// URL
const BASE_URL = 'http://localhost:3030/jsonstore/gifts/';

// List Elements
const listEl = document.querySelector('div#gift-list');

// Button Elements
const loadBtnEl = document.querySelector('button#load-presents');
const addBtnEl = document.querySelector('button#add-present');
const editBtnEl = document.querySelector('button#edit-present');

// Input Elements
const formEl = document.querySelector('form');

const firstInputEl = document.querySelector('input#gift');
const secondInputEl = document.querySelector('input#for');
const thirdInputEl = document.querySelector('input#price');

// Add Event Listeners
loadBtnEl.addEventListener('click', loadButtonHandler);
addBtnEl.addEventListener('click', addHandler);
editBtnEl.addEventListener('click', editHandler);

// Load Fetched Objects
let currentObjectId = '';
loadButtonHandler();

// Load Handler
function loadButtonHandler() {
    listEl.textContent = '';

    fetch(BASE_URL)
        .then(res => res.json())
        .then(res => {
            const objects = Object.values(res);
            editBtnEl.disabled = true;

            objects.forEach(({ gift, for: recipient, price, _id }) => {
                const divSockEl = createEl('div', listEl, undefined, ['gift-sock']);
                const divContentEl = createEl('div', divSockEl, undefined, ['content']);
                createEl('p', divContentEl, gift);
                createEl('p', divContentEl, recipient);
                createEl('p', divContentEl, price);
                const divBtnEl = createEl('div', divContentEl, undefined, ['buttons-container']);
                const btnChangeEl = createEl('button', divBtnEl, 'Change', ['change-btn']);
                const btnDeleteEl = createEl('button', divBtnEl, 'Delete', ['delete-btn']);

                btnChangeEl.addEventListener('click', changeHandler);
                btnDeleteEl.addEventListener('click', deleteHandler);

                // Change Handler
                function changeHandler() {
                    currentObjectId = _id;

                    firstInputEl.value = gift;
                    secondInputEl.value = recipient;
                    thirdInputEl.value = price;

                    addBtnEl.disabled = true;
                    editBtnEl.disabled = false;
                }

                // Delete Handler
                function deleteHandler() {
                    currentObjectId = _id;

                    fetch(`${BASE_URL}${currentObjectId}`, {
                        method: 'DELETE',
                        headers: {
                            'Content-Type': 'application/json',
                        }
                    })
                        .then(loadButtonHandler)
                        .catch(error => console.error('Error:', error));
                }
            })
        })
        .catch(err => {
            console.log(err);
        })
}

// Add Handler
function addHandler() {
    const gift = firstInputEl.value;
    const recipient = secondInputEl.value;
    const price = thirdInputEl.value;

    if (!gift || !recipient || !price) {
        return;
    }

    formEl.reset();

    fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            gift,
            'for': recipient,
            price,
        })
    })
        .then(loadButtonHandler)
        .catch(err => console.log(err.message))
}

// Edit Handler
function editHandler() {
    fetch(`${BASE_URL}${currentObjectId}`, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            gift: firstInputEl.value,
            'for': secondInputEl.value,
            price: thirdInputEl.value,
            _id: currentObjectId
        })
    })
        .then(() => {
            loadButtonHandler();
            addBtnEl.disabled = false;
            editBtnEl.disabled = true;
            formEl.reset();
        }
        )
        .catch(err => console.log(err.message));
}

// Type = string
// Content = string
// Id = string
// Classes = array of strings
// Attributes = object
// Textarea - not implemented 
function createEl(type, parentNode, content, classes, attributes, id) {
    const htmlElement = document.createElement(type);

    if (content && type !== 'input') {
        htmlElement.textContent = content;
    }

    if (content && type === 'input') {
        htmlElement.value = content;
    }

    if (id) {
        htmlElement.id = id;
    }

    if (classes) {
        htmlElement.classList.add(...classes);
    }

    if (attributes) {
        for (const key in attributes) {
            htmlElement.setAttribute(key, attributes[key]);
        }
    }

    if (parentNode) {
        parentNode.appendChild(htmlElement);
    }

    return htmlElement;
}

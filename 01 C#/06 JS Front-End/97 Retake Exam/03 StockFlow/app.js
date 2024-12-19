// URL
const BASE_URL = 'http://localhost:3030/jsonstore/orders/';

const inputDOMSelectors = {
    form: document.querySelector('form'),
    first: document.querySelector('#name'),
    second: document.querySelector('#quantity'),
    third: document.querySelector('#date')
}

const otherDOMSelectors = {
    list: document.querySelector('#list'),
    loadBtn: document.querySelector('#load-orders'),
    addBtn: document.querySelector('#order-btn'),
    editBtn: document.querySelector('#edit-order')
}

// Add Event Listeners
otherDOMSelectors.loadBtn.addEventListener('click', loadButtonHandler);
otherDOMSelectors.addBtn.addEventListener('click', addHandler);
otherDOMSelectors.editBtn.addEventListener('click', editHandler);

// Load Fetched Objects
let currentObjectId = '';
loadButtonHandler();

// Load Handler
function loadButtonHandler() {
    otherDOMSelectors.list.textContent = '';
    fetch(BASE_URL)
        .then(res => res.json())
        .then(res => {
            const objects = Object.values(res);
            otherDOMSelectors.editBtn.disabled = true;

            objects.forEach(({ name, quantity, date, _id }) => {
                const divEl = createEl('div', otherDOMSelectors.list, null, ['container']);
                createEl('h2', divEl, name);
                createEl('h3', divEl, date);
                createEl('h3', divEl, quantity);
                const btnChangeEl = createEl('button', divEl, 'Change', ['change-btn']);
                const btnDeleteEl = createEl('button', divEl, 'Done', ['done-btn']);

                btnChangeEl.addEventListener('click', changeHandler);
                btnDeleteEl.addEventListener('click', deleteHandler);

                // Change Handler
                function changeHandler() {
                    currentObjectId = _id;

                    inputDOMSelectors.first.value = name;
                    inputDOMSelectors.second.value = quantity;
                    inputDOMSelectors.third.value = date;

                    otherDOMSelectors.addBtn.disabled = true;
                    otherDOMSelectors.editBtn.disabled = false;
                }

                // Delete Handler
                function deleteHandler() {
                    currentObjectId = _id;

                    fetch(BASE_URL + currentObjectId, {
                        method: 'DELETE',
                        headers: {
                            'Content-Type': 'application/json',
                        }
                    })
                        .then(loadButtonHandler)
                        .catch(err => console.log(err));
                }
            })
        })
        .catch(err => console.log(err));
}

// Add Handler
function addHandler() {
    const name = inputDOMSelectors.first.value;
    const quantity = inputDOMSelectors.second.value;
    const date = inputDOMSelectors.third.value;

    if (!name || !quantity || !date) return;

    inputDOMSelectors.form.reset();

    fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            name,
            quantity,
            date,
        })
    })
        .then(loadButtonHandler)
        .catch(err => console.log(err));
}

// Edit Handler
function editHandler() {
    fetch(BASE_URL + currentObjectId, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            name: inputDOMSelectors.first.value,
            quantity: inputDOMSelectors.second.value,
            date: inputDOMSelectors.third.value,
            _id: currentObjectId
        })
    })
        .then(() => {
            loadButtonHandler();
            otherDOMSelectors.addBtn.disabled = false;
            otherDOMSelectors.editBtn.disabled = true;
            inputDOMSelectors.form.reset();
        }
        )
        .catch(err => console.log(err));
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

// Created on: 19/12/2024 09:58:22

// URL
const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';

// List Elements
const listEl = document.querySelector('#list');

// Button Elements
const loadBtnEl = document.querySelector('#load-vacations');
const addBtnEl = document.querySelector('#add-vacation');
const editBtnEl = document.querySelector('#edit-vacation');

// Input Elements
const formEl = document.querySelector('form');

const firstInputEl = document.querySelector('#name');
const secondInputEl = document.querySelector('#num-days');
const thirdInputEl = document.querySelector('#from-date');

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

            objects.forEach(({ name, days, date, _id }) => {
                const divContentEl = createEl('div', listEl, undefined, ['container']);
                createEl('h2', divContentEl, name);
                createEl('h3', divContentEl, date);
                createEl('h3', divContentEl, days, undefined, undefined, 'celsius');
                const btnChangeEl = createEl('button', divContentEl, 'Change', ['change-btn']);
                const btnDeleteEl = createEl('button', divContentEl, 'Done', ['done-btn']);

                btnChangeEl.addEventListener('click', changeHandler);
                btnDeleteEl.addEventListener('click', deleteHandler);

                // Change Handler
                function changeHandler() {
                    currentObjectId = _id;

                    firstInputEl.value = name;
                    secondInputEl.value = days;
                    thirdInputEl.value = date;

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
    const name = firstInputEl.value;
    const days = secondInputEl.value;
    const date = thirdInputEl.value;

    if (!name || !days || !date) {
        return;
    }

    formEl.reset();

    fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            name,
            days,
            date,
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
            name: firstInputEl.value,
            days: secondInputEl.value,
            date: thirdInputEl.value,
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

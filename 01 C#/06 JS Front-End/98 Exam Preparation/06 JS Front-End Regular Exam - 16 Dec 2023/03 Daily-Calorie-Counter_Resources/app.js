// URL
const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';

// List Elements
const listEl = document.querySelector('#list');

// Button Elements
const loadBtnEl = document.querySelector('#load-meals');
const addBtnEl = document.querySelector('#add-meal');
const editBtnEl = document.querySelector('#edit-meal');

// Input Elements
const formEl = document.querySelector('form');

const firstInputEl = document.querySelector('#food');
const secondInputEl = document.querySelector('#time');
const thirdInputEl = document.querySelector('#calories');

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

            objects.forEach(({ food, time, calories, _id }) => {
                const divContentEl = createEl('div', listEl, undefined, ['meal']);
                createEl('h2', divContentEl, food);
                createEl('h3', divContentEl, time);
                createEl('h3', divContentEl, calories);
                const divBtnEl = createEl('div', divContentEl, undefined, ['meal-buttons']);
                const btnChangeEl = createEl('button', divBtnEl, 'Change', ['change-meal']);
                const btnDeleteEl = createEl('button', divBtnEl, 'Delete', ['delete-meal']);

                btnChangeEl.addEventListener('click', changeHandler);
                btnDeleteEl.addEventListener('click', deleteHandler);

                // Change Handler
                function changeHandler() {
                    currentObjectId = _id;

                    firstInputEl.value = food;
                    secondInputEl.value = time;
                    thirdInputEl.value = calories;

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
    const food = firstInputEl.value;
    const time = secondInputEl.value;
    const calories = thirdInputEl.value;

    if (!food || !time || !calories) {
        return;
    }

    formEl.reset();

    fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            food,
            time,
            calories,
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
            food: firstInputEl.value,
            time: secondInputEl.value,
            calories: thirdInputEl.value,
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

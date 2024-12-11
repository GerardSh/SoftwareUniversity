// URL
const BASE_URL = 'http://localhost:3030/jsonstore/records/';

// UL Elements
const ulEl = document.querySelector('ul#list');

// Button Elements
const loadBtnEl = document.querySelector('button#load-records');
const addBtnEl = document.querySelector('button#add-record');
const editBtnEl = document.querySelector('button#edit-record');

// Input Elements
const formEl = document.querySelector('form');

const firstInputEl = document.querySelector('input#p-name');
const secondInputEl = document.querySelector('input#steps');
const thirdInputEl = document.querySelector('input#calories');

// Add Event Listeners
loadBtnEl.addEventListener('click', loadButtonHandler);
addBtnEl.addEventListener('click', addHandler);
editBtnEl.addEventListener('click', editHandler);

// Load Fetched Objects
let currentObjectId = '';
loadButtonHandler();

// Load Handler
function loadButtonHandler() {
    ulEl.textContent = '';

    fetch(BASE_URL)
        .then(res => res.json())
        .then(res => {
            const objects = Object.values(res);

            objects.forEach(({ name, steps, calories, _id }) => {
                const liEl = createEl('li', undefined, undefined, ['record'], undefined, ulEl);
                const divEl = createEl('div', undefined, undefined, ['info'], undefined, liEl);
                createEl('p', name, undefined, undefined, undefined, divEl);
                createEl('p', steps, undefined, undefined, undefined, divEl);
                createEl('p', calories, undefined, undefined, undefined, divEl);
                const divBtnEl = createEl('div', undefined, undefined, ['btn-wrapper'], undefined, liEl);
                const btnChangeEl = createEl('button', 'Change', undefined, ['change-btn'], undefined, divBtnEl);
                const btnDeleteEl = createEl('button', 'Delete', undefined, ['delete-btn'], undefined, divBtnEl);

                btnChangeEl.addEventListener('click', changeHandler);
                btnDeleteEl.addEventListener('click', deleteHandler);

                // Change Handler
                function changeHandler() {
                    currentObjectId = _id;

                    firstInputEl.value = name;
                    secondInputEl.value = steps;
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
    const name = firstInputEl.value;
    const steps = secondInputEl.value;
    const calories = thirdInputEl.value;

    if (!name || !steps || !calories) {
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
            steps,
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
            name: firstInputEl.value,
            steps: secondInputEl.value,
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
function createEl(type, content, id, classes, attributes, parentNode) {
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

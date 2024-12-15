// URL
const BASE_URL = 'http://localhost:3030/jsonstore/workout/';

const inputDOMSelectors = {
    form: document.querySelector('form'),
    first: document.querySelector('#workout'),
    second: document.querySelector('#location'),
    third: document.querySelector('#date')
}

const otherDOMSelectors = {
    list: document.querySelector('#list'),
    loadBtn: document.querySelector('#load-workout'),
    addBtn: document.querySelector('#add-workout'),
    editBtn: document.querySelector('#edit-workout')
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

            objects.forEach(({ workout, location, date, _id }) => {
                const liEl = createEl('li', otherDOMSelectors.list, null, ['container']);
                createEl('h2', liEl, workout);
                createEl('h3', liEl, date);
                createEl('h3', liEl, location, null, null, 'location');
                const divBtnEl = createEl('div', liEl, null, ['buttons-container']);
                const btnChangeEl = createEl('button', divBtnEl, 'Change', ['change-btn']);
                const btnDeleteEl = createEl('button', divBtnEl, 'Done', ['delete-btn']);

                btnChangeEl.addEventListener('click', changeHandler);
                btnDeleteEl.addEventListener('click', deleteHandler);

                // Change Handler
                function changeHandler() {
                    currentObjectId = _id;

                    inputDOMSelectors.first.value = workout;
                    inputDOMSelectors.second.value = location;
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
    const workout = inputDOMSelectors.first.value;
    const location = inputDOMSelectors.second.value;
    const date = inputDOMSelectors.third.value;

    if (!workout || !location || !date) return;

    inputDOMSelectors.form.reset();

    fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            workout,
            location,
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
            workout: inputDOMSelectors.first.value,
            location: inputDOMSelectors.second.value,
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

// Created on: 15/12/2024 10:35:52
// URL
const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';

// List Elements
const listEl = document.querySelector('#list');

// Button Elements
const loadBtnEl = document.querySelector('#load-course');
const addBtnEl = document.querySelector('#add-course');
const editBtnEl = document.querySelector('#edit-course');

// Input Elements
const formEl = document.querySelector('form');

const firstInputEl = document.querySelector('#course-name');
const secondInputEl = document.querySelector('#course-type');
const thirdInputEl = document.querySelector('#description');
const fourthInputEl = document.querySelector('#teacher-name');

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

            objects.forEach(({ title, type, description, teacher, _id }) => {
                const divContentEl = createEl('div', listEl, undefined, ['container']);
                createEl('h2', divContentEl, title);
                createEl('h3', divContentEl, teacher);
                createEl('h3', divContentEl, type);
                createEl('h4', divContentEl, description);
                const btnChangeEl = createEl('button', divContentEl, 'Edit Course', ['edit-btn']);
                const btnDeleteEl = createEl('button', divContentEl, 'Finish Course', ['finish-btn']);

                btnChangeEl.addEventListener('click', changeHandler);
                btnDeleteEl.addEventListener('click', deleteHandler);

                // Change Handler
                function changeHandler() {
                    currentObjectId = _id;

                    firstInputEl.value = title;
                    secondInputEl.value = type;
                    thirdInputEl.value = description;
                    fourthInputEl.value = teacher;

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
    const title = firstInputEl.value;
    const type = secondInputEl.value;
    const description = thirdInputEl.value;
    const teacher = fourthInputEl.value;

    if (!title || !description || !type || !teacher) {
        return;
    }

    formEl.reset();

    fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            title,
            type,
            description,
            teacher
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
            title: firstInputEl.value,
            type: thirdInputEl.value,
            description: secondInputEl.value,
            teacher: fourthInputEl.value,
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

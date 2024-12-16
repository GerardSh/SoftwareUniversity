// URL
const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';

const inputDOMSelectors = {
    form: document.querySelector('form'),
    name: document.querySelector('#title')
}

const otherDOMSelectors = {
    list: document.querySelector('#todo-list'),
    loadBtn: document.querySelector('#load-button'),
    addBtn: document.querySelector('#add-button'),
}

// Add Event Listeners
otherDOMSelectors.loadBtn.addEventListener('click', loadButtonHandler);
otherDOMSelectors.addBtn.addEventListener('click', addHandler);

// Load Fetched Objects
let currentObjectId = '';
loadButtonHandler();

// Load Handler
function loadButtonHandler(e) {
    if (e) e.preventDefault();

    otherDOMSelectors.list.textContent = '';
    fetch(BASE_URL)
        .then(res => res.json())
        .then(res => {
            const objects = Object.values(res);

            objects.forEach(({ name, _id }) => {
                const liEl = createEl('li', otherDOMSelectors.list);
                const buttonEl = createEl('span', liEl, name);
                const btnRemoveEl = createEl('button', liEl, 'Remove');
                const btnEditEl = createEl('button', liEl, 'Edit');

                btnRemoveEl.addEventListener('click', removeHandler);
                btnEditEl.addEventListener('click', editHandler);

                // Edit Handler
                function editHandler() {
                    if (e) e.preventDefault();

                    buttonEl.remove();
                    btnRemoveEl.remove();
                    btnEditEl.remove();

                    const inputEl = createEl('input', liEl, name);
                    liEl.appendChild(btnRemoveEl);
                    const btnSubmitEl = createEl('button', liEl, 'Submit');

                    btnSubmitEl.addEventListener('click', submitHandler);

                    function submitHandler() {

                        fetch(BASE_URL + _id, {
                            method: 'PATCH',
                            headers: {
                                'Content-type': 'application/json',
                            },
                            body: JSON.stringify({ name: inputEl.value })
                        })
                            .then(() => loadButtonHandler())
                            .catch(err => console.log(err));
                    }
                }

                // Remove Handler
                function removeHandler() {
                    if (e) e.preventDefault();

                    fetch(BASE_URL + _id, {
                        method: 'DELETE',
                        headers: {
                            'Content-Type': 'application/json',
                        }
                    })
                        .then(() => loadButtonHandler())
                        .catch(err => console.log(err));
                }
            })
        })
        .catch(err => {

            console.log(err)
        });
}

// Add Handler
function addHandler(e) {
    if (e) e.preventDefault();

    const name = inputDOMSelectors.name.value;

    if (!name) return;

    inputDOMSelectors.form.reset();

    fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            name
        })
    })
        .then(() => loadButtonHandler())
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

// URL
const BASE_URL = 'http://localhost:3030/jsonstore/matches/';

const inputDOMSelectors = {
    form: document.querySelector('form'),
    first: document.querySelector('#host'),
    second: document.querySelector('#score'),
    third: document.querySelector('#guest')
}

const otherDOMSelectors = {
    list: document.querySelector('#list'),
    loadBtn: document.querySelector('#load-matches'),
    addBtn: document.querySelector('#add-match'),
    editBtn: document.querySelector('#edit-match')
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

            objects.forEach(({ host, score, guest, _id }) => {
                const liEl = createEl('li', otherDOMSelectors.list, null, ['match']);
                const divEl = createEl('li', liEl, null, ['info']);
                createEl('p', divEl, host);
                createEl('p', divEl, score);
                createEl('p', divEl, guest);
                const divBtnEl = createEl('div', liEl, undefined, ['btn-wrapper']);
                const btnChangeEl = createEl('button', divBtnEl, 'Change', ['change-btn']);
                const btnDeleteEl = createEl('button', divBtnEl, 'Delete', ['delete-btn']);

                btnChangeEl.addEventListener('click', changeHandler);
                btnDeleteEl.addEventListener('click', deleteHandler);

                // Change Handler
                function changeHandler() {
                    currentObjectId = _id;

                    inputDOMSelectors.first.value = host;
                    inputDOMSelectors.second.value = score;
                    inputDOMSelectors.third.value = guest;

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
                        .catch(error => console.error(error));
                }
            })
        })
        .catch(err => {
            console.log(err);
        })
}

// Add Handler
function addHandler() {
    const host = inputDOMSelectors.first.value;
    const score = inputDOMSelectors.second.value;
    const guest = inputDOMSelectors.third.value;

    if (!host || !score || !guest) return;

    inputDOMSelectors.form.reset();

    fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            host,
            score,
            guest,
        })
    })
        .then(loadButtonHandler)
        .catch(err => console.error(err));
}

// Edit Handler
function editHandler() {
    fetch(BASE_URL + currentObjectId, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            host: inputDOMSelectors.first.value,
            score: inputDOMSelectors.second.value,
            guest: inputDOMSelectors.third.value,
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
        .catch(err => console.error(err));
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

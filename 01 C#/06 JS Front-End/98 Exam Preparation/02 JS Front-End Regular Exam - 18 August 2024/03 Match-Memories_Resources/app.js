// URL
const BASE_URL = 'http://localhost:3030/jsonstore/matches/';

// UL Elements
const ulEl = document.querySelector('ul#list');

// Button Elements
const loadBtnEl = document.querySelector('button#load-matches');
const addBtnEl = document.querySelector('button#add-match');
const editBtnEl = document.querySelector('button#edit-match');

// Input Elements
const formEl = document.querySelector('form');
const hostEl = document.querySelector('input#host');
const scoreEl = document.querySelector('input#score');
const guestEl = document.querySelector('input#guest');

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

            objects.forEach(({ host, score, guest, _id }) => {
                const liEl = createEl('li', undefined, undefined, ['match'], undefined, ulEl);
                liEl.setAttribute('_id', _id)
                const divInfoEl = createEl('div', undefined, undefined, ['info'], undefined, liEl);
                const pHostEl = createEl('p', host, undefined, undefined, undefined, divInfoEl);
                const pScoreEl = createEl('p', score, undefined, undefined, undefined, divInfoEl);
                const pGuestEl = createEl('p', guest, undefined, undefined, undefined, divInfoEl);
                const divBtnEl = createEl('div', undefined, undefined, ['btn-wrapper'], undefined, liEl);
                const btnChangeEl = createEl('button', 'Change', undefined, ['change-btn'], undefined, divBtnEl);
                const btnDeleteEl = createEl('button', 'Delete', undefined, ['delete-btn'], undefined, divBtnEl);

                btnChangeEl.addEventListener('click', () => changeHandler(liEl, pHostEl, pScoreEl, pGuestEl));
                btnDeleteEl.addEventListener('click', () => deleteHandler(liEl));
            })
        })
        .catch(err => {
            console.log(err);
        })
}

// Add Handler
function addHandler() {
    const host = hostEl.value;
    const score = scoreEl.value;
    const guest = guestEl.value;

    if (!host || !score || !guest) {
        return;
    }

    formEl.reset();

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
        .then(response => loadButtonHandler())
        .catch(err => console.log(err.message))
}

// Change Handler
function changeHandler(liEl, pHostEl, pScoreEl, pGuestEl) {
    currentObjectId = liEl.getAttribute('_id');

    hostEl.value = pHostEl.textContent;
    scoreEl.value = pScoreEl.textContent;
    guestEl.value = pGuestEl.textContent;

    addBtnEl.disabled = true;
    editBtnEl.disabled = false;
}

// Edit Handler
function editHandler() {
    fetch(`${BASE_URL}${currentObjectId}`, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            host: hostEl.value,
            score: scoreEl.value,
            guest: guestEl.value,
            _id: currentObjectId
        })
    })
        .then(response => {
            loadButtonHandler();
            addBtnEl.disabled = false;
            editBtnEl.disabled = true;
            formEl.reset();
        }
        )
        .catch(err => console.log(err.message));
}

function deleteHandler(liEl) {
    liEl.remove();
    currentObjectId = liEl.getAttribute('_id');

    fetch(`${BASE_URL}${currentObjectId}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        }
    })
        .then()
        .catch(error => console.error('Error:', error));
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

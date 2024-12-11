const BASE_URL = 'http://localhost:3030/jsonstore/appointments/';

const loadBtnEl = document.querySelector('#load-appointments');
const ulEl = document.querySelector('#appointments-list');
const editAppointmentsBtnEl = document.querySelector('#edit-appointment');
const addAppointmentBtnEl = document.querySelector('#add-appointment');
const formEl = document.querySelector('form');

const modelEl = document.querySelector('input#car-model');
const serviceEl = document.querySelector('select#car-service');
const dateEl = document.querySelector('input#date');

loadBtnEl.addEventListener('click', loadButtonHandler);
addAppointmentBtnEl.addEventListener('click', addHandler);
editAppointmentsBtnEl.addEventListener('click', editHandler);

let currentObjectId = '';

loadButtonHandler();

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

function changeHandler(e, h2ModelEl, h3DateEl, h3ServiceEl) {
    const parentEl = e.target.parentNode.parentNode;
    const _id = parentEl.getAttribute('_id');
    currentObjectId = _id;

    modelEl.value = h2ModelEl.textContent;
    dateEl.value = h3DateEl.textContent;
    serviceEl.value = h3ServiceEl.textContent;

    addAppointmentBtnEl.disabled = true;
    editAppointmentsBtnEl.disabled = false;
}

function editHandler() {
    fetch(`${BASE_URL}${currentObjectId}`, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            model: modelEl.value,
            service: serviceEl.value,
            date: dateEl.value,
            _id: currentObjectId
        })
    })
        .then(response => {
            loadButtonHandler();
            addAppointmentBtnEl.disabled = false;
            editAppointmentsBtnEl.disabled = true;
            formEl.reset();
        }
        )
        .catch(err => console.log(err.message));
}

function loadButtonHandler() {
    ulEl.textContent = '';

    fetch(BASE_URL)
        .then(res => res.json())
        .then(res => {
            const objects = Object.values(res);

            objects.forEach(({ model, service, date, _id }) => {
                const liEl = createEl('li', undefined, undefined, ['appointment'], undefined, ulEl);
                liEl.setAttribute('_id', _id)
                const h2ModelEl = createEl('h2', model, undefined, undefined, undefined, liEl);
                const h3DateEl = createEl('h3', date, undefined, undefined, undefined, liEl);
                const h3ServiceEl = createEl('h3', service, undefined, undefined, undefined, liEl);
                const divEl = createEl('div', undefined, undefined, ['buttons-appointment'], undefined, liEl);
                const btnChangeEl = createEl('button', 'Change', undefined, ['change-btn'], undefined, divEl);
                const btnDeleteEl = createEl('button', 'Delete', undefined, ['delete-btn'], undefined, divEl);

                btnChangeEl.addEventListener('click', (e) => changeHandler(e, h2ModelEl, h3DateEl, h3ServiceEl));
                btnDeleteEl.addEventListener('click', () => deleteHandler(liEl));
            })
        })
        .catch(err => {
            console.log(err);
        })
}

function addHandler() {
    const model = modelEl.value;
    const service = serviceEl.value;
    const date = dateEl.value;

    if (!model || !service || !date) {
        return;
    }

    formEl.reset();

    fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            model,
            service,
            date,
        })
    })
        .then(response => loadButtonHandler())
        .catch(err => console.log(err.message))
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

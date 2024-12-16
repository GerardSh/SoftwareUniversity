// URL
const BASE_URL = 'http://localhost:3030/jsonstore/grocery/';

const inputDOMSelectors = {
    form: document.querySelector('form'),
    product: document.querySelector('#product'),
    count: document.querySelector('#count'),
    price: document.querySelector('#price')
}

const otherDOMSelectors = {
    list: document.querySelector('#tbody'),
    loadBtn: document.querySelector('#load-product'),
    addBtn: document.querySelector('#add-product'),
    updateBtn: document.querySelector('#update-product'),
}

// Add Event Listeners
otherDOMSelectors.loadBtn.addEventListener('click', loadButtonHandler);
otherDOMSelectors.addBtn.addEventListener('click', addHandler);
otherDOMSelectors.updateBtn.addEventListener('click', updateHandler);

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

            objects.forEach(({ product, count, price, _id }) => {
                const trEl = createEl('tr', otherDOMSelectors.list);
                createEl('td', trEl, product, ['name']);
                createEl('td', trEl, count, ['count-product']);
                createEl('td', trEl, price, ['product-price']);
                const tdBtnEl = createEl('td', trEl, null, ['btn']);

                const btnUpdEl = createEl('button', tdBtnEl, 'Update', ['update']);
                const btnDelEl = createEl('button', tdBtnEl, 'Delete', ['delete']);

                btnUpdEl.addEventListener('click', changeHandler);
                btnDelEl.addEventListener('click', delHandler);

                // Change Handler
                function changeHandler() {
                    if (e) e.preventDefault();

                    trEl.remove();
                    otherDOMSelectors.updateBtn.disabled = false;
                    otherDOMSelectors.addBtn.disabled = true;

                    inputDOMSelectors.product.value = product;
                    inputDOMSelectors.price.value = price;
                    inputDOMSelectors.count.value = count;

                    currentObjectId = _id;
                }

                // Delete Handler
                function delHandler() {
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
        .catch(err => { console.log(err) });
}

// Add Handler
function addHandler(e) {
    if (e) e.preventDefault();

    const product = inputDOMSelectors.product.value;
    const count = inputDOMSelectors.count.value;
    const price = inputDOMSelectors.price.value;

    if (!product || !count || !price) return;

    inputDOMSelectors.form.reset();

    fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            product,
            price,
            count
        })
    })
        .then(() => loadButtonHandler())
        .catch(err => console.log(err));
}

function updateHandler(e) {
    if (e) e.preventDefault();

    const product = inputDOMSelectors.product.value;
    const count = inputDOMSelectors.count.value;
    const price = inputDOMSelectors.price.value;

    otherDOMSelectors.updateBtn.disabled = true;
    otherDOMSelectors.addBtn.disabled = false;
    inputDOMSelectors.form.reset();

    fetch(BASE_URL + currentObjectId, {
        method: 'PATCH',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            product,
            count,
            price
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

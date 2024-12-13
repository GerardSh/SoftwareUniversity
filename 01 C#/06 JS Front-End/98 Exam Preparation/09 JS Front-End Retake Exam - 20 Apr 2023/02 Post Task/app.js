window.addEventListener("load", solve);

function solve() {
    // UL Elements
    const ulFirstEl = document.querySelector('#review-list');
    const ulSecondEl = document.querySelector('#published-list');

    // Form Element
    const formEl = document.querySelector('form');

    const firstInputEl = document.querySelector('#task-title');
    const secondInputEl = document.querySelector('#task-category');
    const thirdInputEl = document.querySelector('#task-content');

    // Button Elements
    const addBtnEl = document.querySelector('#publish-btn');

    // Adding Handlers
    addBtnEl.addEventListener('click', addHandler);

    // Add Handler
    function addHandler(e) {
        e.preventDefault();

        // Input Values
        const firstValue = firstInputEl.value;
        const secondValue = secondInputEl.value;
        const thirdValue = thirdInputEl.value;

        if (!firstValue || !secondValue || !thirdValue) return;

        addBtnEl.disabled = true;
        formEl.reset();

        const liEl = createEl('li', ulFirstEl, undefined, ['rpost']);
        const arEl = createEl('article', liEl);
        createEl('h4', arEl, firstValue);
        createEl('p', arEl, `Category: ${secondValue}`);
        createEl('p', arEl, `Content: ${thirdValue}`);
        const btnEditEl = createEl('button', liEl, 'Edit', ['action-btn', 'edit']);
        const btnDoneEl = createEl('button', liEl, 'Post', ['action-btn', 'post']);

        btnEditEl.addEventListener('click', editHandler);
        btnDoneEl.addEventListener('click', doneHandler);

        // Edit Handler
        function editHandler() {
            addBtnEl.disabled = false;

            firstInputEl.value = firstValue;
            secondInputEl.value = secondValue;
            thirdInputEl.value = thirdValue;

            liEl.remove();
        }

        // Done Handler
        function doneHandler() {
            addBtnEl.disabled = false;

            ulSecondEl.appendChild(liEl);
            btnEditEl.remove();
            btnDoneEl.remove();
        }
    }

    // Type = string
    // Content = string
    // Classes = array of strings
    // Attributes = object
    // Id = string
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
}

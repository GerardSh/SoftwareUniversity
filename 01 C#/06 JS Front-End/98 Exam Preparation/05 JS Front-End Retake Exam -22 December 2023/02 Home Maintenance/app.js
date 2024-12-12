window.addEventListener("load", solve);

function solve() {
    // UL Elements
    const ulFirstEl = document.querySelector('ul#task-list');
    const ulSecondEl = document.querySelector('ul#done-list');

    // Form Element
    const formEl = document.querySelector('form');

    const firstInputEl = document.querySelector('input#place');
    const secondInputEl = document.querySelector('input#action');
    const thirdInputEl = document.querySelector('input#person');

    // Button Elements
    const addBtnEl = document.querySelector('input#add-btn');

    // Adding Handlers
    addBtnEl.addEventListener('click', addHandler);

    // Add Handler
    function addHandler(e) {
        e.preventDefault();

        // Input Values
        const firstValue = firstInputEl.value;
        const secondValue = secondInputEl.value;
        const thirdValue = thirdInputEl.value;

        if (!firstValue || !secondValue || !thirdValue) {
            return;
        }

        formEl.reset();

        const liEl = createEl('li', ulFirstEl, undefined, ['clean-task']);
        const arEl = createEl('article', liEl);
        createEl('p', arEl, `Place:${firstValue}`);
        createEl('p', arEl, `Action:${thirdValue}`);
        createEl('p', arEl, `Person:${secondValue}`);
        const divBtnsEl = createEl('div', liEl, undefined, ['buttons']);
        const btnEditEl = createEl('button', divBtnsEl, 'Edit', ['edit']);
        const btnDoneEl = createEl('button', divBtnsEl, 'Done', ['done']);

        btnEditEl.addEventListener('click', editHandler);
        btnDoneEl.addEventListener('click', doneHandler);

        // Edit Handler
        function editHandler() {
            firstInputEl.value = firstValue;
            secondInputEl.value = secondValue;
            thirdInputEl.value = thirdValue;

            liEl.remove();
        }

        // Done Handler
        function doneHandler() {
            ulSecondEl.appendChild(liEl);
            divBtnsEl.remove();

            const btnDeleteEl = createEl('button', liEl, 'Delete', ['delete'],);

            btnDeleteEl.addEventListener('click', newBtnHandler);
        }

        // Delete Handler
        function newBtnHandler() {
            liEl.remove();
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

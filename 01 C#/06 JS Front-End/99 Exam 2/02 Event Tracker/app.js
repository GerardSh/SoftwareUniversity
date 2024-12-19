window.addEventListener("load", solve);

function solve() {
    const inputDOMSelectors = {
        form: document.querySelector('form'),
        first: document.querySelector('#event'),
        second: document.querySelector('#note'),
        third: document.querySelector('#date')
    }

    const otherDOMSelectors = {
        firstList: document.querySelector('#upcoming-list'),
        secondList: document.querySelector('#events-list'),
        addBtn: document.querySelector('#save'),
        delBtn: document.querySelector('.btn.delete')
    }

    // Adding Handlers
    otherDOMSelectors.addBtn.addEventListener('click', addHandler);

    // Add Handler
    function addHandler(e) {
        e.preventDefault();

        // Input Values
        const firstValue = inputDOMSelectors.first.value;
        const secondValue = inputDOMSelectors.second.value;
        const thirdValue = inputDOMSelectors.third.value;

        if (!firstValue || !secondValue || !thirdValue) return;

        inputDOMSelectors.form.reset();

        const liEl = createEl('li', otherDOMSelectors.firstList, null, ['event-item']);
        const divEl = createEl('div', liEl, null, ['event-container']);
        const arEl = createEl('article', divEl);
        createEl('p', arEl, 'Name: ' + firstValue);
        createEl('p', arEl, 'Note: ' + secondValue);
        createEl('p', arEl, 'Date: ' + thirdValue);

        const divBtns = createEl('div', divEl, null, ['buttons']);

        const editBtnEl = createEl('button', divBtns, 'Edit', ['btn', 'edit']);
        const doneBtnEl = createEl('button', divBtns, 'Done', ['btn', 'done']);

        editBtnEl.addEventListener('click', editHandler);
        doneBtnEl.addEventListener('click', doneHandler);

        // Edit Handler
        function editHandler(e) {
            e.preventDefault();

            inputDOMSelectors.first.value = firstValue;
            inputDOMSelectors.second.value = secondValue;
            inputDOMSelectors.third.value = thirdValue;

            liEl.remove();
        }

        // Done Handler
        function doneHandler(e) {
            e.preventDefault();

            otherDOMSelectors.secondList.appendChild(liEl);
            liEl.appendChild(arEl);
            divEl.remove();
            divBtns.remove();
        }
    }

    otherDOMSelectors.delBtn.addEventListener('click', (e) => {
        e.preventDefault();

        otherDOMSelectors.secondList.textContent = '';
    });

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

// Created on: 19/12/2024 09:45:18

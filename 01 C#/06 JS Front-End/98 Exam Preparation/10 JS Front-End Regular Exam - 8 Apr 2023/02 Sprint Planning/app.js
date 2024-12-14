window.addEventListener("load", solve);

function solve() {
    // UL Elements
    const ulFirstEl = document.querySelector('#tasks-section');

    // Form Element
    const formEl = document.querySelector('form');

    const firstInputEl = document.querySelector('#title');
    const secondInputEl = document.querySelector('#description');
    const thirdInputEl = document.querySelector('#label');
    const fourthInputEl = document.querySelector('#points');
    const fifthInputEl = document.querySelector('#assignee');

    // Button Elements
    const addBtnEl = document.querySelector('#create-task-btn');
    const delBtnEl = document.querySelector('#delete-task-btn');

    // Other Elements
    const totalPointsEl = document.querySelector('#total-sprint-points');

    // Map
    const featureToIconMap = {
        Feature: '&#8865',
        'Low Priority Bug': '&#9737',
        'High Priority Bug': '&#9888'
    }

    const labelMap = {
        Feature: 'feature',
        'Low Priority Bug': 'low-priority',
        'High Priority Bug': 'high-priority'
    }

    // Variables
    let id = 1;
    let totalPoints = 0;

    // Adding Handlers
    addBtnEl.addEventListener('click', addHandler);
    delBtnEl.addEventListener('click', formDelHandler);

    // Add Handler
    function addHandler() {
        // Input Values
        const firstValue = firstInputEl.value;
        const secondValue = secondInputEl.value;
        const thirdValue = thirdInputEl.value;
        const fourthValue = fourthInputEl.value;
        const fifthValue = fifthInputEl.value;

        if (!firstValue || !secondValue || !thirdValue || !fourthValue || !fifthValue) return;

        formEl.reset();
        totalPoints += Number(fourthValue);
        totalPointsEl.textContent = `Total Points ${totalPoints}pts`;

        const arEl = createEl('article', ulFirstEl, undefined, ['task-card'], undefined, `task-${id++}`);
        const divElt = createEl('div', arEl, undefined, ['task-card-label', labelMap[thirdValue]]);
        divElt.innerHTML = `${thirdValue} ${featureToIconMap[thirdValue]}`;

        createEl('h3', arEl, firstValue, ['task-card-title']);
        createEl('p', arEl, secondValue, ['task-card-description']);
        createEl('div', arEl, `Estimated at ${fourthValue} pts`, ['task-card-points']);
        createEl('div', arEl, `Assigned to: ${fifthValue}`, ['task-card-assignee']);
        const divEl = createEl('div', arEl, undefined, ['task-card-actions']);
        const btnDelEl = createEl('button', divEl, 'Delete');

        btnDelEl.addEventListener('click', articleDelHandler);

        function articleDelHandler() {
            firstInputEl.value = firstValue;
            secondInputEl.value = secondValue;
            thirdInputEl.value = thirdValue;
            fourthInputEl.value = fourthValue;
            fifthInputEl.value = fifthValue;

            changeInputElDisableStatus();

            document.querySelector('#task-id').value = arEl.id;
        }
    }

    function formDelHandler() {
        const taskToDelete = document.querySelector('#task-id').value;
        const el = document.querySelector(`#${taskToDelete}`);
        let number = Number(el.children[3].textContent.match(/\d+/g)[0]);
        totalPoints -= number;
        totalPointsEl.textContent = `Total Points ${totalPoints}pts`;
        el.remove();
        formEl.reset();

        changeInputElDisableStatus();
    }

    function changeInputElDisableStatus() {
        firstInputEl.disabled = !firstInputEl.disabled;
        secondInputEl.disabled = !secondInputEl.disabled;
        thirdInputEl.disabled = !thirdInputEl.disabled;
        fourthInputEl.disabled = !fourthInputEl.disabled;
        fifthInputEl.disabled = !fifthInputEl.disabled;
        addBtnEl.disabled = !addBtnEl.disabled;
        delBtnEl.disabled = !delBtnEl.disabled;
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

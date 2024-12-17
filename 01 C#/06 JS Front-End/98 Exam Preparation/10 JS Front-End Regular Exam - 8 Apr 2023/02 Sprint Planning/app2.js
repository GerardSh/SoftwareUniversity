window.addEventListener('load', solve);

function solve() {
    const inputDOMSelectors = {
        form: document.querySelector('form'),
        title: document.querySelector('#title'),
        description: document.querySelector('#description'),
        label: document.querySelector('#label'),
        points: document.querySelector('#points'),
        assignee: document.querySelector('#assignee')
    }

    const otherDOMSelectors = {
        list: document.querySelector('#tasks-section'),
        pPoints: document.querySelector('#total-sprint-points'),
        createBtn: document.querySelector('#create-task-btn'),
        delBtn: document.querySelector('#delete-task-btn')
    }

    let taskId = 1;
    let totalPointsSum = 0;
    let currentPointsToDelete = 0;

    otherDOMSelectors.createBtn.addEventListener('click', createHandler);
    otherDOMSelectors.delBtn.addEventListener('click', delHandler);

    otherDOMSelectors.delBtn.disabled = true;

    function createHandler(e) {
        if (e) e.preventDefault();

        const title = inputDOMSelectors.title.value;
        const description = inputDOMSelectors.description.value;
        const label = inputDOMSelectors.label.value;
        const points = inputDOMSelectors.points.value;
        const assignee = inputDOMSelectors.assignee.value;

        if (!title || !description || !points || !assignee) return;

        inputDOMSelectors.form.reset();
        totalPointsSum += Number(points);
        otherDOMSelectors.pPoints.textContent = `Total Points ${totalPointsSum}pts`
        const currentTaskId = taskId++;

        const arEl = createEl('article', otherDOMSelectors.list, null, ['task-card'], null, `task-${currentTaskId}`);
        const labelDivEl = createEl('div', arEl, null, ['task-card-label']);

        if (label === 'Feature') {
            labelDivEl.classList.add(label.toLowerCase());
            labelDivEl.innerHTML = 'Feature &#8865';
        } else if (label.includes('Low')) {
            labelDivEl.classList.add('low-priority');
            labelDivEl.innerHTML = 'Low Priority Bug &#9737';
        } else {
            labelDivEl.classList.add('high-priority');
            labelDivEl.innerHTML = 'High Priority Bug &#9888';
        }

        createEl('h3', arEl, title, ['task-card-title']);
        createEl('p', arEl, description, ['task-card-description']);
        createEl('div', arEl, `Estimated at ${points} pts`, ['task-card-points']);
        createEl('div', arEl, `Assigned to: ${assignee}`, ['task-card-assignee']);
        const actionsDivEl = createEl('div', arEl, null, ['task-card-actions']);
        const delBtnEl = createEl('button', actionsDivEl, 'Delete');

        delBtnEl.addEventListener('click', confirmDelHandler);

        function confirmDelHandler(e) {
            inputDOMSelectors.title.value = title;
            inputDOMSelectors.description.value = description;
            inputDOMSelectors.label.value = label;
            inputDOMSelectors.points.value = points;
            inputDOMSelectors.assignee.value = assignee;

            disableOrEnableInputAndButtonElements();

            document.querySelector('#task-id').value = currentTaskId;
            currentPointsToDelete = Number(points);
        }
    }

    function delHandler(e) {
        if (e) e.preventDefault();
        const taskId = document.querySelector('#task-id').value;

        document.querySelector('#task-' + taskId).remove();
        inputDOMSelectors.form.reset();

        disableOrEnableInputAndButtonElements();

        totalPointsSum -= currentPointsToDelete;
        otherDOMSelectors.pPoints.textContent = `Total Points ${totalPointsSum}pts`
    }

    function disableOrEnableInputAndButtonElements() {
        inputDOMSelectors.assignee.disabled = !inputDOMSelectors.assignee.disabled;
        inputDOMSelectors.description.disabled = !inputDOMSelectors.description.disabled;
        inputDOMSelectors.label.disabled = !inputDOMSelectors.label.disabled;
        inputDOMSelectors.points.disabled = !inputDOMSelectors.points.disabled;
        inputDOMSelectors.title.disabled = !inputDOMSelectors.title.disabled;

        otherDOMSelectors.delBtn.disabled = !otherDOMSelectors.delBtn.disabled;
        otherDOMSelectors.createBtn.disabled = !otherDOMSelectors.createBtn.disabled;

        Array.from(otherDOMSelectors.list.querySelectorAll('button')).forEach(x => x.disabled = !x.disabled);
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

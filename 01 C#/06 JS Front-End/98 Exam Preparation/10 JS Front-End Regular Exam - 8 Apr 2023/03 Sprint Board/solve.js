// TODO:
function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';

    const inputDOMSelectors = {
        title: document.querySelector('#title'),
        description: document.querySelector('#description')
    }

    const otherDOMSelectors = {
        loadBtn: document.querySelector('#load-board-btn'),
        addBtn: document.querySelector('#create-task-btn'),
        toDoList: document.querySelector('#todo-section > .task-list'),
        inProgressList: document.querySelector('#in-progress-section > .task-list'),
        codeList: document.querySelector('#code-review-section > .task-list'),
        doneList: document.querySelector('#done-section > .task-list'),
        form: document.querySelector('form')
    }

    const statusToElementMap = {
        ToDo: otherDOMSelectors.toDoList,
        'In Progress': otherDOMSelectors.inProgressList,
        'Code Review': otherDOMSelectors.codeList,
        Done: otherDOMSelectors.doneList
    }

    const buttonTextMap = {
        ToDo: 'Move to In Progress',
        'In Progress': 'Move to Code Review',
        'Code Review': 'Move to Done',
        Done: 'Close'
    }

    otherDOMSelectors.loadBtn.addEventListener('click', loadHandler);
    otherDOMSelectors.addBtn.addEventListener('click', addHandler);

    loadHandler();

    function loadHandler(e) {
        if (e) {
            e.preventDefault();
        }

        Array.from(document.querySelectorAll('.task-list'))
            .forEach(ul => ul.textContent = '');

        fetch(BASE_URL)
            .then(res => res.json())
            .then(res => {
                Object.values(res).forEach(({ description, status, title, _id }) => {
                    const liEl = createEl('li', statusToElementMap[status], null, ['task']);
                    createEl('h3', liEl, title);
                    createEl('p', liEl, description);
                    const btnEl = createEl('button', liEl, buttonTextMap[status]);

                    btnEl.addEventListener('click', () => moveTaskHandler(status, _id));
                })
            }).catch(err => console.log(err))
    }

    function addHandler(e) {
        if (e) {
            e.preventDefault();
        }

        const title = inputDOMSelectors.title.value;
        const description = inputDOMSelectors.description.value;
        const status = 'ToDo';

        if (!title || !description) return;

        otherDOMSelectors.form.reset();

        fetch(BASE_URL, {
            method: 'POST',
            headers: {
                'Content-type': 'application/json',
            },
            body: JSON.stringify({
                title,
                description,
                status
            })
        })
            .then(() => loadHandler())
            .catch(err => console.log(err))
    }

    function moveTaskHandler(status, _id) {
        let newStatus = '';

        switch (status) {
            case 'ToDo': {
                newStatus = 'In Progress';
            }
                break;
            case 'In Progress': {
                newStatus = 'Code Review';
            }
                break;
            case 'Code Review': {
                newStatus = 'Done';
            }
                break;
            case 'Done': {
                newStatus = 'Close';
            }
                break;
        }

        const headers = {
            method: 'PATCH',
            headers: {
                'Content-type': 'application/json',
            },
            body: JSON.stringify({ status: newStatus })
        };

        if (newStatus == 'Close') {
            headers.method = 'DELETE';
            delete headers.body;
        }

        fetch(BASE_URL + _id, headers)
            .then(() => loadHandler())
            .catch(err => console.log(err));
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

attachEvents();

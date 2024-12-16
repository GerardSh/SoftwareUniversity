window.addEventListener("load", solve);

function solve() {
    const inputDOMSelectors = {
        form: document.querySelector('form'),
        genre: document.querySelector('#genre'),
        name: document.querySelector('#name'),
        author: document.querySelector('#author'),
        date: document.querySelector('#date'),
    }

    const otherDOMSelectors = {
        songsCollection: document.querySelector('#all-hits .all-hits-container'),
        songsSaved: document.querySelector('#saved-hits .saved-container'),
        likeCounter: document.querySelector('.likes p'),
        addBtn: document.querySelector('#add-btn'),
    }

    // Variables
    let likes = 1;

    // Adding Handlers
    otherDOMSelectors.addBtn.addEventListener('click', addHandler);

    // Add Handler
    function addHandler(e) {
        e.preventDefault();

        // Input Values
        const genre = inputDOMSelectors.genre.value;
        const name = inputDOMSelectors.name.value;
        const author = inputDOMSelectors.author.value;
        const date = inputDOMSelectors.date.value;

        if (!genre || !name || !author || !date) return;

        inputDOMSelectors.form.reset();

        const divEl = createEl('div', otherDOMSelectors.songsCollection, null, ['hits-info']);
        createEl('img', divEl, null, null, { src: "./static/img/img.png" });
        createEl('h2', divEl, `Genre: ${genre}`);
        createEl('h2', divEl, `Name: ${name}`);
        createEl('h2', divEl, `Author: ${author}`);
        createEl('h3', divEl, `Date: ${date}`);

        const saveBtn = createEl('button', divEl, 'Save song', ['save-btn']);
        const likeBtn = createEl('button', divEl, 'Like song', ['like-btn']);
        const delBtn = createEl('button', divEl, 'Delete', ['delete-btn']);

        saveBtn.addEventListener('click', saveHandler);
        likeBtn.addEventListener('click', likeHandler);
        delBtn.addEventListener('click', delHandler);

        // Save Handler
        function saveHandler(e) {
            e.preventDefault();

            otherDOMSelectors.songsSaved.appendChild(divEl);
            likeBtn.remove();
            saveBtn.remove();
        }

        // Like Handler
        function likeHandler(e) {
            e.preventDefault();

            likeBtn.disabled = true;
            otherDOMSelectors.likeCounter.textContent = `Total Likes: ${likes++}`;
        }

        // Delete Handler
        function delHandler(e) {
            e.preventDefault();

            divEl.remove();
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

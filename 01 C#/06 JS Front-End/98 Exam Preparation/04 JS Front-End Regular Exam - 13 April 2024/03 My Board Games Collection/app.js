const BASE_URL = 'http://localhost:3030/jsonstore/games';
const loadBtnEl = document.querySelector('button#load-games');
const gamesListEl = document.querySelector('div#games-list');
const addGameBtnEl = document.querySelector('#add-game');
const editGameBtnEl = document.querySelector('#edit-game');

const nameEl = document.querySelector('#g-name');
const typeEl = document.querySelector('#type');
const playersEl = document.querySelector('#players');

loadBtnEl.addEventListener('click', loadHandler);
addGameBtnEl.addEventListener('click', addGameHandler);
editGameBtnEl.addEventListener('click', editGameHandler);

let currentGameId = '';

loadHandler();

function loadHandler() {
    fetch(BASE_URL)
        .then(res => res.json())
        .then(res => {
            gamesListEl.textContent = '';
            editGameBtnEl.disabled = true;
            const games = Object.values(res);

            games.forEach(({ name, players, type, _id }) => {
                const divGameEl = createEl('div', undefined, undefined, ['board-game'], { _id }, gamesListEl);
                const divContentEl = createEl('div', undefined, undefined, ['content'], undefined, divGameEl);
                createEl('p', name, undefined, undefined, undefined, divContentEl);
                createEl('p', type, undefined, undefined, undefined, divContentEl);
                createEl('p', players, undefined, undefined, undefined, divContentEl);
                const buttonsDivEl = createEl('div', undefined, undefined, ['buttons-container'], undefined, divGameEl);
                const changeGameBtnEl = createEl('button', 'Change', undefined, ['change-btn'], undefined, buttonsDivEl);
                const deleteGameBtnEl = createEl('button', 'Delete', undefined, ['delete-btn'], undefined, buttonsDivEl);

                changeGameBtnEl.addEventListener('click', changeGameHandler);
                deleteGameBtnEl.addEventListener('click', deleteGameHandler);
            })
        })
        .catch(err => {
            console.log(err);
        })
}

function addGameHandler() {
    const name = nameEl.value;
    const type = typeEl.value;
    const players = playersEl.value;

    if (!name || !type || !players) {
        return;
    }

    document.querySelector('form').reset();

    fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            name,
            type,
            players
        })
    })
        .then(response => {
            gamesListEl.textContent = '';
            loadHandler();
        })
        .catch(err => console.log(err))
}

function changeGameHandler(e) {
    editGameBtnEl.disabled = false;
    addGameBtnEl.disabled = true;
    const parentEl = e.target.parentNode.parentNode;
    currentGameId = parentEl.getAttribute('_id');

    const [name, type, players] = parentEl.querySelectorAll('p');

    nameEl.value = name.textContent;
    typeEl.value = type.textContent;
    playersEl.value = players.textContent;
}

function editGameHandler() {
    fetch(`${BASE_URL}/${currentGameId}`, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify({
            name: nameEl.value,
            type: typeEl.value,
            players: playersEl.value,
            _id: currentGameId
        })
    })
        .then(response => {
            loadHandler();
            document.querySelector('form').reset();
            editGameBtnEl.disabled = true;
            addGameBtnEl.disabled = false;
        })
        .catch(err => console.log(err.message));
}

function deleteGameHandler(e) {
    const parentEl = e.target.parentNode.parentNode;
    const id = parentEl.getAttribute('_id');

    fetch(`${BASE_URL}/${id}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => loadHandler())
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

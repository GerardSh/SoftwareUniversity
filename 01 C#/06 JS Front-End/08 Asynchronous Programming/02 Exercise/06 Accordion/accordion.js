solution();

function solution() {
    window.addEventListener('load', initialLoadHandler);
}

function initialLoadHandler() {
    const BASE_URL = "http://localhost:3030/jsonstore/advanced/articles/";

    fetch(`${BASE_URL}list`)
        .then((res) => res.json())
        .then((response) => {
            const sectionMain = document.getElementById('main');

            for (const obj of response) {
                let divAccordion = createElement('div', undefined, undefined, ['accordion'], undefined, sectionMain);
                let divHead = createElement('div', undefined, undefined, ['head'], undefined, divAccordion);
                createElement('span', obj.title, undefined, undefined, undefined, divHead);
                let btn = createElement('button', 'More', obj._id, ['button'], undefined, divHead);
                btn.addEventListener('click', toggleInfoHandler);
                let divExtra = createElement('div', undefined, undefined, ['extra'], undefined, divAccordion);
                divExtra.style.display = 'none';
                createElement('p', undefined, undefined, undefined, undefined, divExtra);
            }
        })
        .catch((err) => {
            console.error(err);
        });
}

function toggleInfoHandler(e) {
    const BASE_URL = "http://localhost:3030/jsonstore/advanced/articles/";

    const btn = e.currentTarget;

    const parent = btn.parentElement.parentElement;
    const divExtra = Array.from(parent.getElementsByTagName('div'))[1];
    const paragraph = Array.from(parent.getElementsByTagName('p'))[0];

    if (btn.textContent === 'More') {
        fetch(`${BASE_URL}details/${btn.id}`)
            .then((res) => res.json())
            .then((response) => {
                divExtra.style.display = 'block';
                paragraph.textContent = response.content;
                btn.textContent = 'Less';
            })
            .catch((err) => {
                console.error(err);
            });
    } else {
        divExtra.style.display = 'none';
        btn.textContent = 'More';
    }
}

// Type = string
// Content = string
// Id = string
// Classes = array of strings
// Attributes = object
// Textarea - not implemented
function createElement(type, content, id, classes, attributes, parentNode) {
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

window.addEventListener("load", solve);

function solve() {
  // UL Elements
  const ulFirstEl = document.querySelector('#sure-list');
  const ulSecondEl = document.querySelector('#scoreboard-list');

  // Form Element
  const formEl = document.querySelector('form');

  const firstInputEl = document.querySelector('#player');
  const secondInputEl = document.querySelector('#score');
  const thirdInputEl = document.querySelector('#round');

  // Button Elements
  const addBtnEl = document.querySelector('#add-btn');

  // Adding Handlers
  addBtnEl.addEventListener('click', addHandler);
  document.querySelector('.btn.clear').addEventListener('click', () => {
    ulFirstEl.textContent = '';
    ulSecondEl.textContent = '';
    formEl.reset();
  });

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

    const liEl = createEl('li', ulFirstEl, undefined, ['dart-item']);
    const arEl = createEl('article', liEl);
    createEl('p', arEl, firstValue);
    createEl('p', arEl, `Score: ${secondValue}`);
    createEl('p', arEl, `Round: ${thirdValue}`);
    const btnEditEl = createEl('button', liEl, 'edit', ['btn', 'edit']);
    const btnDoneEl = createEl('button', liEl, 'ok', ['btn', 'ok']);

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

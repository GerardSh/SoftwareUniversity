window.addEventListener("load", solve);

function solve() {
  // UL Elements
  const ulFirstEl = document.querySelector('#preview-list');
  const ulSecondEl = document.querySelector('#candidates-list');

  // Form Element
  const formEl = document.querySelector('form');

  const firstInputEl = document.querySelector('#student');
  const secondInputEl = document.querySelector('#university');
  const thirdInputEl = document.querySelector('#score');

  // Button Elements
  const addBtnEl = document.querySelector('#next-btn');

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

    const liEl = createEl('li', ulFirstEl, undefined, ['application']);
    const arEl = createEl('article', liEl);
    createEl('h4', arEl, firstValue);
    createEl('p', arEl, `University: ${secondValue}`);
    createEl('p', arEl, `Score: ${thirdValue}`);
    const btnEditEl = createEl('button', liEl, 'edit', ['action-btn', 'edit']);
    const btnDoneEl = createEl('button', liEl, 'apply', ['action-btn', 'apply']);

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

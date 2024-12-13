window.addEventListener("load", solve);

function solve() {
  // UL Elements
  const ulFirstEl = document.querySelector('ul#adoption-info');
  const ulSecondEl = document.querySelector('ul#adopted-list');

  // Form Elements
  const formEl = document.querySelector('form');

  const firstInputEl = document.querySelector('input#type');
  const secondInputEl = document.querySelector('input#age');
  const thirdInputEl = document.querySelector('select#gender');

  // Button Elements
  const addBtnEl = document.querySelector('button#adopt-btn')

  // Adding Handler
  addBtnEl.addEventListener('click', addHandler)

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

    const liEl = createEl('li', undefined, undefined, undefined, undefined, ulFirstEl);
    const arEl = createEl('article', undefined, undefined, undefined, undefined, liEl);
    createEl('p', `Pet:${firstValue}`, undefined, undefined, undefined, arEl);
    createEl('p', `Gender:${thirdValue}`, undefined, undefined, undefined, arEl);
    createEl('p', `Age:${secondValue}`, undefined, undefined, undefined, arEl);
    const divBtnsEl = createEl('div', undefined, undefined, ['buttons'], undefined, liEl);
    const btnEditEl = createEl('button', 'Edit', undefined, ['edit-btn'], undefined, divBtnsEl);
    const btnDoneEl = createEl('button', 'Done', undefined, ['done-btn'], undefined, divBtnsEl);

    btnEditEl.addEventListener('click', editHandler);
    btnDoneEl.addEventListener('click', doneHandler)

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

      const btnDeleteEl = createEl('button', 'Clear', undefined, ['clear-btn'], undefined, undefined);

      liEl.appendChild(btnDeleteEl);

      btnDeleteEl.addEventListener('click', newBtnHandler);
    }

    // Delete Handler
    function newBtnHandler() {
      liEl.remove();
    }
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
}

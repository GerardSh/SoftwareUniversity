window.addEventListener("load", solve);

function solve() {
  const ulPreviewEl = document.querySelector('ul#preview-list');
  const ulArchiveEl = document.querySelector('ul#archive-list');
  const formEl = document.querySelector('form');
  const nameEl = document.querySelector('input#name');
  const timeEl = document.querySelector('input#time');
  const textareaEl = document.querySelector('textarea#description');
  const addBtnEl = document.querySelector('button#add-btn')

  addBtnEl.addEventListener('click', addHandler)

  function addHandler(e) {
    e.preventDefault();

    const text = textareaEl.value;
    const name = nameEl.value;
    const time = timeEl.value;

    if (!text || !name || !time) {
      return;
    }

    formEl.reset();
    addBtnEl.disabled = true;

    const liEl = createEl('li', undefined, undefined, undefined, undefined, ulPreviewEl);
    const arEl = createEl('article', undefined, undefined, undefined, undefined, liEl);
    createEl('p', name, undefined, undefined, undefined, arEl);
    createEl('p', time, undefined, undefined, undefined, arEl);
    createEl('p', text, undefined, undefined, undefined, arEl);
    const divBtnsEl = createEl('div', undefined, undefined, ['buttons'], undefined, liEl);
    const btnEditEl = createEl('button', 'Edit', undefined, ['edit-btn'], undefined, divBtnsEl);
    const btnNextEl = createEl('button', 'Next', undefined, ['next-btn'], undefined, divBtnsEl);

    btnEditEl.addEventListener('click', editHandler);
    btnNextEl.addEventListener('click', nextHandler)

    function editHandler() {
      textareaEl.value = text;
      nameEl.value = name;
      timeEl.value = time;

      addBtnEl.disabled = false;
      liEl.remove();
    }

    function nextHandler() {
      liEl.remove();
      ulArchiveEl.append(liEl);
      divBtnsEl.remove();

      const btnArchiveEl = createEl('button', 'Archive', undefined, ['archive-btn'], undefined, undefined);

      liEl.append(btnArchiveEl);

      btnArchiveEl.addEventListener('click', archiveHandler);
    }

    function archiveHandler() {
      liEl.remove();
      addBtnEl.disabled = false;
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

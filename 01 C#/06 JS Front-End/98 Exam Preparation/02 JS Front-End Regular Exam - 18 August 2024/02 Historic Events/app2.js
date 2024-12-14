window.addEventListener("load", solve);

function solve() {
  const inputDOMSelectors = {
    form: document.querySelector('form'),
    first: document.querySelector('#name'),
    second: document.querySelector('#time'),
    third: document.querySelector('#description')
  }

  const otherDOMSelectors = {
    firstList: document.querySelector('#preview-list'),
    secondList: document.querySelector('#archive-list'),
    addBtn: document.querySelector('#add-btn')
  }

  // Adding Handlers
  otherDOMSelectors.addBtn.addEventListener('click', addHandler);

  // Add Handler
  function addHandler(e) {
    e.preventDefault();

    // Input Values
    const firstValue = inputDOMSelectors.first.value;
    const secondValue = inputDOMSelectors.second.value;
    const thirdValue = inputDOMSelectors.third.value;

    if (!firstValue || !secondValue || !thirdValue) return;

    otherDOMSelectors.addBtn.disabled = true;
    inputDOMSelectors.form.reset();

    const liEl = createEl('li', otherDOMSelectors.firstList);
    const arEl = createEl('article', liEl);
    createEl('p', arEl, firstValue);
    createEl('p', arEl, secondValue);
    createEl('p', arEl, thirdValue);
    const divEl = createEl('div', liEl, null, ['buttons']);
    const editBtnEl = createEl('button', divEl, 'Edit', ['edit-btn']);
    const doneBtnEl = createEl('button', divEl, 'Next', ['next-btn']);

    editBtnEl.addEventListener('click', editHandler);
    doneBtnEl.addEventListener('click', doneHandler);

    // Edit Handler
    function editHandler() {
      otherDOMSelectors.addBtn.disabled = false;

      inputDOMSelectors.first.value = firstValue;
      inputDOMSelectors.second.value = secondValue;
      inputDOMSelectors.third.value = thirdValue;

      liEl.remove();
    }

    // Done Handler
    function doneHandler() {
      otherDOMSelectors.addBtn.disabled = false;

      otherDOMSelectors.secondList.append(liEl);

      const delBtnEl = createEl('button', liEl, 'Archive', ['archive-btn']);
      delBtnEl.addEventListener('click', delHandler);

      divEl.remove();
      editBtnEl.remove();
      doneBtnEl.remove();
    }

    function delHandler() {
      liEl.remove();
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

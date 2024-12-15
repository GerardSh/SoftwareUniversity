window.addEventListener("load", solve);

function solve() {
  const inputDOMSelectors = {
    form: document.querySelector('form'),
    first: document.querySelector('#email'),
    second: document.querySelector('#event'),
    third: document.querySelector('#location')
  }

  const otherDOMSelectors = {
    firstList: document.querySelector('#preview-list'),
    secondList: document.querySelector('#event-list'),
    addBtn: document.querySelector('#next-btn')
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

    const liEl = createEl('li', otherDOMSelectors.firstList, null, ['application']);
    const arEl = createEl('article', liEl);
    createEl('h4', arEl, firstValue);

    const pEl = createEl('p', arEl);
    createEl('strong', pEl, 'Event:');
    pEl.appendChild(document.createElement('br'));
    pEl.appendChild(document.createTextNode(secondValue));

    const p2El = createEl('p', arEl);
    createEl('strong', p2El, 'Location:');
    p2El.appendChild(document.createElement('br'));
    p2El.appendChild(document.createTextNode(thirdValue));

    const editBtnEl = createEl('button', liEl, 'edit', ['action-btn', 'edit']);
    const doneBtnEl = createEl('button', liEl, 'apply', ['action-btn', 'apply']);

    editBtnEl.addEventListener('click', editHandler);
    doneBtnEl.addEventListener('click', doneHandler);

    // Edit Handler
    function editHandler(e) {
      e.preventDefault();
      otherDOMSelectors.addBtn.disabled = false;

      inputDOMSelectors.first.value = firstValue;
      inputDOMSelectors.second.value = secondValue;
      inputDOMSelectors.third.value = thirdValue;

      liEl.remove();
    }

    // Done Handler
    function doneHandler(e) {
      e.preventDefault();
      otherDOMSelectors.addBtn.disabled = false;

      otherDOMSelectors.secondList.appendChild(liEl);

      editBtnEl.remove();
      doneBtnEl.remove();
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

// Created on: 15/12/2024 10:18:37

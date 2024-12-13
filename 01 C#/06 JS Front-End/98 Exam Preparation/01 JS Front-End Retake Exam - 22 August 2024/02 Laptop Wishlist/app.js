window.addEventListener("load", solve);

function solve() {
  const ulCheckListEl = document.querySelector('#check-list');
  const ulWishListEl = document.querySelector('#laptops-list');
  const addBtnEl = document.querySelector('#add-btn');
  const formEl = document.querySelector('form');
  const [modelEl, storageEl, priceEl] = document.querySelectorAll('form > input')
  const clearBtnEl = document.querySelector('button.clear.btn');

  addBtnEl.addEventListener('click', addHandler)
  clearBtnEl.addEventListener('click', clearHandler);

  function clearHandler() {
    ulCheckListEl.textContent = '';
    ulWishListEl.textContent = '';
  }

  function addHandler(e) {
    e.preventDefault();
    const model = modelEl.value;
    const storage = storageEl.value;
    const price = priceEl.value;

    if (!model || !storage || !price) {
      return;
    }

    formEl.reset();
    addBtnEl.disabled = true;

    const liEl = createEl('li', undefined, undefined, ['laptop-item'], undefined, ulCheckListEl);
    const arEl = createEl('article', undefined, undefined, undefined, undefined, liEl);
    createEl('p', model, undefined, undefined, undefined, arEl);
    createEl('p', `Memory: ${storage} TB`, undefined, undefined, undefined, arEl);
    createEl('p', `Price: ${price}$`, undefined, undefined, undefined, arEl);
    const btnEditEl = createEl('button', 'edit', undefined, ['btn', 'edit'], undefined, liEl);
    const btnOkEl = createEl('button', 'ok', undefined, ['btn', 'ok'], undefined, liEl);

    btnEditEl.addEventListener('click', editHandler);
    btnOkEl.addEventListener('click', okHandler)

    function editHandler() {
      modelEl.value = model;
      storageEl.value = storage;
      priceEl.value = price;

      addBtnEl.disabled = false;
      liEl.remove();
    }

    function okHandler() {
      liEl.remove();
      ulWishListEl.append(liEl);
      btnEditEl.remove();
      btnOkEl.remove();
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

window.addEventListener("load", solve);

function solve() {
  const nameEl = document.querySelector('#name');
  const phoneEl = document.querySelector('#phone');
  const categoryEl = document.querySelector('#category');
  const addBtnEl = document.querySelector('#add-btn');
  const ulEl = document.querySelector('#check-list');
  const selectEl = document.querySelector('select');
  const ulContactListEl = document.querySelector('#contact-list');

  addBtnEl.addEventListener('click', addContactHandler);

  function addContactHandler(e) {
    e.preventDefault();
    const selectedEl = categoryEl.querySelector(':checked');

    const name = nameEl.value;
    const phone = phoneEl.value;
    const validCategory = selectedEl.disabled;
    const category = selectedEl.value;


    if (!name || !phone || validCategory) {
      return;
    }

    nameEl.value = '';
    phoneEl.value = '';
    selectEl.value = '';

    const liEl = createEl('li', undefined, undefined, undefined, undefined, ulEl);
    const arEl = createEl('article', undefined, undefined, undefined, undefined, liEl);
    createEl('p', `name:${name}`, undefined, undefined, undefined, arEl);
    createEl('p', `phone:${phone}`, undefined, undefined, undefined, arEl);
    createEl('p', `category:${category}`, undefined, undefined, undefined, arEl);
    const divEl = createEl('div', undefined, undefined, ['buttons'], undefined, liEl);
    const editBtn = createEl('button', undefined, undefined, ['edit-btn'], undefined, divEl);
    const saveBtn = createEl('button', undefined, undefined, ['save-btn'], undefined, divEl);

    editBtn.addEventListener('click', (e) => editBtnHandler(e, name, phone, selectedEl));
    saveBtn.addEventListener('click', (e) => saveBtnHandler(e, name, phone, category));
  }

  function editBtnHandler(e, name, phone, category) {
    const parentLiEl = e.target.parentNode.parentNode;

    nameEl.value = name;
    phoneEl.value = phone;
    category.selected = true;

    parentLiEl.remove();
  }

  function saveBtnHandler(e, name, phone, category) {
    const parentLiEl = e.target.parentNode.parentNode;
    parentLiEl.remove();

    console.log(parentLiEl);

    const liEl = createEl('li', undefined, undefined, undefined, undefined, ulContactListEl);
    const arEl = createEl('article', undefined, undefined, undefined, undefined, liEl);
    createEl('p', `name:${name}`, undefined, undefined, undefined, arEl);
    createEl('p', `phone:${phone}`, undefined, undefined, undefined, arEl);
    createEl('p', `category:${category}`, undefined, undefined, undefined, arEl);
    const editBtn = createEl('button', undefined, undefined, ['del-btn'], undefined, liEl);
    editBtn.addEventListener('click', deleteHandler)
  }

  function deleteHandler(e) {
    e.target.parentNode.remove();
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

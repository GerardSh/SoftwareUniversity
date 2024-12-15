window.addEventListener("load", solve);

function solve() {
  const inputDOMSelectors = {
    form: document.querySelector('form'),
    firstName: document.querySelector('#first-name'),
    lastName: document.querySelector('#last-name'),
    age: document.querySelector('#age'),
    title: document.querySelector('#story-title'),
    genre: document.querySelector('#genre'),
    story: document.querySelector('#story')
  }

  const otherDOMSelectors = {
    list: document.querySelector('#preview-list'),
    addBtn: document.querySelector('#form-btn'),
    main: document.querySelector('#main')
  }

  // Adding Handlers
  otherDOMSelectors.addBtn.addEventListener('click', addHandler);

  // Add Handler
  function addHandler(e) {
    e.preventDefault();

    // Input Values
    const firstName = inputDOMSelectors.firstName.value;
    const lastName = inputDOMSelectors.lastName.value;
    const age = inputDOMSelectors.age.value;
    const title = inputDOMSelectors.title.value;
    const genre = inputDOMSelectors.genre.value;
    const story = inputDOMSelectors.story.value;

    if (!firstName || !lastName || !age || !title || !story) return;

    otherDOMSelectors.addBtn.disabled = true;
    inputDOMSelectors.form.reset();

    const liEl = createEl('li', otherDOMSelectors.list, null, ['story-info']);
    const arEl = createEl('article', liEl);
    createEl('h4', arEl, `Name: ${firstName} ${lastName}`);
    createEl('p', arEl, `Age: ${age}`);
    createEl('p', arEl, `Title: ${title}`);
    createEl('p', arEl, `Genre: ${genre}`);
    createEl('p', arEl, story);
    const saveBtn = createEl('button', liEl, 'Save Story', ['save-btn']);
    const editBtn = createEl('button', liEl, 'Edit Story', ['edit-btn']);
    const delBtn = createEl('button', liEl, 'Delete Story', ['delete-btn']);

    saveBtn.addEventListener('click', saveHandler);
    editBtn.addEventListener('click', editHandler);
    delBtn.addEventListener('click', delHandler);

    // Save Handler
    function saveHandler() {
      otherDOMSelectors.main.textContent = '';
      createEl('h1', otherDOMSelectors.main, 'Your scary story is saved!');
    }

    // Edit Handler
    function editHandler(e) {
      e.preventDefault();

      otherDOMSelectors.addBtn.disabled = false;

      inputDOMSelectors.firstName.value = firstName;
      inputDOMSelectors.lastName.value = lastName;
      inputDOMSelectors.age.value = age;
      inputDOMSelectors.title.value = title;
      inputDOMSelectors.story.value = story;

      liEl.remove();
    }

    // Done Handler
    function delHandler(e) {
      e.preventDefault();

      otherDOMSelectors.addBtn.disabled = false;
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

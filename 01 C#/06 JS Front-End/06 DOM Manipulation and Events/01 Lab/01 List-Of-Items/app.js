function addItem() {
    const listElement = document.querySelector('ul');
    const input = document.querySelector('input');
    const newLiElement = document.createElement('li');

    newLiElement.textContent = input.value;
    input.value = '';

    listElement.appendChild(newLiElement);
}

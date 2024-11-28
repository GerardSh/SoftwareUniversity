function addItem() {
    const listEl = document.getElementById('items');
    const input = document.querySelector('input[type="text"][id="newItemText"]');
    const liEl = document.createElement('li');
    const aEl = document.createElement('a');

    aEl.setAttribute('href', '#');
    aEl.textContent = '[Delete]'

    aEl.addEventListener('click', (e) => {
        e.target.parentElement.remove();
    })

    liEl.textContent = input.value;

    liEl.append(aEl);
    listEl.append(liEl);

    input.value = '';
}

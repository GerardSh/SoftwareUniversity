document.addEventListener('DOMContentLoaded', solve);

function solve() {
    document.querySelector('input[type="submit"').addEventListener('click', (e) => {
        e.preventDefault();

        const textInputEl = document.getElementById('newItemText');
        const valueInputEl = document.getElementById('newItemValue');
        const menuEl = document.getElementById('menu');

        const optionEl = document.createElement('option');
        optionEl.textContent = textInputEl.value;
        optionEl.value = valueInputEl.value;

        menuEl.append(optionEl);

        textInputEl.value = '';
        valueInputEl.value = '';

        textInputEl.focus();
    });
}

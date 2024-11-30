document.addEventListener('DOMContentLoaded', solve);

function solve() {
    document.querySelectorAll('button')
        .forEach(el => el.addEventListener('click', (e) => {
            const profileEl = e.target.parentElement;
            const activeRadioButton = profileEl.querySelector('input[type="radio"]:checked');
            const radioButtonId = activeRadioButton.id;
            const labelEl = profileEl.querySelector(`label[for = "${radioButtonId}"]`);

            if (labelEl.textContent == 'Lock') {
                return;
            }

            const hiddenFieldsEl = profileEl.querySelector('div.hidden-fields');

            if (hiddenFieldsEl.style.display == '') {
                hiddenFieldsEl.style.display = 'block';
            } else {
                hiddenFieldsEl.style.display = '';
            }

        }));
}

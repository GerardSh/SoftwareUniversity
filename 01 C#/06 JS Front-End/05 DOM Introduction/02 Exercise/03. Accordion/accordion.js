function toggle() {
    const buttonElement = document.getElementsByClassName('button')[0];
    const extraDivElement = document.getElementById('extra');

    if (buttonElement.textContent == 'More') {
        extraDivElement.style.display = 'block';
        buttonElement.textContent = 'Less';
    } else {
        extraDivElement.style.display = 'none';
        buttonElement.textContent = 'More';
    }
}

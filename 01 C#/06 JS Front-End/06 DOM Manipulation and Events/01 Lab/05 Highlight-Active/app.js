function focused() {
    inputEls = document.querySelectorAll('div input[type="text"]')
        .forEach(el => {
            el.addEventListener('focus', () => {
                el.parentElement.classList.add('focused');
            })

            el.addEventListener('blur', () => {
                el.parentElement.classList.remove('focused');
            })
        });
}

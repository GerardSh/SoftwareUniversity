function validate() {
    const inputEl = document.getElementById('email');

    inputEl.addEventListener('change', function (e) {
        const enteredEmail = this.value;
        const pattern = /^[^A-Z]+@[^A-Z]+\.[^A-Z]+$/

        if (!pattern.test(enteredEmail)) {
            this.classList.add('error');
        } else {
            this.classList.remove('error');
        }
    })
}

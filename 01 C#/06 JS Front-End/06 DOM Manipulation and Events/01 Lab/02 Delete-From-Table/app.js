function deleteByEmail() {
    const tableRowEls = document.querySelector('tbody').children;
    const inputEl = document.querySelector('input[name="email"]');
    const resultEl = document.querySelector('div[id="result"]');

    let removedEmail = '';

    for (let row of tableRowEls) {
        const emailAddressCell = row.children[1].textContent;
        const emailToDelete = inputEl.value;

        if (emailAddressCell === emailToDelete) {
            row.remove();
            removedEmail = emailAddressCell;
        }
    }

    if (removedEmail) {
        resultEl.textContent = 'Deleted.';
    } else {
        resultEl.textContent = 'Not found.'
    }

    inputEl.value = '';
}

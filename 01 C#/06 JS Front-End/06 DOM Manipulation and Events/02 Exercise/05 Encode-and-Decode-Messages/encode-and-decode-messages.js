document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const encodeButtonEl = document.querySelector('form#encode button');
    const decodeButtonEl = document.querySelector('form#decode button');

    encodeButtonEl.addEventListener('click', (e) => {
        e.preventDefault();

        const encodeTextAreaEl = document.querySelector('form#encode textarea');
        const inputMessage = encodeTextAreaEl.value;
        encodeTextAreaEl.value = '';

        let encryptedMessage = '';

        for (const char of inputMessage) {
            const AsciCodeNumber = char.charCodeAt(0) + 1;
            const symbol = String.fromCharCode(AsciCodeNumber);
            encryptedMessage += symbol;
        }

        const decodeTextAreaEl = document.querySelector('form#decode textarea');

        decodeTextAreaEl.textContent = encryptedMessage;
    })

    decodeButtonEl.addEventListener('click', (e) => {
        e.preventDefault();

        const decodeTextAreaEl = document.querySelector('form#decode textarea');
        const inputMessage = decodeTextAreaEl.value;

        let decryptedMessage = '';

        for (const char of inputMessage) {
            const AsciCodeNumber = char.charCodeAt(0) - 1;
            const symbol = String.fromCharCode(AsciCodeNumber);
            decryptedMessage += symbol;
        }

        decodeTextAreaEl.textContent = decryptedMessage;
    })
}

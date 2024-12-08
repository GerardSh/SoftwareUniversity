function attachEvents() {
    const BASE_URL = 'http://localhost:3030/jsonstore/messenger';
    const sendBtnEl = document.querySelector('input[value="Send"');
    const rshBtnEl = document.querySelector('input[value="Refresh"');
    const textAreaEl = document.querySelector('textarea');
    const nameInputEl = document.querySelector('input[name="author"]')
    const msgInputEl = document.querySelector('input[name="content"]')

    sendBtnEl.addEventListener('click', sendHandler);
    rshBtnEl.addEventListener('click', refreshHandler);

    function sendHandler() {
        const author = nameInputEl.value;
        const content = msgInputEl.value;

        nameInputEl.value = '';
        msgInputEl.value = '';

        fetch(BASE_URL, {
            method: 'POST',
            headers: {
                'Content-type': 'application/json',
            },
            body: JSON.stringify({ author, content })
        })
            .catch((err) => {
                console.error(err);
            });
    }

    function refreshHandler() {
        fetch(BASE_URL)
            .then(res => res.json())
            .then(res => {
                const messages = Object.values(res)
                    .map(obj => `${obj.author}: ${obj.content}`)

                textAreaEl.textContent = messages.join('\n');
            })
            .catch((err) => {
                console.error(err);
            });
    }
}

attachEvents();

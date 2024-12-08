function attachEvents() {
    BASE_URL = 'http://localhost:3030/jsonstore/phonebook';
    const phonebookEl = document.querySelector('#phonebook');
    const loadButtonEl = document.querySelector('#btnLoad');
    const createButtonEl = document.querySelector('#btnCreate');
    const [personInputEl, phoneInputEl] = document.querySelectorAll('input');

    loadButtonEl.addEventListener('click', loadContactsHandler);
    createButtonEl.addEventListener('click', createContactHandler);

    function loadContactsHandler() {
        fetch(BASE_URL)
            .then(res => res.json())
            .then(res => {
                const posts = Object.values(res);
                phonebookEl.textContent = '';

                posts.forEach(contact => {
                    const { person, phone, _id } = contact;
                    const liEl = document.createElement('li');
                    liEl.textContent = `${person}: ${phone}`;

                    const deleteButtonEl = document.createElement("button");
                    deleteButtonEl.textContent = 'Delete';
                    deleteButtonEl.addEventListener('click', () =>
                        deleteContact(contact)
                    );

                    liEl.append(deleteButtonEl);
                    phonebookEl.append(liEl);
                })
            })
            .catch(err => {
                console.log(err);
            })
    }

    function createContactHandler() {
        const { value: person } = personInputEl;
        const { value: phone } = phoneInputEl;

        personInputEl.value = '';
        phoneInputEl.value = '';

        const options = {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                person,
                phone,
            })
        };

        fetch(BASE_URL, options)
            .then(res => res.json())
            .then(res => {
                loadContactsHandler();
            })
            .catch(err =>
                console.log(err)
            )
    }

    function deleteContact(contact) {
        const options = {
            method: 'DELETE',
            headers: {
                "Content-Type": "application/json"
            }
        }

        fetch(`${BASE_URL}/${contact._id}`, options)
            .then(res => res.json())
            .then(res => {
                loadContactsHandler();
            })
            .catch(err =>
                console.log(err)
            )
    }
}

attachEvents();

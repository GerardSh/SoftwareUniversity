const baseUrl = 'http://localhost:3030/jsonstore/collections/books';

const loadButton = document.getElementById('loadBooks');
const bookListElement = document.querySelector('table tbody');
const formElement = document.getElementById('form');
const formSubmit = formElement.querySelector('button:last-of-type');
const titleInput = formElement.querySelector('input[name=title]');
const authorInput = formElement.querySelector('input[name=author]');

loadButton.addEventListener('click', fetchBooks);

formSubmit.addEventListener('click', (e) => {
    e.preventDefault();

    const bookId = formElement.getAttribute('data-edit-id');

    const bookData = {
        _id: bookId,
        title: titleInput.value,
        author: authorInput.value,
    }

    // Send data to the server api
    fetch(`${baseUrl}/${bookId ? bookId : ''}`, {
        method: bookId ? 'PUT' : 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(bookData),
    })
        .then(response => response.json())
        .then(result => {
            // clear inputs
            titleInput.value = '';
            authorInput.value = '';

            // refetch books
            fetchBooks();
        })
        .finally(() => {
            formElement.removeAttribute('data-edit-id');
        });
});

function fetchBooks() {
    fetch(baseUrl)
        .then(response => response.json())
        .then(result => {
            // clear book list
            bookListElement.innerHTML = '';

            const books = Object.values(result)
            const bookElements = books.map(createBookElement);
            bookListElement.append(...bookElements);
        });
}

function createBookElement(book) {
    const nameTdElement = document.createElement('td');
    nameTdElement.textContent = book.title;

    const authorTdElement = document.createElement('td');
    authorTdElement.textContent = book.author;

    const editButtonElement = document.createElement('button');
    editButtonElement.textContent = 'Edit';

    const deleteButtonElement = document.createElement('button');
    deleteButtonElement.textContent = 'Delete';

    const buttonsTdElement = document.createElement('td');
    buttonsTdElement.appendChild(editButtonElement);
    buttonsTdElement.appendChild(deleteButtonElement);

    const trElement = document.createElement('tr');
    trElement.appendChild(nameTdElement);
    trElement.appendChild(authorTdElement);
    trElement.appendChild(buttonsTdElement);

    // add delete button handler
    deleteButtonElement.addEventListener('click', async () => {
        // Delete request
        const response = await fetch(`${baseUrl}/${book._id}`, {
            method: 'DELETE',
        });

        // TODO: Error handling

        // Delete element from list
        trElement.remove();
    });

    // Add edit button handler
    editButtonElement.addEventListener('click', () => {
        titleInput.value = book.title;
        authorInput.value = book.author;

        formElement.setAttribute('data-edit-id', book._id);

        trElement.remove();        
    });

    return trElement;
}

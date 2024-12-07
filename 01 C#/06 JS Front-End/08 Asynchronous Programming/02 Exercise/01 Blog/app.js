function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/blog/';
    const buttonLoadPostsEl = document.querySelector('#btnLoadPosts');
    const buttonViewPostsEl = document.querySelector('#btnViewPost');
    const selectEl = document.querySelector('#posts');
    const h1PostTitleEl = document.querySelector('#post-title');
    const ulPostCommentsEl = document.querySelector('#post-comments');
    const pPostBodyEL = document.querySelector('#post-body');

    buttonLoadPostsEl.addEventListener('click', loadHandler);
    buttonViewPostsEl.addEventListener('click', viewHandler);

    function loadHandler() {
        fetch(`${baseUrl}/posts`)
            .then(response => response.json())
            .then(result => {

                for (let key in result) {
                    const optionEl = document.createElement('option');
                    optionEl.value = key;
                    optionEl.textContent = result[key].title;
                    optionEl.customBody = result[key].body;
                    selectEl.append(optionEl);
                }
            })
            .catch(err => {
                console.log(err.message);
            })
    }

    function viewHandler() {
        fetch(`${baseUrl}/comments`)
            .then(response => response.json())
            .then(result => {
                const selectedOptionEl = selectEl.querySelector(':checked');
                const selectedOptionId = selectedOptionEl.value;
                const selectedOptionTitle = selectedOptionEl.textContent.toUpperCase();

                pPostBodyEL.textContent = selectedOptionEl.customBody;

                h1PostTitleEl.textContent = selectedOptionTitle;

                for (let key in result) {
                    if (result[key].postId == selectedOptionId) {
                        const commentText = result[key].text;

                        const newLiEl = document.createElement('li');
                        newLiEl.textContent = commentText;

                    }
                }
            })
            .catch(err => {
                console.log(err.message);
            })
    }
}

attachEvents();

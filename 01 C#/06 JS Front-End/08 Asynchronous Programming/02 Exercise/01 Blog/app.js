function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/blog/';
    const buttonLoadPostsEl = document.querySelector('#btnLoadPosts');
    const buttonViewPostsEl = document.querySelector('#btnViewPost');
    const selectEl = document.querySelector('#posts');
    const titleEl = document.querySelector('#post-title');
    const ulCommentsEl = document.querySelector('#post-comments');
    const pPostBodyEL = document.querySelector('#post-body');
    const commentsTitleEl = document.querySelector('h2');

    buttonLoadPostsEl.addEventListener('click', loadHandler);
    buttonViewPostsEl.addEventListener('click', viewHandler);

    function loadHandler() {
        clearDynamicData();

        fetch(`${baseUrl}posts`)
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
        titleEl.style.display = 'block';
        commentsTitleEl.style.display = 'block';
        ulCommentsEl.textContent = '';

        fetch(`${baseUrl}comments`)
            .then(response => response.json())
            .then(result => {
                debugger;
                const selectedOptionEl = selectEl.querySelector(':checked');
                const selectedOptionId = selectedOptionEl.value;
                const selectedOptionTitle = selectedOptionEl.textContent;

                pPostBodyEL.textContent = selectedOptionEl.customBody;

                titleEl.textContent = selectedOptionTitle;

                for (let key in result) {
                    if (result[key].postId == selectedOptionId) {
                        const commentText = result[key].text;
                        const newLiEl = document.createElement('li');
                        newLiEl.textContent = commentText;
                        ulCommentsEl.append(newLiEl);
                    }
                }
            })
            .catch(err => {
                console.log(err.message);
            })
    }

    function clearDynamicData() {
        titleEl.textContent = '';
        pPostBodyEL.textContent = '';
        ulCommentsEl.textContent = '';
        selectEl.textContent = '';
        titleEl.style.display = 'none';
        commentsTitleEl.style.display = 'none';
    }
}

attachEvents();

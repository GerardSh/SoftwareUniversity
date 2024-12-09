function lockedProfile() {
    BASE_URL = 'http://localhost:3030/jsonstore/advanced/profiles';
    const profileStructureEl = document.querySelector('.profile');
    const mainEl = document.querySelector('#main');
    profileStructureEl.remove();

    function loadingProfiles() {
        fetch(BASE_URL)
            .then(res => res.json())
            .then(res => {
                const profiles = Object.values(res);
                profileStructureEl.remove();
                profiles.forEach(({ username, email, age, _id }) => {
                    const profileCloneEl = profileStructureEl.cloneNode(true);
                    profileCloneEl.querySelector('input[name="user1Username"').value = username;
                    profileCloneEl.querySelector('input[name="user1Email').value = email;
                    profileCloneEl.querySelector('input[name="user1Age"]').value = age;
                    profileCloneEl.querySelector('input[value="lock"]').checked = true;
                    profileCloneEl.querySelector('input[value="lock"]').setAttribute('name', 'lock' + _id);
                    profileCloneEl.querySelector('input[value="unlock"]').setAttribute('name', 'lock' + _id);
                    profileCloneEl.querySelector('div.user1Username').style.display = "none";
                    profileCloneEl.querySelector('button').addEventListener('click', btnHandler);

                    mainEl.append(profileCloneEl);
                });
            })
            .catch(err => {
                console.log(err);
            })
    }

    loadingProfiles();


    function btnHandler(e) {
        const btnEl = e.target;
        const parentEl = btnEl.parentElement;
        const userDetailsEl = parentEl.querySelector('div.user1Username');
        const checkedRadioBtn = parentEl.querySelector(':checked');


        if (checkedRadioBtn.value === 'unlock') {
            if (btnEl.textContent === 'Show more') {
                btnEl.textContent = 'Hide it';
                userDetailsEl.style.display = 'block';
            } else {
                btnEl.textContent = 'Show more';
                userDetailsEl.style.display = 'none';
            }

        }
    }
}



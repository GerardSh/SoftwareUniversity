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
                profiles.forEach(({ username, email, age, _id }, index) => {
                    const profileCloneEl = profileStructureEl.cloneNode(true);
                    profileCloneEl.innerHTML = profileCloneEl.innerHTML.replace(/user1/g, `user${index + 1}`);

                    profileCloneEl.querySelector(`input[name="user${index + 1}Username"]`).value = username;
                    profileCloneEl.querySelector(`input[name="user${index + 1}Email"]`).value = email;
                    profileCloneEl.querySelector(`input[name="user${index + 1}Age"]`).value = age;
                    profileCloneEl.querySelector('input[value="lock"]').checked = true;
                    profileCloneEl.querySelector('input[value="lock"]').setAttribute('name', _id);
                    profileCloneEl.querySelector('input[value="unlock"]').setAttribute('name', _id);

                    profileCloneEl.querySelector(`div.user${index + 1}Username`).style.display = "none";
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

        const userDetailsEl = parentEl.querySelector('div > div');
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

function lockedProfile() {
    BASE_URL = 'http://localhost:3030/jsonstore/advanced/profiles';
    const profileStructureEl = document.querySelector('.profile');;
    profileStructureEl.remove();

    function loadingProfiles() {
        fetch(BASE_URL)
            .then(res => res.json())
            .then(res => {
                const profiles = Object.values(res);

                profiles.forEach(({ username, email, age, _id }, i) => {
                    let divProfile = createElement('div', undefined, undefined, ['profile'], undefined, main);
                    createElement('img', undefined, undefined, ['userIcon'], { src: './iconProfile2.png' }, divProfile);
                    createElement('label', 'Lock', undefined, undefined, undefined, divProfile);
                    createElement('input', undefined, undefined, undefined, { type: 'radio', name: `user${i + 1}Locked`, value: 'lock', checked: true }, divProfile);
                    createElement('label', 'Unlock', undefined, undefined, undefined, divProfile);
                    createElement('input', undefined, undefined, undefined, { type: 'radio', name: `user${i + 1}Locked`, value: 'unlock' }, divProfile);
                    createElement('br', undefined, undefined, undefined, undefined, divProfile);
                    createElement('hr', undefined, undefined, undefined, undefined, divProfile);
                    createElement('label', 'Username', undefined, undefined, undefined, divProfile);
                    createElement('input', undefined, undefined, undefined, { type: 'text', name: `user${i + 1}Username`, value: username, disabled: true, readonly: true }, divProfile);
                    let divHidden = createElement('div', undefined, `user${i}Username`, undefined, undefined, divProfile);
                    divHidden.style.display = 'none';
                    createElement('hr', undefined, undefined, undefined, undefined, divHidden);
                    createElement('label', 'Email:', undefined, undefined, undefined, divHidden);
                    createElement('input', undefined, undefined, undefined, { type: 'email', name: `user${i + 1}Email`, value: email, disabled: true, readonly: true }, divHidden);
                    createElement('label', 'Age:', undefined, undefined, undefined, divHidden);
                    createElement('input', undefined, undefined, undefined, { type: 'number', name: `user${i + 1}Age`, value: age, disabled: true, readonly: true }, divHidden);
                    let btnShow = createElement('button', 'Show more', undefined, undefined, undefined, divProfile);

                    btnShow.addEventListener('click', btnHandler);

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
        const username = parentEl.querySelector('input[type="text"]').name;

        const userDetailsEl = parentEl.querySelector(`div.${username}HiddenFields`);

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

// Type = string
// Content = string
// Id = string
// Classes = array of strings
// Attributes = object
// Textarea - not implemented 
function createElement(type, content, id, classes, attributes, parentNode) {
    const htmlElement = document.createElement(type);

    if (content && type !== 'input') {
        htmlElement.textContent = content;
    }

    if (content && type === 'input') {
        htmlElement.value = content;
    }

    if (id) {
        htmlElement.id = id;
    }

    if (classes) {
        htmlElement.classList.add(...classes);
    }

    if (attributes) {
        for (const key in attributes) {
            htmlElement.setAttribute(key, attributes[key]);
        }
    }

    if (parentNode) {
        parentNode.appendChild(htmlElement);
    }

    return htmlElement;
}

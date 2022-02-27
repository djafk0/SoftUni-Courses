async function lockedProfile() {
    document.querySelector('button').addEventListener('click', show);

    const url = `http://localhost:3030/jsonstore/advanced/profiles`;

    const res = await fetch(url);
    const data = await res.json();

    let counter = 1;

    let main = document.getElementById('main');

    Object.entries(data).forEach(x => {
        let img = document.createElement('img');
        img.classList = 'userIcon';
        img.src = './iconProfile2.png';

        let labelLock = createWithTextContent('label', 'Lock')

        let inputLock = document.createElement('input');
        inputLock = lock(inputLock, ['radio', `user${counter}Locked`, 'lock']);
        inputLock.checked = true;

        let labelUnlock = createWithTextContent('label', 'Unlock');

        let inputUnlock = document.createElement('input');
        inputUnlock = lock(inputUnlock, ['radio', `user${counter}Locked`, 'unlock'])

        let br = document.createElement('br');

        let hrProfile = document.createElement('hr');

        let labelUsername = createWithTextContent('label', 'Username');

        let inputUsername = createHiddenItems('input', ['text', `user${counter}Username`, `${x[1].username}`, true, true]);

        let hrInfo = document.createElement('hr');

        let labelEmail = createWithTextContent('label', 'Email:');

        let inputEmail = createHiddenItems('input', ['email', `user${counter}Email`, `${x[1].email}`, true, true]);

        let labelAge = createWithTextContent('label', 'Age:');

        let inputAge = createHiddenItems('input', ['email', `user${counter}Age`, `${x[1].age}`, true, true]);

        let divInfo = createDivAndInsert('hiddenInfo', [hrInfo, labelEmail, inputEmail, labelAge, inputAge]);
        divInfo.id = `user${counter}HiddenFields`;

        let btn = createWithTextContent('button', 'Show more');
        btn.addEventListener('click', show);

        let divProfile = createDivAndInsert('profile', [img, labelLock, inputLock, labelUnlock, inputUnlock, br, hrProfile, labelUsername, inputUsername, divInfo, btn]);

        main.appendChild(divProfile);

        counter++;
    })

    document.querySelector('div.profile').remove();

    function show(e) {
        let inputs = e.target.parentElement.querySelectorAll('div.hiddenInfo input');
        let labels = e.target.parentElement.querySelectorAll('div.hiddenInfo label');

        if (e.target.parentElement.querySelector('input').checked) {
            return;
        }

        if (e.target.textContent == 'Show more') {
            e.target.textContent = 'Show less'

            inputs.forEach(x => x.style.display = 'inline-block');
            labels.forEach(x => x.style.display = 'inline-block');
        } else {
            e.target.textContent = 'Show more';

            inputs.forEach(x => x.style.display = 'none');
            labels.forEach(x => x.style.display = 'none');
        }
    }

    function createWithTextContent(element, text){
        let domEl = document.createElement(element);
        domEl.textContent = text;

        return domEl;
    }

    function lock(input, arr){
        input.type = arr[0];
        input.name = arr[1];
        input.value = arr[2];

        return input;
    }

    function createHiddenItems(type, arr) {
        let element = document.createElement(type);

        element.type = arr[0];
        element.name = arr[1];
        element.value = arr[2];
        element.disabled = arr[3];
        element.readOnly = arr[4];

        return element;
    }

    function createDivAndInsert(classlist, arr) {
        let domEl = document.createElement('div');
        domEl.classList = classlist;

        for (const item of arr) {
            domEl.appendChild(item);
        }

        return domEl;
    }
}
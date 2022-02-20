window.addEventListener('load', solve);

function solve() {
    document.querySelector('button[type="submit"]').addEventListener('click', (e) => {
        e.preventDefault();
        
        document.querySelector('.clear-btn').addEventListener('click', clear);
        
        const type = document.getElementById('type-product');
        const description = document.getElementById('description');
        const name = document.getElementById('client-name');
        const phone = document.getElementById('client-phone');

        if (isEmptyOrSpaces(description.value) ||
            isEmptyOrSpaces(name.value) ||
            isEmptyOrSpaces(phone.value)) {
            return;
        }

        let div = document.createElement('div');
        div.classList.add('container');

        let h2 = document.createElement('h2');
        h2.textContent = `Product type for repair: ${type.value}`;

        let h3 = document.createElement('h3');
        h3.textContent = `Client information: ${name.value}, ${phone.value}`;

        let h4 = document.createElement('h4');
        h4.textContent = `Description of the problem: ${description.value}`;

        let startBtn = document.createElement('button');
        startBtn.classList.add('start-btn');
        startBtn.textContent = 'Start repair';
        startBtn.addEventListener('click', start);

        let finishBtn = document.createElement('button');
        finishBtn.classList.add('finish-btn');
        finishBtn.textContent = 'Finish repair';
        finishBtn.disabled = true;
        finishBtn.addEventListener('click', finish);

        div.appendChild(h2);
        div.appendChild(h3);
        div.appendChild(h4);
        div.appendChild(startBtn);
        div.appendChild(finishBtn);

        document.getElementById('received-orders').appendChild(div);

        description.value = '';
        phone.value = '';
        name.value = '';
    })

    function start(e) {
        e.target.parentElement.querySelector('.finish-btn').disabled = false;
        e.target.disabled = true;
    }

    function finish(e) {
        document.getElementById('completed-orders').appendChild(e.target.parentElement)
        
        e.target.parentElement.querySelector('.start-btn').remove();
        e.target.parentElement.querySelector('.finish-btn').remove();
    }

    function clear(e) {
        let arr = Array.from(e.target.parentElement.querySelectorAll('div'));
        arr.forEach(x => x.remove());
    }

    function isEmptyOrSpaces(str) {
        return str === null || str.match(/^ *$/) !== null;
    }
}
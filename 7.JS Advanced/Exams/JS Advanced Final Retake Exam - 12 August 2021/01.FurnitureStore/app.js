window.addEventListener('load', solve);

function solve() {
    document.getElementById('add').addEventListener('click', (e) => {
        e.preventDefault();

        const model = document.getElementById('model');
        const year = document.getElementById('year');
        const description = document.getElementById('description');
        const price = document.getElementById('price');

        const furnitureList = document.getElementById('furniture-list');

        if (isEmptyOrSpaces(model.value) ||
            isEmptyOrSpaces(description.value) ||
            Number(year.value) <= 0 ||
            Number(price.value) <= 0) {
            return;
        }

        let trInfo = document.createElement('tr');
        trInfo.classList.add('info');

        let tdModel = document.createElement('td');
        tdModel.textContent = model.value;

        let tdPrice = document.createElement('td');
        tdPrice.textContent = (Number(price.value)).toFixed(2);

        let tdButtons = document.createElement('td');

        let moreBtn = document.createElement('button');
        moreBtn.classList.add('moreBtn');
        moreBtn.textContent = 'More Info';
        moreBtn.addEventListener('click', more);

        let buyBtn = document.createElement('button');
        buyBtn.classList.add('buyBtn');
        buyBtn.textContent = 'Buy it';
        buyBtn.addEventListener('click', buy);

        tdButtons.appendChild(moreBtn);
        tdButtons.appendChild(buyBtn);

        trInfo.appendChild(tdModel);
        trInfo.appendChild(tdPrice);
        trInfo.appendChild(tdButtons);

        let trHide = document.createElement('tr');
        trHide.classList.add('hide');

        let tdYear = document.createElement('td');
        tdYear.textContent = `Year: ${year.value}`

        let tdDescription = document.createElement('td');
        tdDescription.colSpan = 3;
        tdDescription.textContent = `Description: ${description.value}`

        trHide.appendChild(tdYear);
        trHide.appendChild(tdDescription);

        furnitureList.appendChild(trInfo);
        furnitureList.appendChild(trHide);
    })

    function more(e) {
        let hide = document.querySelector('.hide');

        if (e.target.textContent == 'More Info'){
            e.target.textContent = 'Less Info';
            hide.style.display = 'contents';
        } else {
            e.target.textContent = 'More Info';
            hide.style.display = 'none';
        }
    }

    function buy(e) {
        let totalPriceElement = document.querySelector('.total-price');

        let totalPrice = Number(totalPriceElement.textContent);
        totalPrice += Number(e.target.parentElement.parentElement.querySelectorAll('td')[1].textContent);
       
        totalPriceElement.textContent = totalPrice.toFixed(2);

        let arr = Array.from(e.target.parentElement.parentElement.querySelectorAll('td'));
        arr.forEach(x => x.remove());
    }

    function isEmptyOrSpaces(str) {
        return str === null || str.match(/^ *$/) !== null;
    }
}

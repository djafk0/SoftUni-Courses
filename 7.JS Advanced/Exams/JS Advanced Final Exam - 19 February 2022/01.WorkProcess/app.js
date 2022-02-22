function solve() {
    document.getElementById('add-worker').addEventListener('click', (e) => {
        e.preventDefault();

        const firstName = document.getElementById('fname');
        const lastName = document.getElementById('lname');
        const email = document.getElementById('email');
        const birth = document.getElementById('birth');
        const position = document.getElementById('position');
        const salary = document.getElementById('salary');

        if (isEmptyOrSpaces(firstName.value) == null ||
            isEmptyOrSpaces(lastName.value) ||
            isEmptyOrSpaces(email.value) ||
            isEmptyOrSpaces(birth.value) ||
            isEmptyOrSpaces(position.value) ||
            isEmptyOrSpaces(salary.value)) {
            return;
        }

        let tr = document.createElement('tr');

        let tdFirstName = document.createElement('td');
        tdFirstName.textContent = firstName.value;

        let tdLastName = document.createElement('td');
        tdLastName.textContent = lastName.value;

        let tdEmail = document.createElement('td');
        tdEmail.textContent = email.value;

        let tdBirth = document.createElement('td');
        tdBirth.textContent = birth.value;

        let tdPosition = document.createElement('td');
        tdPosition.textContent = position.value;

        let tdSalary = document.createElement('td');
        tdSalary.textContent = salary.value;

        let tdButton = document.createElement('td');

        let firedButton = document.createElement('button');
        firedButton.classList.add('fired');
        firedButton.textContent = 'Fired';
        firedButton.addEventListener('click', fire);

        let editButton = document.createElement('button');
        editButton.classList.add('edit');
        editButton.textContent = 'Edit';
        editButton.addEventListener('click', edit);

        tdButton.appendChild(firedButton);
        tdButton.appendChild(editButton);

        tr.appendChild(tdFirstName);
        tr.appendChild(tdLastName);
        tr.appendChild(tdEmail);
        tr.appendChild(tdBirth);
        tr.appendChild(tdPosition);
        tr.appendChild(tdSalary);
        tr.appendChild(tdButton);

        document.getElementById('tbody').appendChild(tr);

        let sumText = document.getElementById('sum');
        let sum = Number(sumText.textContent);
        sum += Number(salary.value);
        sumText.textContent = sum.toFixed(2);

        firstName.value = '';
        lastName.value = '';
        email.value = '';
        birth.value = '';
        position.value = '';
        salary.value = '';

        function fire(e) {
            let tr = e.target.parentElement.parentElement;

            let salary = tr.querySelectorAll('td')[5];

            sum = Number(sumText.textContent);
            sum -= Number(salary.textContent);
            sumText.textContent = sum.toFixed(2);

            tr.remove();
        }

        function edit(e) {
            let tr = e.target.parentElement.parentElement;
            let arr = Array.from(tr.querySelectorAll('td'));

            firstName.value = arr[0].textContent;
            lastName.value = arr[1].textContent;
            email.value = arr[2].textContent;
            birth.value = arr[3].textContent;
            position.value = arr[4].textContent;
            salary.value = arr[5].textContent;

            sum = Number(sumText.textContent);
            sum -= Number(salary.value);
            sumText.textContent = sum.toFixed(2);

            tr.remove();
        }
    })

    function isEmptyOrSpaces(str) {
        return str === null || str.match(/^ *$/) !== null;
    }
}

solve()

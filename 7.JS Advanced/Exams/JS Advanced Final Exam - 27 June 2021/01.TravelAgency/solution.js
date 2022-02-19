window.addEventListener('load', solution);

function solution() {
  document.getElementById('submitBTN').addEventListener('click', (e) => {
    const name = document.getElementById('fname');
    const email = document.getElementById('email');
    const phone = document.getElementById('phone');
    const address = document.getElementById('address');
    const code = document.getElementById('code');

    if (isEmptyOrSpaces(name.value) || isEmptyOrSpaces(email.value)) {
      return;
    }

    const editButton = document.querySelector('input[value="Edit"]');
    const continueButton = document.querySelector('input[value="Continue"]');

    let ul = document.getElementById('infoPreview');

    let liName = document.createElement('li');
    liName.textContent = `Full Name: ${name.value}`;

    let liEmail = document.createElement('li');
    liEmail.textContent = `Email: ${email.value}`;

    let liPhone = document.createElement('li');
    liPhone.textContent = `Phone Number: ${phone.value}`;

    let liAddress = document.createElement('li');
    liAddress.textContent = `Address: ${address.value}`;

    let liCode = document.createElement('li');
    liCode.textContent = `Postal Code: ${code.value}`;

    ul.appendChild(liName);
    ul.appendChild(liEmail);
    ul.appendChild(liPhone);
    ul.appendChild(liAddress);
    ul.appendChild(liCode);

    let savedName = name.value;
    let savedEmail = email.value;
    let savedPhone = phone.value;
    let savedAddress = address.value;
    let savedCode = code.value;

    name.value = '';
    email.value = '';
    phone.value = '';
    address.value = '';
    code.value = '';

    editButton.disabled = false;
    continueButton.disabled = false;

    let submitButton = e.target;
    submitButton.disabled = true;

    editButton.addEventListener('click', (е) => {
      name.value = savedName;
      email.value = savedEmail;
      phone.value = savedPhone;
      address.value = savedAddress;
      code.value = savedCode;

      let liItems = Array.from(document.querySelectorAll('#infoPreview li'));
      liItems.forEach(x => x.remove());

      editButton.disabled = true;
      continueButton.disabled = true;
      submitButton.disabled = false;
    })

    document.getElementById('continueBTN').addEventListener('click', () => {
      let div = document.createElement('div');
      div.id = 'block';

      let h3 = document.createElement('h3');
      h3.textContent = 'Thank you for your reservation!';

      div.appendChild(h3);

      document.getElementById('block').remove();
      document.querySelector('body').appendChild(div);
    })
  })

  function isEmptyOrSpaces(str) {
    return str === null || str.match(/^ *$/) !== null;
  }
}

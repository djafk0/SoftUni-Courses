window.addEventListener('load', solve);

function solve() {
    document.getElementById('add-btn').addEventListener('click', (e) => {
        e.preventDefault();

        const genre = document.getElementById('genre');
        const name = document.getElementById('name');
        const author = document.getElementById('author');
        const date = document.getElementById('date');

        const divAllHits = document.querySelector('.all-hits-container');

        if (isEmptyOrSpaces(genre.value) == null ||
            isEmptyOrSpaces(name.value) ||
            isEmptyOrSpaces(author.value) ||
            isEmptyOrSpaces(date.value)) {
            return;
        }

        let div = document.createElement('div');
        div.classList.add('hits-info');

        let img = document.createElement('img');
        img.src = './static/img/img.png';

        let genreHeading = document.createElement('h2');
        genreHeading.textContent = `Genre: ${genre.value}`;

        let nameHeading = document.createElement('h2');
        nameHeading.textContent = `Name: ${name.value}`;

        let authorHeading = document.createElement('h2');
        authorHeading.textContent = `Author: ${author.value}`;

        let dateHeading = document.createElement('h3');
        dateHeading.textContent = `Date: ${date.value}`;

        let saveBtn = document.createElement('button');
        saveBtn.classList.add('save-btn');
        saveBtn.textContent = 'Save song';
        saveBtn.addEventListener('click', save);

        let likeBtn = document.createElement('button');
        likeBtn.classList.add('like-btn');
        likeBtn.textContent = 'Like song';
        likeBtn.addEventListener('click', like);

        let deleteBtn = document.createElement('button');
        deleteBtn.classList.add('delete-btn');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', remove);

        div.appendChild(img);
        div.appendChild(genreHeading);
        div.appendChild(nameHeading);
        div.appendChild(authorHeading);
        div.appendChild(dateHeading);
        div.appendChild(saveBtn);
        div.appendChild(likeBtn);
        div.appendChild(deleteBtn);

        divAllHits.appendChild(div);

        genre.value = '';
        name.value = '';
        author.value = '';
        date.value = '';
    })

    function like(e) {
        let likesText = document.querySelector('.likes p');
        let emptyIndex = likesText.textContent.lastIndexOf(' ') + 1;
        let likes = likesText.textContent.substring(emptyIndex);
        likesText.textContent = `Total Likes: ${++likes}`

        e.target.disabled = true;
    }

    function remove(e) {
        e.target.parentElement.remove();
    }

    function save(e) {
        let songs = document.querySelector('.saved-container');
        songs.appendChild(e.target.parentElement);
        e.target.parentElement.querySelector('.like-btn').remove();
        e.target.parentElement.querySelector('.save-btn').remove();
    }

    function isEmptyOrSpaces(str) {
        return str === null || str.match(/^ *$/) !== null;
    }
}
async function attachEvents() {
    document.getElementById('btnLoadPosts').addEventListener('click', async (e) => {
        e.target.disabled = true;
        
        let postsUrl = 'http://localhost:3030/jsonstore/blog/posts';

        const postsRes = await fetch(postsUrl);

        const postsData = await postsRes.json();

        let ids = [];
        let bodies = [];
        let titles = [];

        Object.entries(postsData).sort((a, b) => a[1].title.localeCompare(b[1].title))
            .forEach(x => {
                ids.push(x[0]);
                bodies.push(x[1].body);
                titles.push(x[1].title);
            })

        let options = document.getElementById('posts');

        for (let i = 0; i < ids.length; i++) {
            let option = document.createElement('option');
            option.value = ids[i];
            option.textContent = titles[i];

            options.appendChild(option);
        }
    })

    let ul = document.getElementById('post-comments');

    let postTitle = document.getElementById('post-title');

    let postBody = document.getElementById('post-body');

    let h2 = document.querySelector('h2');

    document.getElementById('btnViewPost').addEventListener('click', async (e) => {
        e.target.disabled = true;

        postTitle.textContent = 'Loading...';
        postBody.textContent = '';
        h2.style.display = 'none';

        document.querySelectorAll('#post-comments li').forEach(x => x.remove());

        let post = document.getElementById('posts');
        let currentPost = post.options[post.selectedIndex];
        let currentPostId = currentPost.value;

        let commentsUrl = `http://localhost:3030/jsonstore/blog/comments/`;

        const commentsRes = await fetch(commentsUrl);

        const commentsData = await commentsRes.json();

        let comments = Object.entries(commentsData).filter(x => x[1].postId == currentPostId);

        let bodyUrl = `http://localhost:3030/jsonstore/blog/posts/${currentPostId}`;

        const bodyRes = await fetch(bodyUrl);

        const bodyData = await bodyRes.json();

        postBody.textContent = bodyData.body;

        for (const comment of comments) {
            let li = document.createElement('li');
            li.id = comment[1].id;
            li.textContent = comment[1].text;

            ul.appendChild(li);
        }

        postTitle.textContent = currentPost.textContent;
        h2.style.display = 'block';
        e.target.disabled = false;
    })
}

attachEvents();
import { deleteMemeById, getMemeById } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';
 
const detailsTemplate = (meme, userData, onDelete) => html`
<section id="meme-details">
    <h1>Meme Title: ${meme.title}
    </h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${meme.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>${meme.description}</p>
            ${(userData && meme._ownerId == userData.id)
                ? html`<a class="button warning" href="/edit/${meme._id}">Edit</a>
                    <button class="button danger"  @click=${onDelete}>Delete</button>`
                : null }
        </div>
    </div>
</section>`;
 
export async function detailsPage(ctx) {
    const meme = await getMemeById(ctx.params.id);
 
    const userData = getUserData();
 
    ctx.render(detailsTemplate(meme, userData, onDelete));
 
    async function onDelete() {
        if (confirm('Are you sure you want to delete this meme FOREVER?')) {
            await deleteMemeById(meme._id);
            ctx.page.redirect('/memes');
        }
    }
}
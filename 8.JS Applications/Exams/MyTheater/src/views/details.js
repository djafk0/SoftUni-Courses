import { deleteTheaterById, getTheaterById } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const detailsTemplate = (theater, isOwner, onDelete) => html`
<section id="detailsPage">
    <div id="detailsBox">
        <div class="detailsInfo">
            <h1>Title: ${theater.title}</h1>
            <div>
                <img src=${theater.imageUrl} />
            </div>
        </div>

        <div class="details">
            <h3>Theater Description</h3>
            <p>${theater.description}</p>
            <h4>Date: ${theater.date}</h4>
            <h4>Author: ${theater.author}</h4>
            ${theaterControlsTemplate(theater, isOwner, onDelete)}
            <p class="likes">Likes: 0</p>
        </div>
    </div>
</section>`;

const theaterControlsTemplate = (theater, isOwner, onDelete) => {
    if (isOwner) {
        return html`
            <div class="buttons">
                <a @click=${onDelete} class="btn-delete" href="javascript:void(0)">Delete</a>
                <a class="btn-edit" href="/edit/${theater._id}">Edit</a>
                <a class="btn-like" href="/like/${theater._id}">Like</a>
            </div>`;
        } else {
            return null;
        }
}

export async function detailsPage(ctx) {
    const theater = await getTheaterById(ctx.params.id);

    const userData = getUserData();
    const isOwner = userData && userData.id == theater._ownerId;

    ctx.render(detailsTemplate(theater, isOwner, onDelete));

    async function onDelete(){
        const choice = confirm('Are you sure?');

        if(choice){
            await deleteTheaterById(ctx.params.id);
            ctx.page.redirect('/');
        }
    }
}
import { editTheater, getTheaterById } from "../api/data.js";
import { html } from "../lib.js";

const editTemplate = (theater, onSubmit) => html`
<section id="editPage">
    <form @submit=${onSubmit} class="theater-form">
        <h1>Edit Theater</h1>
        <div>
            <label for="title">Title:</label>
            <input id="title" name="title" type="text" placeholder="Theater name" .value=${theater.title}>
        </div>
        <div>
            <label for="date">Date:</label>
            <input id="date" name="date" type="text" placeholder="Month Day, Year" .value=${theater.date}>
        </div>
        <div>
            <label for="author">Author:</label>
            <input id="author" name="author" type="text" placeholder="Author"
            .value=${theater.author}>
        </div>
        <div>
            <label for="description">Theater Description:</label>
            <textarea id="description" name="description"
                placeholder="Description" .value=${theater.description}></textarea>
        </div>
        <div>
            <label for="imageUrl">Image url:</label>
            <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url"
            .value=${theater.imageUrl}>
        </div>
        <button class="btn" type="submit">Submit</button>
    </form>
</section>`;

export async function editPage(ctx){
    const theater = await getTheaterById(ctx.params.id);
    ctx.render(editTemplate(theater, onSubmit));

    async function onSubmit(event){
        event.preventDefault();

        const formData = new FormData(event.target);

        const title = formData.get('title');
        const date = formData.get('date');
        const author = formData.get('author');
        const imageUrl = formData.get('imageUrl');
        const description = formData.get('description');

        if(title == '' || description == '' || imageUrl == '' || date == '' || author == ''){
            return alert('All fields are required');
        }

        await editTheater(ctx.params.id, {
            title,
            date,
            author,
            imageUrl,
            description
        });

        ctx.page.redirect('/details/' + ctx.params.id);
    }
}
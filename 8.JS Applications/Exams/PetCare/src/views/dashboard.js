import { getAllPets } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const dashboardTemplate = (pets) => html`
<section id="dashboard">
    <h2 class="dashboard-title">Services for every animal</h2>
    <div class="animals-dashboard">
        ${pets.length == 0 
            ? html`<div><p class="no-pets">No pets in dashboard</p></div>`
            : html`${pets.map(petPreview)}` }
    </div>
</section>`;

const petPreview = (pet) => html`
<div class="animals-board">
    <img class="animal-image-cover" src=${pet.image}>
    <h2 class="name">${pet.name}</h2>
    <h3 class="breed">${pet.breed}</h3>
    <div class="action">
        <a class="btn" href="/details/${pet._id}">Details</a>
    </div>
</div>`;

export async function dashboardPage(ctx){
    const pets = await getAllPets();
    ctx.render(dashboardTemplate(pets));
}
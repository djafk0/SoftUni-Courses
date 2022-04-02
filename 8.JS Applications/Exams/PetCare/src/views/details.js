import { createDonation, deletePetById, getDonationByUserId, getDonationCount, getPetById } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const detailsTemplate = (pet, isOwner, onDelete, onDonation, donation, isDonated) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src=${pet.image}
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age}</h4>
                <h4>Weight: ${pet.weight}</h4>
                <h4 class="donation">Donation: ${donation}$</h4>
            </div>
            ${getUserData() == null
        ? null
        : html`<div class="actionBtn">${petControlsTemplate(pet, isOwner, onDelete, onDonation, isDonated)}</div>`}
        </div>
    </div>
</section>`;

const petControlsTemplate = (pet, isOwner, onDelete, onDonation, isDonated) => {
    if (isOwner) {
        return html`
        <a href="/edit/${pet._id}" class="edit">Edit</a>
        <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>`;
    } else {
        if(isDonated == 0){
            return html`<a @click=${onDonation} href="javascript:void(0)" class="donate">Donate</a>`;
        }
    }
}

export async function detailsPage(ctx) {
    const pet = await getPetById(ctx.params.id);

    const userData = getUserData();
    const isOwner = userData && userData.id == pet._ownerId;

    const donation = await getDonationCount(ctx.params.id) * 100;

    const isDonated = userData != null ? await getDonationByUserId(ctx.params.id, userData.id) : 0;

    ctx.render(detailsTemplate(pet, isOwner, onDelete, onDonation, donation, isDonated));

    async function onDelete() {
        const choice = confirm('Are you sure?');

        if (choice) {
            await deletePetById(ctx.params.id);
            ctx.page.redirect('/');
        }
    }

    async function onDonation() {
        document.querySelector('.donation').textContent = 'Donation: ' + (donation + 100) + '$';
        document.querySelector('.donate').style.display = 'none';
        await createDonation(ctx.params.id);
    }
}
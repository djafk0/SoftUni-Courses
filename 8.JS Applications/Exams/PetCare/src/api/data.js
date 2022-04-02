import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllPets() {
    return api.get('/data/pets?sortBy=_createdOn%20desc&distinct=name');
}

export async function getPetById(id) {
    return api.get('/data/pets/' + id);
}

export async function createPet(pet) {
    return api.post('/data/pets', pet);
}

export async function editPet(id, pet) {
    return api.put('/data/pets/' + id, pet);
}

export async function deletePetById(id) {
    return api.del('/data/pets/' + id);
}

export async function getDonationCount(petId) {
    return api.get(`/data/donation?where=petId%3D%22${petId}%22&distinct=_ownerId&count`);
}

export async function createDonation(petId) {
    return api.post('/data/donation', { petId });
}

export async function getDonationByUserId(petId, userId) {
    return api.get(`/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`)
}

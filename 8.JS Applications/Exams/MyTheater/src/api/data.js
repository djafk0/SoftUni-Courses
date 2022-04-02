import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllTheaters() {
    return api.get('/data/theaters?sortBy=_createdOn%20desc&distinct=title');
}

export async function getTheaterById(id) {
    return api.get('/data/theaters/' + id);
}

export async function createTheater(theater) {
    return api.post('/data/theaters', theater);
}

export async function editTheater(id, theater) {
    return api.put('/data/theaters/' + id, theater);
}

export async function deleteTheaterById(id) {
    return api.del('/data/theaters/' + id);
}

export async function getMyTheaters(userId){
    return api.get(`/data/theaters?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}
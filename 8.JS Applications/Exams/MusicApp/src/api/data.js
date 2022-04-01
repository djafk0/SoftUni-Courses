import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllAlbums() {
    return api.get('/data/albums?sortBy=_createdOn%20desc&distinct=name');
}

export async function getAlbumById(id) {
    return api.get('/data/albums/' + id);
}

export async function createAlbum(book) {
    return api.post('/data/albums', book);
}

export async function editAlbum(id, book) {
    return api.put('/data/albums/' + id, book);
}

export async function deleteAlbumById(id) {
    return api.del('/data/albums/' + id);
}
import { logout } from '../api/data.js';
import { page, render } from '../lib.js';
import { getUserData } from '../util.js';

const root = document.getElementById('content');
document.getElementById('logoutBtn').addEventListener('click', onLogout);

export default function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, root);
    ctx.updateUserNav = updateUserNav;

    next();
}

export function updateUserNav(){
    const userData = getUserData();

    if(userData){
        document.getElementsByClassName('user')[0].style.display = 'inline-block';
        document.getElementsByClassName('user')[1].style.display = 'inline-block';
        document.getElementsByClassName('user')[2].style.display = 'inline-block';
        document.getElementsByClassName('guest')[0].style.display = 'none';
        document.getElementsByClassName('guest')[1].style.display = 'none';
    } else {
        document.getElementsByClassName('user')[0].style.display = 'none';
        document.getElementsByClassName('user')[1].style.display = 'none';
        document.getElementsByClassName('user')[2].style.display = 'none';
        document.getElementsByClassName('guest')[0].style.display = 'inline-block';
        document.getElementsByClassName('guest')[1].style.display = 'inline-block';
    }
}

function onLogout() {
    logout();
    updateUserNav();
    page.redirect('/');
}
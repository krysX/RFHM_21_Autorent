// let token = localStorage.getItem("token");
// const api = import('/api.js');

function init() {
    getRequest("/cars")
        .then(json => alert(JSON.stringify(json)))
    
    // felhasználói adatok lekérése (név, username) (API hívás!)
    const userData = getRequest('/users/me');
    console.log(userData);
    // username-text beállítása
    // autó-kategóriák lekérése és beállítása (API hívás!) -> selectCategory()
    // autók lekérése és tábla feltöltése
}

function selectCategory(id) {
    // kategória kiválasztásakor fut le
    // autók lekérése és tábla feltöltése (API hívás!)
}

function onDetailsClick(carId) {
    // autó id elmentése local storage-ba
    localStorage.setItem("carId", carId);
    // átirányítás a rent_car.html-re
    window.location.href = '/rent_car.html';
}   
let token = localStorage.getItem("token");
let carId = localStorage.getItem("carId");
let car;
let carAvailable;

function getCarData() {
    // let car = autó adatainak lekérése (API!)
    // let carAvailable = autó mikor szabad (API!)
    // megfelelő mezőkbe adatok betöltése
}

function updateRentalDetails() {
    // input mezőből kezdeti és végdátum lekérése
    // ha bármely foglalt nap a kezdeti és végnap közé esik, nem lehetséges a kölcsönzés
    // különben napok és díjszámítása
    // szövegek update-elése e szerint
}

function rentCar() {
    // új kölcsönzés felvétele a fiókba (API!)
}
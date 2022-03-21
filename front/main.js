import { Hotel } from "./hotel.js";

// const hotel = new Hotel(7,"Ambasador","Vlasotince","22 divizije",20);
// hotel.crtaj(document.body);


fetch("https://localhost:5001/Hotel/Hoteli").then( p=> {
        p.json().then(data => {
            data.forEach(hotel => {
                const hotel1 = new Hotel(hotel.id, hotel.naziv, hotel.grad,hotel.adresa, hotel.brojSoba);
                hotel1.crtaj(document.body);
            });});})


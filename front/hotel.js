import { Gost } from "./gost.js";
import { Racun } from "./racun.js";
import {Soba} from "./soba.js";
export class Hotel
{

    constructor(id, naziv, grad,adresa, brojSoba)
    {
        this.id = id;
        this.naziv = naziv;
        this.adresa = adresa;
        this.grad=grad;

        this.brojSoba = brojSoba;

        this.sobe = [];
        this.racuni = [];
        this.gosti=[];
        this.grafovi=[];

        this.tipovi=["Jednokrevetna","Dvokrevetna","Trokrevetna","Cetvorokrevetna"];
        

        this.kontejner = null;
    }

    crtaj(host)
    {
        if (!host)
            throw new Error("Host nije definisan!");


        this.kontejner = document.createElement("div");
        this.kontejner.className = "kontejnerHotel";
        host.appendChild(this.kontejner);

        const naziv = document.createElement("h1");
        naziv.innerHTML = this.naziv;
        this.kontejner.appendChild(naziv);
        
        
        const kontForme=document.createElement("div");
        kontForme.classList="kontForma";
        this.kontejner.appendChild(kontForme);

        this.crtajDodajGosta(kontForme);
        this.crtajformuSoba(kontForme);

        const kontSobe = document.createElement("div");
        kontSobe.className = "kontSobe";
        this.kontejner.appendChild(kontSobe);

        this.crtajFormuSobe(kontSobe);
        this.crtajSobe(kontSobe);

        const kontRacun= document.createElement("div");
        kontRacun.className = "kontRacun";
        this.kontejner.appendChild(kontRacun);

        this.crtajRacun(kontRacun);
        this.crtajGraf(kontRacun);

        const kontrazdvoji= document.createElement("br");
        
        this.kontejner.appendChild(kontrazdvoji);
       
    }

    crtajDodajGosta(host)
    {
        if (!host)
            throw new Error("Host nije definisan!");
        
        const gostDiv=document.createElement("div");
        gostDiv.classList="formaGost";
        host.appendChild(gostDiv);

        let naslovGost=document.createElement("h3");
        naslovGost.innerHTML="Dodaj gosta";
        gostDiv.appendChild(naslovGost);

        let labelaIme=document.createElement("label");
        labelaIme.innerHTML="Ime:";
        labelaIme.className="labelaIme";
        gostDiv.appendChild(labelaIme);
        let inputIme=document.createElement("input");
        inputIme.className="inputIme";
        inputIme.type="text";
        gostDiv.appendChild(inputIme);   

        let labelaPrezime=document.createElement("label");
        labelaPrezime.innerHTML="Prezime:";
        labelaPrezime.className="labelaPrezime";
        gostDiv.appendChild(labelaPrezime);
        let inputPrezime=document.createElement("input");
        inputPrezime.className=".inputPrezime";
        inputPrezime.type="text";
        gostDiv.appendChild(inputPrezime);  

        let labelaLicnaKarta=document.createElement("label");
        labelaLicnaKarta.innerHTML="Broj licne karte:";
        labelaLicnaKarta.className="labelaLicnaKarta";
        gostDiv.appendChild(labelaLicnaKarta);
        let inputLicnaKarta=document.createElement("input");
        inputPrezime.className=".inputLicnaKarta";
        inputLicnaKarta.type="number";
        gostDiv.appendChild(inputLicnaKarta);  

      
        
        let dugmeDodajGosta=document.createElement("button");
        dugmeDodajGosta.className=".dugmeDodajGosta";
        dugmeDodajGosta.innerHTML="Dodaj";
        gostDiv.appendChild(dugmeDodajGosta);

    

        dugmeDodajGosta.onclick = (ev) => 
        {
            let ime= inputIme.value;
            let prezime= inputPrezime.value;
            let licnakarta= inputLicnaKarta.value;
            
            if (ime === "")
            {
                alert("Morate uneti ime!");
                return;
            }
    
            if (prezime === "")
            {
                alert("Morate uneti prezime!");
                return;
            }

            if (licnakarta === "")
            {
                alert("Morate uneti prezime!");
                return;
            }

            fetch("https://localhost:5001/Hotel/DodajGostaUHotel/"+this.id+"/"+ime+"/"+prezime+"/"+licnakarta
            ,{method:'POST'}).then(p => {
                if (p.ok)
                {
                    p.json().then(msg =>
                    {
                        let gost1=new Gost(msg.id,ime,prezime,licnakarta)
                        this.gosti.push(gost1);
                        
                        
                        alert(msg.poruka);
                      
                    })
                }
                else
                {
                    p.json().then(msg => alert(msg.poruka))
                    
                }  
            })
        

        }

        
    }
        
    

    crtajformuSoba(host)
    {
        let kontejnerDodaj = document.createElement("div");
        kontejnerDodaj.className = "kontUpravljanje";
        host.appendChild(kontejnerDodaj);
        
        
        let elLabela = document.createElement("h3");
        elLabela.innerHTML = "Dodaj sobu";
        kontejnerDodaj.appendChild(elLabela);

        let dodajSobuLabela=document.createElement("label");
        dodajSobuLabela.innerHTML="Broj sobe:";
        kontejnerDodaj.appendChild(dodajSobuLabela);

        let izbor = document.createElement("select");
        kontejnerDodaj.appendChild(izbor);
        let opcija=[];
        for(let i=0;i<this.brojSoba;i++)
        {
            opcija = document.createElement("option");
            opcija.innerHTML = i+1;
            opcija.value = i+1;
            izbor.appendChild(opcija);
        }

        let tipSobeLabela=document.createElement("label");
        tipSobeLabela.innerHTML="Tip sobe:";
        kontejnerDodaj.appendChild(tipSobeLabela);

        let izbor1=document.createElement("select");
        kontejnerDodaj.appendChild(izbor1);

        let opcija1 = null;
        for(let i=0;i<this.tipovi.length;i++)
        {
            opcija1 = document.createElement("option");
            opcija1.innerHTML = this.tipovi[i];
            opcija1.value = this.tipovi[i];
            izbor1.appendChild(opcija1);
        }

        let dugmiciDiv = document.createElement("div");
        dugmiciDiv.className = "dugmiciSoba";
        kontejnerDodaj.appendChild(dugmiciDiv);

         const dugmeDodaj = document.createElement("button");
        dugmeDodaj.innerHTML="Dodaj sobu";
        dugmeDodaj.className = "dugmeDodajSobu";
        dugmiciDiv.appendChild(dugmeDodaj);

        dugmeDodaj.onclick = (ev) => 
        {
           
                let brojsobe = parseInt(izbor.value);
                let tip = izbor1.value;

                console.log(brojsobe+" "+tip);
                
        
                if (brojsobe === "")
                {
                    alert("Morate izabrati broj sobe!");
                    return;
                }
        
                if (tip === "")
                {
                    alert("Morate izabrati tip sobe!");
                    return;
                }
        
                fetch("https://localhost:5001/Hotel/DodajSobuuHotel?idHotela=" + this.id +
                "&brojSobe=" + encodeURIComponent(brojsobe) + "&tip=" + encodeURIComponent(tip),
                {
                    method: "POST"
                })
                .then(p => {
                    if (p.ok)
                    {
                        p.json().then(k => 
                        {
                            let novaSoba = new Soba(k.id, brojsobe,tip);
                            this.sobe.push(novaSoba);
                            alert(k.poruka);
                            //let racun=new Racun(k.id,novaSoba);
                            this.racuni.push(racun);
                        });
                    }
                    else
                    {
                        p.json().then(k => { alert(k.poruka) })
                    }
        
                })
            
        
        }
        
        
        

    }

   
    crtajFormuSobe(host)
    {
        if(!host)
            throw new Error("Host nije definisan!");
        
        const kontFormaSobe = document.createElement("div");
        kontFormaSobe.classList.add("kontSobe","divSobe");
        host.appendChild(kontFormaSobe);

        let elLabela = document.createElement("h3");
        elLabela.innerHTML = "Smesti gosta u sobu";
        kontFormaSobe.appendChild(elLabela);

        let elInput;

        let podaci = ["Broj licne karte:", "Datum prijavljivanja:", "Broj nocenja:"];
        let imenaKlasa = ["licnaKarta", "datumPrijavljivanja", "brojNocenja"];
        let tipovi = ["number", "date", "number"];
        podaci.forEach((el, ind) =>
        {
            elLabela = document.createElement("label");
            elLabela.innerHTML = el;
            elLabela.className="prvaforma";
            kontFormaSobe.appendChild(elLabela);
            elInput = document.createElement("input");
            elInput.type = tipovi[ind];
            elInput.className = imenaKlasa[ind];
            kontFormaSobe.appendChild(elInput);
        })

        kontFormaSobe.appendChild(document.createElement("br"));

        let divSl = document.createElement("div");
        kontFormaSobe.appendChild(divSl);
        elLabela = document.createElement("label");
        elLabela.innerHTML = "Broj sobe:";
        divSl.appendChild(elLabela);
        let izbor = document.createElement("select");
        divSl.appendChild(izbor);
        let opcija = null;
        for(let i=0;i<this.brojSoba;i++)
        {
            opcija = document.createElement("option");
            opcija.innerHTML = i+1;
            opcija.value = i+1;
            izbor.appendChild(opcija);
        }


        let dugmeRezervisi = document.createElement("button");
        dugmeRezervisi.innerHTML="Rezervisi";
        dugmeRezervisi.classList="rezervisi";
        kontFormaSobe.appendChild(dugmeRezervisi);

        let dugmeIsprati = document.createElement("button");
        dugmeIsprati.innerHTML="Isprati gosta";
        dugmeIsprati.classList="rezervisi";
        kontFormaSobe.appendChild(dugmeIsprati);
        dugmeRezervisi.onclick = (ev)=>{

            let licnakarta=kontFormaSobe.querySelector(".licnaKarta").value;
            //console.log(licnakarta);
            let prijavljivanjeDatum=kontFormaSobe.querySelector(".datumPrijavljivanja").value;
            console.log(prijavljivanjeDatum);
            let brojdana=kontFormaSobe.getElementsByClassName("brojNocenja")[0].value;
            let  brsobe=izbor.value;

            

            if (licnakarta === "")
            {
                alert("Morate uneti licnu kartu!");
                return;
            }
    
            if (prijavljivanjeDatum === "")
            {
                alert("Morate izabrati datum!");
                return;
            }

            if (brojdana === "")
            {
                alert("Morate uneti broj dana!");
                return;
            }
        
           
            if (brsobe === "")
            {
                alert("Morate izabrati broj sobe!");
                return;
            }
            
            let cena=brojdana*this.sobe.find(p => p.brojSobe == brsobe).vratiCenuPoTipuSobe();
            console.log(cena);
            fetch("https://localhost:5001/Hotel/DodajGostaUSobu/"+this.id+"/"+brsobe+"/"+licnakarta+"/"+prijavljivanjeDatum+"/"+brojdana
            ,{method:'POST'})


            fetch("https://localhost:5001/Hotel/DodajRacun/"+this.id+"/"+brsobe+"/"+cena ,{method:'POST'})
           

            if(this.sobe.find(p => p.brojSobe == brsobe).brojDana==0)
            {
                
                
                this.sobe.find(p => p.brojSobe == brsobe ).azurirajSobu(brojdana,true);
            }
            //this.sobe.find(p => p.brojSobe == brsobe).azurirajGraf();
            
            

            // fetch("https://localhost:5001/Hotel/IzmeniSobu/"+this.id+"/"+brsobe+"/"+brojdana+"/true"
            // ,{method:'PUT'})

            //this.sobe.find(p => p.brojSobe == brsobe).azurirajSobu(brojdana,true);
           // this.kontejner.getElementsByClassName("kontSobe")[0].removeChild(document.getElementsByClassName("sobeCrtanje")[0])
            //this.crtajSobe(this.kontejner.getElementsByClassName("kontSobe")[0]);
           
                  
        }
        dugmeIsprati.onclick=(ev)=>{
            let  brsobe=izbor.value;
            if (brsobe === "")
            {
                alert("Morate izabrati broj sobe!");
                return;
            }
            fetch("https://localhost:5001/Hotel/ObrisiGostSoba/"+this.id+"/"+brsobe
            ,{method:'DELETE'})

            fetch("https://localhost:5001/Hotel/ObrisiRacun/"+this.id+"/"+brsobe
            ,{method:'DELETE'})

            this.sobe.find(p => p.brojSobe == brsobe).azurirajSobu(0,false);

        }




    }

    crtajSobe(host)
    {
        if(!host)
            throw new Error("Host nije definisan!");
        const crtanjeSobe = document.createElement("div");
        crtanjeSobe.classList="sobeCrtanje";
        
        host.appendChild(crtanjeSobe);

        

        fetch("https://localhost:5001/Hotel/PreuzmiSobe/" + this.id).then(p=>{
            p.json().then(data=> {
                data.forEach(soba => {
                    let soba1 = new Soba(soba.id, soba.brojSobe, soba.tip,soba.zauzeta,soba.brojDana);
                    this.grafovi.push(soba1);
                    soba1.crtajSobu(crtanjeSobe);

                   
                    
                    
                    
                    
                })
            })
        })
    }
    
    crtajRacun(host)
    {
        if(!host)
            throw new Error("Host nije definisan!");

            const crtanjeRacuna = document.createElement("div");
            crtanjeRacuna.classList="crtanjeRacuna";
            host.appendChild(crtanjeRacuna);

            let naslovGost=document.createElement("h3");
            naslovGost.innerHTML="Racun";
            crtanjeRacuna.appendChild(naslovGost);

            let brojSobelbl=document.createElement("label");
            brojSobelbl.innerHTML="Broj sobe:";
            crtanjeRacuna.appendChild(brojSobelbl);

            let izbor = document.createElement("select");
            crtanjeRacuna.appendChild(izbor);
            let opcija=[];
            for(let i=0;i<this.brojSoba;i++)
            {
                opcija = document.createElement("option");
                opcija.innerHTML = i+1;
                opcija.value = i+1;
                izbor.appendChild(opcija);
            }
            let roomLlb=document.createElement("br");
            crtanjeRacuna.appendChild(roomLlb);


            const dugmeRacun = document.createElement("button");
            dugmeRacun.innerHTML="Racun";
            dugmeRacun.className = "dugmeRacun";
            crtanjeRacuna.appendChild(dugmeRacun);

            dugmeRacun.onclick=(ev)=>
            {
                let brsobe=izbor.value;

                console.log(brsobe);
                let cena=fetch("https://localhost:5001/Hotel/PreuzmiRacun/{idHotela}/{brojsobe}"+this.id+"/"+brsobe
                ,{method:'GET'}
                )
                console.log(cena);




            }

        
    }


    crtajGraf(host)
    {
        if(!host)
            throw new Error("Host nije definisan!");

            const crtanjeGrafa = document.createElement("div");
            crtanjeGrafa.classList="crtanjeGrafa";
            host.appendChild(crtanjeGrafa);

            fetch("https://localhost:5001/Hotel/PreuzmiSobe/" + this.id).then(p=>{
                p.json().then(data=> {
                    data.forEach(soba => {
                        let soba1 = new Soba(soba.id, soba.brojSobe, soba.tip,soba.zauzeta,soba.brojDana);
                        this.sobe.push(soba1);
                        soba1.crtajGrafce(crtanjeGrafa);
    
                       
                        
                        
                        
                        
                    })
                })
            })


    }




  
}
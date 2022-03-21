import { GostiUSobi } from "./gostuSobi.js";
export class Soba
{
    constructor(id,brojSobe,tip,zauzeta,brojDana)
    {
        this.id=id;
        this.brojSobe=brojSobe;
        this.tip=tip;
        this.brojDana=brojDana;

        this.zauzeta=zauzeta;

        this.gostuSobi=null;

        this.miniSobaKont=null;
        this.minigraf=null;
    }
    crtajSobu(host)
    {
        // if(!host)
        //     throw new Error("Host nije definisan!");
        
        this.miniSobaKont = document.createElement("div");
        this.miniSobaKont.id = this.brojSobe;
        this.miniSobaKont.className = "miniSobaKont";
        
        if(this.zauzeta==true)
          this.miniSobaKont.style.backgroundColor = "#ff0103";
          else
          this.miniSobaKont.style.backgroundColor = "#ffffff";
        let tekst = "Soba broj: " + `${this.brojSobe}`+"<br>"+"Broj nocenja: "+ `${this.brojDana}`;
        tekst += "\n " + this.tip;
        this.miniSobaKont.innerHTML = tekst;
        host.appendChild(this.miniSobaKont);
      

    }
    azurirajSobu(brDana,zauzeta,kontejner)
    {

    
      this.miniSobaKont = kontejner.getElementById(this.brojSobe);
      if(zauzeta==true)
          this.miniSobaKont.style.backgroundColor = "#ff0103";
          else
          this.miniSobaKont.style.backgroundColor = "#ffffff";
        let tekst = "Soba broj: " + `${this.brojSobe}`+"<br>"+"Broj nocenja: "+ `${brDana}`;
        tekst += "\n " + this.tip;
        this.miniSobaKont.innerHTML = tekst;
      
      
        
    }


    vratiCenuPoTipuSobe()
    {
        var cena = 0;
        switch(this.tip)
        {
            case "Jednokrevetna":
                cena = 2500;
                break;
            case "Dvokrevetna":
                cena = 5000;
                break;
            case "Trokrevetna":
                cena = 7000;
                break;
            case "Cetvorokrevetna":
                cena = 8500;
                break;
            default:
                cena = 0;
        }
        return cena;
    }
   

    crtajGrafce(host)
    {
        this.minigraf = document.createElement("div");
        this.minigraf.id = this.brojSobe;
        this.minigraf.classList.add("miniGraf","font1");

        if(this.brojDana!=0)
        {
            host.appendChild(this.minigraf);
            let sirina = (this.brojDana/2) *100;
            this.minigraf.style.width = (sirina+"px");
            if(this.brojDana==1)
            {
                this.minigraf.innerHTML="Soba broj:" + `${this.brojSobe}`+" jos "+`${this.brojDana}`+" noc";
            }
            else
            {
                this.minigraf.innerHTML="Soba broj:" + `${this.brojSobe}`+" jos "+`${this.brojDana}`+" noci" 
            }
          

        }
        
        
    }

    azurirajGraf()
    {
        this.minigraf = document.getElementById(this.brojSobe);
        
            host.appendChild(this.minigraf);
            let sirina = this.brojDana *100;
            this.minigraf.style.width = sirina;
            if(this.brojDana==1)
            {
                this.minigraf.innerHTML="Soba broj:" + `${this.brojSobe}`+" jos "+`${this.brojDana}`+" noc";
            }
            else
            {
                this.minigraf.innerHTML="Soba broj:" + `${this.brojSobe}`+" jos "+`${this.brojDana}`+" noci" 
            }
          

        
    }
}
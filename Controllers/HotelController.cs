    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using hotel.Models;
    using Microsoft.EntityFrameworkCore;

    namespace hotel.Controllers
    {
        [ApiController]
        [Route("[controller]")]

        public class HotelController : ControllerBase
        {    
        public HotelPrContext Context{get;set;}

        public HotelController(HotelPrContext context)
        {
            Context=context;
        }


       [HttpDelete]
        [Route("ObrisiRacun/{idHotela}/{brSobe}")]
        public async Task ObrisiGostUSobi(int idHotela,int brSobe)
        {
            
            var racuni= await Context.Racuni.Where(p=>p.Hotel.ID==idHotela).ToListAsync();
            
            
            foreach (var item in racuni)
            {
                if(item.soba.BrojSobe==brSobe)
                {
                     Context.Racuni.Remove(item);
                }
            }

            
            //Context.Racuni.Remove(racun);
           // Context.Gosti.Remove(gost);
            await Context.SaveChangesAsync();
        }
         [Route("PreuzmiRacun/{idHotela}/{brojsobe}")]
         [HttpGet]

            public async Task<ActionResult> PreuzmiRacun(int idHotela,int brojsobe)
            {   Soba soba=null;
                var nizSoba= await Context.Sobe.Where(x=>x.Hotel.ID==idHotela).ToListAsync();
                foreach (var item in nizSoba)
                {
                    if(item.BrojSobe==brojsobe)
                    {
                        soba=item;
                    }
                    
                }
                
                var racun=await Context.Racuni.Where(x=>x.soba.ID==soba.ID).FirstAsync();
                if(racun==null)
                {
                    return BadRequest("Soba je prazna");
                }
                else{
                    return Ok(racun.KonacnaCena);
                }
                
            }
        [Route("DodajRacun/{idHotela}/{brojsobe}/{cenapoTipu}")]
        [HttpPost]

        public async Task<ActionResult> DodajRacun(int idHotela,int brojsobe,int cenapoTipu)
        {
                 if(idHotela<=0)
                    {return BadRequest("Nepostojeci id");}
                if(brojsobe<=0)
                    {return BadRequest("Pograsan broj");}
                if(cenapoTipu<=0)
                    {return BadRequest("nepostojeca licna karta");}
              
                 Soba soba=null;
                var nizSoba= await Context.Sobe.Where(x=>x.Hotel.ID==idHotela).ToListAsync();
                foreach (var item in nizSoba)
                {
                    if(item.BrojSobe==brojsobe)
                    {
                        soba=item;
                    }
                    
                }


                if(soba!=null)
                {
                    var racun=new Racun();
                    racun.soba=soba;
                    racun.Hotel=await Context.Hoteli.FindAsync(idHotela);
                    racun.KonacnaCena=cenapoTipu;

                    Context.Racuni.Add(racun);
                    await Context.SaveChangesAsync();
                    return Ok("Ok");
                }
                else{
                    return BadRequest("GRESKA");
                }

                
          
        
           
        }

        [Route("Hoteli")]
        [HttpGet]

            public async Task<ActionResult> Preuzmi()
            {
                var hoteli=Context.Hoteli;

                var hotel=await hoteli.ToListAsync();

                return Ok(hotel);
            }

        [Route("DodatiHotel")]
        [HttpPost]
            public async Task<ActionResult>DodajHotel([FromBody] Hotel hotel )
            {
                if(string.IsNullOrEmpty(hotel.Naziv)||hotel.Grad.Length>50)
                {
                    return BadRequest("Pogresno ime");

                }
                try{
                    Context.Hoteli.Add(hotel);
                    await Context.SaveChangesAsync();
                    return Ok("Hotel je dodat");

                }

                catch(Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        [Route("IzmeniHotel/{id}/{naziv}/{grad}/{adresa}")]
        [HttpPut]
            public async Task<ActionResult> Promeni(int id,string naziv,string grad,string adresa)
            {
                if(id<=0){
                    return BadRequest("Nepostojeci ID") ;
                }
                try
                {
                var htl = Context.Hoteli.Where(p=> p.ID==id).FirstOrDefault();  
                if(htl!=null)
                    {
                        htl.Naziv=naziv;
                        htl.Grad=grad;
                        htl.Adresa=adresa;

                        await Context.SaveChangesAsync();
                        return Ok($"Uspesno promenjen hotel sa ID: {htl.ID}");
                    }
                    else{
                        return BadRequest("Ne postoji hotel sa tim IDjem");
                    }

                }
            catch(Exception e){
                return BadRequest(e.Message);

            }

            
            }

        [Route("IzmeniFromBody")]
        [HttpPut]
            public async Task<ActionResult> Izmeni([FromBody] Hotel hotel)
            {
                if(hotel.ID<=0){
                    return BadRequest("Nepostojeci ID") ;
                }
                try
                {
                var htl = await Context.Hoteli.FindAsync(hotel.ID);  
                
                    /* htl.Naziv=hotel.Naziv;
                        htl.Grad=hotel.Grad;
                        htl.Adresa=hotel.Adresa;*/
                        Context.Hoteli.Update(hotel);

                        await Context.SaveChangesAsync();
                        return Ok($"Uspesno promenjen hotel sa ID: {htl.ID}");
                

                }
            catch(Exception e){
                return BadRequest(e.Message);

            }

            
            }   

        [Route("IzbrisiHotel/{id}")]
        [HttpDelete]
            
            public async Task<ActionResult> Izbrisi(int id)
            {
                if(id<=0)
                {
                    return BadRequest("Pogresan ID");

                }
                try
                {   var nizSoba = Context.Sobe.Where(s=>s.Hotel.ID == id);
                await nizSoba.ForEachAsync( s=> 
                {
                    Context.Remove(s);
                });

                var nizRacuna = Context.Racuni.Where(r=> r.Hotel.ID == id);
                await nizRacuna.ForEachAsync( r=> 
                {
                    Context.Remove(r);
                });

                var hotel = await Context.Hoteli.FindAsync(id);
                Context.Remove(hotel);
                await Context.SaveChangesAsync();

                    return Ok($"Uspesno izbrisan Hotel sa nazivom: {hotel.Naziv}");
                }
                catch (Exception e)
                {
                    
                    return BadRequest(e.Message);
                }
            }
        
        
        
         [Route("PreuzmiSobe/{idHotela}")]
            [HttpGet]
            public async Task<List<Soba>> PreuzmiSobe(int idHotela)
            {
                return await Context.Sobe.Where( soba => soba.Hotel.ID == idHotela).OrderBy( soba=> soba.BrojSobe).ToListAsync();
            }

            

            [Route("DodajGosta")]
            [HttpPost]
            public async Task<ActionResult> DodajGosta([FromBody]Gost gost)
            {
                Context.Gosti.Add(gost);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno ste dodali Gosta sa Id: {gost.ID}");
            }

            [Route("DodajGostaUSobu/{idHotela}/{brojSobe}/{licnaKarta}/{Prijavljivanje}/{brojDana}")] //Radi
            [HttpPost]
            public async Task<ActionResult> DodajGostaUSobu(int idHotela,int brojSobe,int licnaKarta, string prijavljivanje, int brojDana)
            {
                if(idHotela<=0)
                    {return BadRequest("Nepostojeci id");}
                if(brojSobe<=0)
                    {return BadRequest("Pograsan broj");}
                if(licnaKarta<=0)
                    {return BadRequest("nepostojeca licna karta");}
               
                

                var hotel=await Context.Hoteli.Where(x=>x.ID==idHotela).FirstAsync();
                var soba= await Context.Sobe.Where(x=>x.BrojSobe==brojSobe && x.Hotel.ID==idHotela).FirstAsync();
                var gosti =await Context.Gosti.Where(x=>x.LicnaKarta==licnaKarta).FirstAsync();
                // var gost =await Context.GostuSobi.Where(x=>x.Gost.LicnaKarta==licnaKarta).FirstAsync();
                // if(gost!=null)
                // { 
                //     return BadRequest(new{Poruka = $"Korisnik je u sobi"});

                // }

                if(hotel is null)
                {
                    
                    return BadRequest(new{Poruka = "Nepostojeci hotel"});
                }
                 if(soba is null)
                {
                    return BadRequest(new{Poruka = "Nepostojeca soba"});
                }
                 if(gosti is null)
                {
                    return BadRequest(new{Poruka = "Nema korisnika sa tom licnom kartom"});
                }

                
                
                    if (soba.Zauzeta==false)
                    {
                        GostuSobi gostuSobi=new GostuSobi();

                        gostuSobi.Gost=gosti;
                        gostuSobi.Soba=soba;
                        gostuSobi.DatumPrijaljivanja=prijavljivanje;                                          
                                              
                        soba.Zauzeta=true;
                        soba.BrojDana=brojDana;
                        Context.Sobe.Update(soba);
                        Context.GostuSobi.Add(gostuSobi);
                        
                        await Context.SaveChangesAsync();
                        return Ok(new{Poruka = $"Korisnik '{gosti.Ime}' je uspešno dodat u sobu broj '{soba.BrojSobe}'."});
                    }
                    else
                    {
                        return BadRequest(new{Poruka = "Soba je zauzeta"});
                    }
                    
                    
                
    
            }

            
            
            [Route ("PreuzmiSveGosteIzSobe/{idSobe}")]
            [HttpGet]
            public async Task<List<JsonResult>> PreuzmiSveGosteIzSobe (int idSobe)
            {
                var gostSoba=await Context.GostuSobi.Where(x=>x.Soba.ID==idSobe).Include(x=>x.Gost).ToListAsync();
                List<JsonResult> Gosti=new List<JsonResult>();
                foreach(var gs in gostSoba)
                {
                    var gost= await Context.Gosti.Where(x=>x==gs.Gost).ToListAsync();
                    Gosti.Add(new JsonResult (gost));
                }
                return Gosti;
            }
        /* [HttpDelete]
        [Route("ObrisiGostUSobi/{idHotela}/{idGostUSobi}")]
        public async Task DeleteGostUSobi(int idHotela,int idGostUSobi)
        {
            var gostSoba=await Context.GostuSobi.FindAsync(idGostUSobi);
            var soba= await Context.Sobe.Where(x=>x.Hotel.ID==idHotela && x.ID==gostSoba.Soba.ID).FirstAsync();
           // var gost=await Context.Gosti.FindAsync(idGostUSobi);
            
            soba.Zauzeta=false;
            soba.BrojDana=0;
            

            Context.Sobe.Update(soba);
            Context.GostuSobi.Remove(gostSoba);
           // Context.Gosti.Remove(gost);
            await Context.SaveChangesAsync();
        }*/

        [HttpDelete]
        [Route("ObrisiGostSoba/{idHotela}/{brSobe}")]
        public async Task ObrisiGostSoba(int idHotela,int brSobe)
        {
            
            var gostSoba=await Context.GostuSobi.Where(p => p.Soba.Hotel.ID==idHotela && p.Soba.BrojSobe == brSobe).FirstOrDefaultAsync();
            var soba= await Context.Sobe.Where(x=>x.Hotel.ID==idHotela && x.ID==gostSoba.Soba.ID).FirstAsync();

           
           // var gost=await Context.Gosti.FindAsync(idGostUSobi);
            
            soba.Zauzeta=false;
            soba.BrojDana=0;
            

            Context.Sobe.Update(soba);
            Context.GostuSobi.Remove(gostSoba);
           // Context.Gosti.Remove(gost);
            await Context.SaveChangesAsync();
        }

                      
        [Route("DodajGostaUHotel/{idHotela}/{ime}/{prezime}/{licnaKarta}")]
        [HttpPost]
        public async Task<ActionResult> DodajGostaUHotel(int idHotela, string ime, string prezime,int licnaKarta)
        {
            if (idHotela <= 0)
            {
                return BadRequest(new { Poruka = "Hotel ne postoji!"});
            }

            

            if (string.IsNullOrWhiteSpace(ime) || ime.Length > 50)
            {
                return BadRequest(new { Poruka = "Pogrešno ime!"});
            }

            if (string.IsNullOrWhiteSpace(prezime) || prezime.Length > 50)
            {
                return BadRequest(new { Poruka = "Pogrešno prezime!"});
            }

            try
            {
                var hotel = Context.Hoteli.Find(idHotela);

                if (hotel is null)
                {
                    return BadRequest(new { Poruka = $"Hotel ne postoji!"});
                }

                var korisnik = Context.Gosti.Where(p => p.LicnaKarta == licnaKarta&&p.Hotel.ID==idHotela).FirstOrDefault();

                if (korisnik != null)
                {
                    return BadRequest(new { Poruka = $"Gost sa licnom kartom '{licnaKarta}' je već registrovan u hotelu "});
                }

                var gostKlijent = new Gost();
                gostKlijent.Ime = ime;
                gostKlijent.Prezime = prezime;
                gostKlijent.LicnaKarta = licnaKarta;
                gostKlijent.Hotel = hotel;
                Context.Gosti.Add(gostKlijent);
                await Context.SaveChangesAsync();
                return Ok(new { ID = gostKlijent.ID,
                                Poruka = $"Gost '{gostKlijent.Ime}' je uspešno dodat u hotel '{hotel.Naziv}'."
                            });
            }
            catch (Exception e)
            {
                return BadRequest(new { Poruka = e.Message});
            }
        }       

    
    
    
        [Route("DodajSobuuHotel")]
        [HttpPost]
        public async Task<ActionResult> DodajSobuUHotel([FromQuery] int idHotela, [FromQuery] int brojsobe, [FromQuery] string tip)
        {
            if (idHotela <= 0)
            {
                return BadRequest(new { Poruka = "Hotel ne postoji!"});
            }


            try
            {
                var hotel = Context.Hoteli.Find(idHotela);

                if (hotel is null)
                {
                    return BadRequest(new { Poruka = $"Hotel ne postoji!"});
                }

                var soba = Context.Sobe.Where(p => p.Hotel.ID == idHotela && p.BrojSobe==brojsobe).FirstOrDefault();

                if (soba != null)
                {
                    return BadRequest(new { Poruka = $"Soba je već registrovana u hotelu "});
                }

                var sobaKlijent = new Soba();
                sobaKlijent.BrojSobe = brojsobe;
                sobaKlijent.tip = tip;
                
                sobaKlijent.Hotel = hotel;
                Context.Sobe.Add(sobaKlijent);
                await Context.SaveChangesAsync();
                return Ok(new { ID = sobaKlijent.ID,
                                Poruka = $"Soba '{sobaKlijent.BrojSobe}' je uspešno dodata  u hotel '{hotel.Naziv}'."
                            });
            }
            catch (Exception e)
            {
                return BadRequest(new { Poruka = e.Message});
            }

        
        }     

        [Route("IzmeniSobu/{idHotela}/{brojSobe}/{tip}")]
        [HttpPut]
        public async Task<ActionResult> IzmeniSobu(int idHotela,int brojSobe,string tip)
        {
            var hotel= await Context.Hoteli.FindAsync(idHotela);
            var soba= await Context.Sobe.Where(x=>x.BrojSobe==brojSobe).Include(p => p.Hotel).FirstAsync();
            
            if(soba.Zauzeta==false)
            {
                soba.tip=tip;
                Context.Sobe.Update(soba);
                await Context.SaveChangesAsync();
                return Ok("Izmenjena soba");
            }   
            
            else{
                return BadRequest("greska!");
            }
           

        }

       
        
        


       
    
    }   
}
using Microsoft.EntityFrameworkCore;

namespace hotel.Models
{
    public class HotelPrContext : DbContext
    {
        
        public DbSet<Hotel> Hoteli { get; set; } //svaka klasa koja se kreira u bazi mora ovako da se poveze

        public DbSet<Soba> Sobe { get; set; }

        public DbSet<Gost> Gosti { get; set; }

        public DbSet<Racun> Racuni { get; set; }

        public DbSet<GostuSobi> GostuSobi{get;set;}

        

        public HotelPrContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
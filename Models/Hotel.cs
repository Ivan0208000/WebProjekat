using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv { get; set; }

          [Column("Grad")]
        [MaxLength(255)]
        public string Grad { get; set; }
        
        [Column("Adresa")]
        [MaxLength(255)]
        public string Adresa { get; set; }

         [Column("BrojSoba")]
        [MaxLength(255)]
        public int BrojSoba{get;set;}

        public virtual List<Soba> Sobe { get; set; }

        public Hotel()
        {
          Sobe=new List<Soba>();
        }
        public virtual List<Gost> Gosti{get;set;}
        public virtual List<Racun> Racuni { get; set; }

        
    }
}
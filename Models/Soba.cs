using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace hotel.Models
{
    [Table("Soba")]
    public class Soba
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("BrojSobe")]
        public int BrojSobe { get; set; }

        [Column("TipSobe")]
        public string tip { get; set; }

        [Column("BrojDana")]
        public int BrojDana {  get;set; }

        [Column("Zauzeta")]
        public bool Zauzeta { get; set; }

        [JsonIgnore]
        public virtual Hotel Hotel { get; set; }

    
        


    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace hotel.Models
{
    [Table("Racun")]
    public class Racun
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [JsonIgnore]
        public virtual Soba soba{get;set;}


        [Column("KonacnaCena")]
        public int KonacnaCena { get; set; }

        [JsonIgnore]
        public virtual Hotel Hotel { get; set; }
    }
}
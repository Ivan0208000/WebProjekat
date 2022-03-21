using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using hotel.Models;
using System;

namespace hotel.Models
{
    [Table ("GostuSobi")]
    public class GostuSobi
    {
        [Key]
        [Column ("ID")]
        public int ID { get; set; }

        
        [JsonIgnore]
        public  virtual Soba Soba { get; set; }

       
        [JsonIgnore]
        public virtual Gost Gost { get; set; }

         [Column("DatumPrijaljivanja")]
        public string DatumPrijaljivanja{get;set;}

        

    

        




    }


}

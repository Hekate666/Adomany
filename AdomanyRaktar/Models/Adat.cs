using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace AdomanyRaktar.Models
{
    public class Adat
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string Adomany { get; set; }
        [StringLength(60)]
        public string Kategoria { get; set; }
        [StringLength(30)]
        public string Csomegyseg { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Mennyiseg { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire5._1
{
    class Statistique
    {
        [Key]
        public int StatistiqueID { get; set; }
        
        [Required]
        [StringLength(50)]
        public String NomPersonnage { get; set; }
        public int Vie { get; set; }
        public int NbAttaque { get; set; }
        public int NbDeplacement { get; set; }
        public int NbEnnemieTue { get; set; }
        public long DureeEnTicks { get; set; }

    }
}

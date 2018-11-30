using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire5._1
{
    class Personnage
    {
        [Key]
        public int PersonnageID { get; set; }

        [Required]
        [StringLength(50)]
        
        public String Nom { get; set; }

        public int Type { get; set; }

        public int VieTotal { get; set; }
        public int ManaTotal { get; set; }
        [Required]
        [StringLength(150)]
        public String ImagePath { get; set; }
    }
}

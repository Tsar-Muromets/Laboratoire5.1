using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire5._1
{
    class Attaque
    {
        [Key]
        public int AttaqueID { get; set; }
        [Required]
        [StringLength(50)]
        public String Nom { get; set; }
        public int Degats { get; set; }
        public int Mana { get; set; }
    }
}

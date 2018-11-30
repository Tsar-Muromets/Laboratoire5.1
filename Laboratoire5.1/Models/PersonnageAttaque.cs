using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire5._1
{
    class PersonnageAttaque
    {
        public int PersonnageID { get; set; }
        public virtual Personnage Personnage { get; set; }
        public int AttaqueID { get; set; }
        public virtual Attaque Attaque { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire5._1
{
    class Partie
    {
        [Key]
        public int PartieID { get; set; }
        public DateTime Date { get; set; }
    }
}

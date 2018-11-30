using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire5._1
{
    class Labo5DbContext : DbContext
    {
        public virtual DbSet<Attaque> Attaques { get; set; }
        public virtual DbSet<Partie> Parties { get; set; }
        public virtual DbSet<Personnage> Personnages { get; set; }
        public virtual DbSet<Statistique> Statistiques { get; set; }
    }
}

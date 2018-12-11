namespace Laboratoire5._1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Statistique")]
    public partial class Statistique
    {
        public int StatistiqueID { get; set; }

        [Required]
        [StringLength(50)]
        public string NomPersonnage { get; set; }

        public int Vie { get; set; }

        public int NbAttaque { get; set; }

        public int NbDeplacement { get; set; }

        public int NbEnnemieTue { get; set; }

        public long DureeEnTicks { get; set; }
    }
}

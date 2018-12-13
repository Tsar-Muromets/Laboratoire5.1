namespace Laboratoire5._1
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personnage")]
    public partial class Personnage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personnage()
        {
            Attaques = new ObservableCollection<Attaque>();
            Parties = new HashSet<Partie>();
        }

        public int PersonnageID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        public int Type { get; set; }

        public int VieTotal { get; set; }

        public int ManaTotal { get; set; }

        [Required]
        [StringLength(150)]
        public string ImagePath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Attaque> Attaques { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Partie> Parties { get; set; }
    }
}

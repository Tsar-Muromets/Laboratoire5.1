namespace Laboratoire5._1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attaque")]
    public partial class Attaque
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Attaque()
        {
            Personnages = new HashSet<Personnage>();
        }

        public int AttaqueID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        public int Degats { get; set; }

        public int Mana { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personnage> Personnages { get; set; }
    }
}

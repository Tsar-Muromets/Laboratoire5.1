namespace Laboratoire5._1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Labo5DbContext : DbContext
    {
        public Labo5DbContext()
            : base("name=Labo5DbContext")
        {
        }

        public virtual DbSet<Attaque> Attaques { get; set; }
        public virtual DbSet<Partie> Parties { get; set; }
        public virtual DbSet<Personnage> Personnages { get; set; }
        public virtual DbSet<Statistique> Statistiques { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attaque>()
                .HasMany(e => e.Personnages)
                .WithMany(e => e.Attaques)
                .Map(m => m.ToTable("PersonnageAttaque").MapLeftKey("AttaqueID").MapRightKey("PersonnageID"));

            modelBuilder.Entity<Partie>()
                .HasMany(e => e.Personnages)
                .WithMany(e => e.Parties)
                .Map(m => m.ToTable("PersonnagePartie").MapLeftKey("PartieID").MapRightKey("PersonnageID"));

            modelBuilder.Entity<Personnage>()
                .Property(e => e.Nom)
                .IsUnicode(false);
        }
    }
}

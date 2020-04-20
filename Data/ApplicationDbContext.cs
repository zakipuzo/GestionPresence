using System;
using System.Collections.Generic;
using System.Text;
using GestionPresence.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionPresence.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            
            modelBuilder.Entity<AppUser>()
                .HasIndex(b => b.CodeRFID)
                .IsUnique();


/// Ne pas avoir deux filiere avec le meme nom dans un niveau
             modelBuilder.Entity<Filiere>()
                .HasIndex(f=> new{f.Libelle,f.NiveauId})
                .IsUnique();

/// Une Annee Solaire a des niveau unique
             modelBuilder.Entity<Niveau>()
                .HasIndex(f=> new{f.Numero,f.AnneeUniversitaireId})
                .IsUnique();


/// filiere et la matiere est unique
   modelBuilder.Entity<FiliereMatiere>()
                .HasIndex(n =>new{ n.FiliereId,n.MatiereId})
                .IsUnique();          


///  la présence est enregistré une seule fois par seance
              modelBuilder.Entity<Presence>()
                .HasIndex(n =>new{ n.InscriptionId,n.SeanceId})
                .IsUnique();   


/// 
 modelBuilder.Entity<Inscription>()
                .HasIndex(f=> new{f.AnneeUniversitaireId,f.EtudiantId})
                .IsUnique();
              base.OnModelCreating(modelBuilder);

              

 modelBuilder.Entity<Groupe>()
                .HasIndex(f=> new{f.FiliereId,f.Numero})
                .IsUnique();
              base.OnModelCreating(modelBuilder);


               modelBuilder.Entity<Salle>()
                .HasIndex(f=> new{f.EcoleSiteId,f.Libelle})
                .IsUnique();

                   modelBuilder.Entity<Salle>()
                .HasIndex(f=>f.CodePointeur)
                .IsUnique();

                  modelBuilder.Entity<EcoleSite>()
                .HasIndex(f=>f.Libelle)
                .IsUnique();

              base.OnModelCreating(modelBuilder);

        }


        public DbSet<AppUser> AppUSers { get; set; }

        public DbSet<AnneeUniversitaire> AnneeUniversitaires { get; set; }

          public DbSet<Niveau> Niveaux { get; set; }

        public DbSet<Filiere> Filieres { get; set; }

        public DbSet<Matiere> Matieres { get; set; }

         public DbSet<FiliereMatiere> FiliereMatieres { get; set; }

        public DbSet<Groupe> Groupes { get; set; }

        public DbSet<Inscription> Inscriptions { get; set; }

      public DbSet<EcoleSite> EcoleSites { get; set; }

         public DbSet<Salle> Salles { get; set; }

        public DbSet<Seance> Seances { get; set; }

         public DbSet<Presence> Presences { get; set; }

       


    }
}

using System;
using Adneom.Distributeur.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adneom.Distributeur.Infrastucture.Data
{
    public class DistruputionContext : DbContext
    {
        public DistruputionContext(DbContextOptions<DistruputionContext> options) : base(options)
        {
        }
        public DbSet<BoissonType> BoissonType { get; set; }
        public DbSet<Commande> Commande { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<BoissonType>(ConfigureBoissonType);
            builder.Entity<Commande>(ConfigureCommande);

        }

        private void ConfigureBoissonType(EntityTypeBuilder<BoissonType> entity)
        {

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .ValueGeneratedNever();

            entity.Property(e => e.DescriptionType)
                .HasMaxLength(50)
                .IsUnicode(false);

        }

        private void ConfigureCommande(EntityTypeBuilder<Commande> entity)
        {
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .ValueGeneratedNever();

            entity.Property(e => e.DateComande).HasColumnType("datetime");

            entity.Property(e => e.IdTypeBoisson)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Mug).IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false); ;

            entity.HasOne(d => d.IdTypeBoissonNavigation)
                .WithMany(p => p.Commande)
                .HasForeignKey(d => d.IdTypeBoisson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Commande_BoissonType");

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week8.Core.Models;

namespace Week8.RepositoryEntityFramework
{
    internal class StudenteConfiguration : IEntityTypeConfiguration<Studente>
    {
        public void Configure(EntityTypeBuilder<Studente> builder)
        {
            builder.ToTable("Studente");
            builder.HasKey(k => k.ID);
            builder.Property(n => n.Nome);
            builder.Property(c => c.Cognome);
            builder.Property(d => d.DataDiNascita);
            builder.Property(e => e.Email);
            builder.Property(t => t.TitoloDiStudio);

            //Relazione 1 a molti tra studente e corso
            builder.HasOne(c => c.Corso)
                   .WithMany(s => s.Studenti)
                   .HasForeignKey(c => c.CodiceCorso)
                   .HasConstraintName("FK_Codice Corso");


        }
    }
}
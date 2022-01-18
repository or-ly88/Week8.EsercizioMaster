using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week8.Core.Models;

namespace Week8.RepositoryEntityFramework
{
    internal class LezioneConfiguration : IEntityTypeConfiguration<Lezione>
    {
        public void Configure(EntityTypeBuilder<Lezione> builder)
        {
            builder.ToTable("Lezione");
            builder.HasKey(k => k.LezioneID);
            builder.Property(d => d.DataOraInizio);
            builder.Property(d => d.Durata);
            builder.Property(a => a.Aula);

            ////Relazione 1 a molti tra lezione e corso
            builder.HasOne(c => c.Corso)
                   .WithMany(l => l.Lezioni)
                   .HasForeignKey(c => c.CodiceCorso);
                  

            //Relazione 1 a molti tra lezione e docente
            builder.HasOne(d => d.Docente)
                   .WithMany(l => l.Lezioni)
                   .HasForeignKey(d => d.DocenteId)
                   .HasConstraintName("FK_Docente ID");
        }
    }
}
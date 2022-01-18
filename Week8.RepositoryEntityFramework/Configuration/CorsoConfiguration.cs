using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week8.Core.Models;

namespace Week8.RepositoryEntityFramework
{
    internal class CorsoConfiguration : IEntityTypeConfiguration<Corso>
    {
        public void Configure(EntityTypeBuilder<Corso> builder)
        {
            builder.ToTable("Corso");
            builder.HasKey(k => k.CodiceCorso);
            builder.Property(n => n.Nome);
            builder.Property(d => d.Descrizione);

            //relazione 1 a molti tra corso e studenti
            builder.HasMany(s => s.Studenti)
                   .WithOne(c => c.Corso);

            //relazione 1 a molti tra corso e lezione
            builder.HasMany(l => l.Lezioni)
                   .WithOne(c => c.Corso);

        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week8.Core.Models;

namespace Week8.RepositoryEntityFramework
{
    internal class DocenteConfiguration : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> builder)
        {
            builder.ToTable("Docente");
            builder.HasKey(k => k.ID);
            builder.Property(n => n.Nome);
            builder.Property(c => c.Cognome);
            builder.Property(e => e.Email);
            builder.Property(n => n.NumeroDiTelefono);

            //relazione 1 a molti tra docente e lezione
            builder.HasMany(l => l.Lezioni)
                   .WithOne(d => d.Docente);

        }
    }
}
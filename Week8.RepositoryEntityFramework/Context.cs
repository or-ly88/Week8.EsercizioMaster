using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Core.Models;

namespace Week8.RepositoryEntityFramework
{
    public class Context :DbContext
    {
        //Elenco i Dbset ovvero le tabelle/entità in gioco
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Lezione> Lezioni { get; set; }
        public DbSet<Docente> Docenti { get; set; }

        //costruttore vuoto
        public Context() 
        { 
        
        }

        //costruttore con option
        public Context(DbContextOptions<Context> options) : base(options)
        { 

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
        optionBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CorsoMasterEF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Partecipante
            modelBuilder.ApplyConfiguration<Corso>(new CorsoConfiguration());
            //Gita
            modelBuilder.ApplyConfiguration<Studente>(new StudenteConfiguration());
            //Itinerario
            modelBuilder.ApplyConfiguration<Lezione>(new LezioneConfiguration());
            //Responsabile
            modelBuilder.ApplyConfiguration<Docente>(new DocenteConfiguration());


        }
    }
}

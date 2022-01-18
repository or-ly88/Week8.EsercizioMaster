using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.Core.Models
{
    public class Corso
    {
        public int CodiceCorso { get; set; }

        public string Nome { get; set; }

        public string Descrizione { get; set; }

        //Collection di studente
        public ICollection<Studente> Studenti { get; set; } = new List<Studente>();

        //Collection di Lezione
        public ICollection<Lezione> Lezioni { get; set; } = new List<Lezione>();

        //override del ToString
        public override string ToString()
        {
            return $"{CodiceCorso} - {Nome} - {Descrizione}";
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.Core.Models
{
    public class Docente : Persona
    {
        public string NumeroDiTelefono { get; set; }

        public ICollection<Lezione> Lezioni { get; set; } = new List<Lezione>();

        ////fk verso corso
        public string CodiceCorso  {get;set;}
        public Corso Corso { get; set; }

         public override string ToString()
         { 
           return base.ToString() + $"Telefono: {NumeroDiTelefono}";
         }
    }
}

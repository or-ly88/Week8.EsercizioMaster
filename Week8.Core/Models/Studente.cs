using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.Core.Models
{
    public class Studente :Persona
    {
        public DateTime DataDiNascita { get; set; }

        public string TitoloDiStudio { get; set; }

        //FK verso corso
        public string CodiceCorso { get; set; }

        //navigation property
        public Corso Corso { get; set; }

      

        //override del to string
        public override string ToString()
        {
            return base.ToString()+ $"nato il: {DataDiNascita.ToShortDateString()} - TitoloDiStudio{TitoloDiStudio}";

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.Core.Models
{
    public class Lezione
    {
        public int LezioneID { get; set; }
        public DateTime DataOraInizio { get; set; }
        public int Durata { get; set; }

        
        public string Aula { get; set; }

        //Fk verso Docente
        public int DocenteId { get; set; }
        //Navigation property
        public Docente Docente { get; set; }

        //Fk verso Corso
        public int CodiceCorso { get; set; }
        //NAvigation property
        public Corso Corso { get; set; }

        //public override del ToString
        public override string ToString()
        {
            return $"Lezione: {LezioneID} - Dta: {DataOraInizio} - Aula: {Aula} - Duarata in gg: {Durata} ";
        }
    }
}

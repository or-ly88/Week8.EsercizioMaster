using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Core.Models;

namespace Week8.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        public List<Corso> GetAllCorsi();
        public Esito AddNuovoCorso(Corso nuovoCorso);
        Esito ModificaCorso(string? codice, string? nuovoNome, string? nuovaDescrizione);
        Esito RimuoviCorso(string? codice);
        List<Studente> GetAllStudenti();
        Esito AddNuovoStudente(Studente nuovoStudente);
        Esito ModificaEmailStudente(string? nome, string? cognome, string? email);
        Esito RimuoviStudente(string? nome,string? cognome, string? eamil,DateTime? dataDiNascita,string? titoloDiStudio);
        List<Docente> GetAllDocenti();
    }
}

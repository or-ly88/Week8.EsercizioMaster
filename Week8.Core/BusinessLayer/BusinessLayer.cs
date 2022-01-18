using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Core.InterfaceRepositories;
using Week8.Core.Models;

namespace Week8.Core.BusinessLayer
{
    //classe che implementa l'interfaccia IBusinessLayer
    public class BusinessLayer : IBusinessLayer
    {
        //proprietà di questa classe
        private readonly IRepositoryCorsi corsiRepo;
        private readonly IRepositoryStudenti studentiRepo;
        private readonly IRepositoryDocenti docentiRepo;
        
        //costruttore
        public BusinessLayer(IRepositoryCorsi corsi,IRepositoryStudenti studenti,IRepositoryDocenti docenti)
        {
            corsiRepo = corsi;
            studentiRepo = studenti;
            docentiRepo = docenti;
            
        }

       



        public Esito AddNuovoCorso(Corso nuovoCorso)
        {
            //controllo se il codice che ha inserito l'utente già esite
            //prendo tutti i corsi e filtro 
            //corsiRepo.Getall().FirstOrDefault(c => c.CodiceCorso == nuovoCorso.CodiceCorso);
            //oppure sfruttare il GetByCode:ricerco tra tuti i corsi quello che ha quel codice
            //memorizzo in una variabile corsoEsistente
            Corso corsoEsistente=corsiRepo.GetByCode(nuovoCorso.Nome);
            //aggiungo un controllo
            if (corsoEsistente == null)
            {
                corsiRepo.Add(nuovoCorso);
                return new Esito { Messaggio = "Corso aggiunto correttamente", isOk = true };
            }
            else 
            {
                return new Esito { Messaggio = "Impossibile aggiungere il corso perché già esiste", isOk = false };
            }

            
            
        }

        public Esito AddNuovoStudente(Studente nuovoStudente)
        {
            //controllo se il codice che ha inserito l'utente già esite
            //prendo tutti i corsi e filtro 
            //studentiRepo.Getall().FirstOrDefault(s => s.ID == nuovoStudente.ID);
            //oppure sfruttare il GetByCode:ricerco tra tutti gli studenti quello che ha quel codice
            //memorizzo in una variabile studenteEsistente
            Studente studenteEsistente = studentiRepo.GetById(nuovoStudente.ID);
            //aggiungo un controllo
            if (studenteEsistente == null)
            {
                studentiRepo.Add(nuovoStudente);
                return new Esito { Messaggio = "Studente aggiunto correttamente", isOk = true };
            }
            else
            {
                return new Esito { Messaggio = "Impossibile aggiungere lo studente perché già esiste", isOk = false };
            }
        }

        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.Getall().ToList();
        }

        public List<Docente> GetAllDocenti()
        {
            throw new NotImplementedException();
        }

        public List<Studente> GetAllStudenti()
        {
            return studentiRepo.Getall().ToList();
        }

        public Esito ModificaCorso(string? codice, string? nuovoNome, string? nuovaDescrizione)
        {
            var corsoEsistente=corsiRepo.GetByCode(codice);
            if (corsoEsistente == null)
            {
                return new Esito { Messaggio = "Non esiste nessun corso con il codice inseririto", isOk = false };
                
            }
            else 
            {
                corsoEsistente.Nome = nuovoNome;
                corsoEsistente.Descrizione = nuovaDescrizione;

                corsiRepo.Update(corsoEsistente);
                return new Esito { Messaggio = "Corso modificato correttamente", isOk = true };
            }
        }

        public Esito ModificaEmailStudente(string? nome, string? cognome, string? email)
        {
            throw new NotImplementedException();
        }

        public Esito RimuoviCorso(string? codice)
            {
                var corsoEsistente = corsiRepo.GetByCode(codice);
                if (corsoEsistente == null)
                {
                    return new Esito { Messaggio = "Non esiste nessun corso con il codice inseririto", isOk = false };

                }
                else
                {
                    corsiRepo.Delete(corsoEsistente);
                    return new Esito { Messaggio = "Corso eliminato correttamente", isOk = true };
                }

            }

        public Esito RimuoviStudente(string? nome, string? cognome, string? eamil, DateTime? dataDiNascita, string? titoloDiStudio)
        {
            var studenteEsistente = studentiRepo.GetById(1);
            if (studenteEsistente == null)
            {
                return new Esito { Messaggio = "Non esiste nessuno studente conl'id inseririto", isOk = false };

            }
            else
            {
                studentiRepo.Delete(studenteEsistente);
                return new Esito { Messaggio = "Studente eliminato correttamente", isOk = true };
            }

        }
    }
}

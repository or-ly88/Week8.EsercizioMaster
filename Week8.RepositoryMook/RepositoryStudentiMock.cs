using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Core.InterfaceRepositories;
using Week8.Core.Models;

namespace Week8.RepositoryMock
{
    public class RepositoryStudentiMock : IRepositoryStudenti
    {
        public static List<Studente> Studenti = new List<Studente>()
        {
         new Studente{ID=1,Nome="Orsola",Cognome= "Liccardo",Email="or.liccardo@libero.it",DataDiNascita=new DateTime(1988/11/30),TitoloDiStudio="Laurea Magistrale"},
         new Studente{ID=2,Nome="Marco",Cognome= "Rossi",Email="m.rossi@libero.it",DataDiNascita=new DateTime(1991/05/09),TitoloDiStudio="Laurea Triennale"},
        };
        public Studente Add(Studente item)
        {
            Studenti.Add(item);
            return item;

           
                if (Studenti.Count == 0)
                {
                    item.ID = 1;
                }
                else //se la lista è piena trova l'id più alto e,
                     //dopo aver incrementato di 1, lo assegna ad item
                {
                    int maxId = 1;
                    foreach (var s in Studenti)
                    {
                        if (s.ID > maxId)
                        {
                            maxId = s.ID;
                        }
                    }
                    item.ID = maxId + 1;
                }
                Studenti.Add(item);
                return item;
            
        }

        public bool Delete(Studente item)
        {
            Studenti.Remove(item);
            return true;
        }

        public IList<Studente> Getall()
        {
            return Studenti;//mi ritorna la lista studenti corsi definita sopra
        }

        public Studente GetById(int id)
        {
            return Studenti.FirstOrDefault(s => s.ID == id);
        }

       

        public Studente Update(Studente item)
        {
            foreach (var s in Studenti)
            {
                if (s.ID == item.ID)
                {
                    s.ID = item.ID;
                    s.Nome = item.Nome;
                    s.Cognome = item.Cognome;
                    s.Email = item.Email;
                    s.DataDiNascita = item.DataDiNascita;
                    s.TitoloDiStudio = item.TitoloDiStudio;
                    return s;
                }

            }
            return null;
        }
    }
}

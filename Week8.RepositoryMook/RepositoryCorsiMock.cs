using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Core.InterfaceRepositories;
using Week8.Core.Models;

namespace Week8.RepositoryMock
{
    public class RepositoryCorsiMock : IRepositoryCorsi
    {
        public static List<Corso> Corsi = new List<Corso>()
        {
         new Corso{CodiceCorso="C-01",Nome="Pre-AcademyA",Descrizione= "corso base"},
         new Corso{CodiceCorso="C-02",Nome="AcademyA",Descrizione= "corso avanzato"},
        };

        public Corso Add(Corso item)
        {
            Corsi.Add(item);
            return item;
        }

        public bool Delete(Corso item)
        {
            Corsi.Remove(item);
            return true;
        }

        public IList<Corso> Getall()
        {
            return Corsi;//mi ritorna la lista corsi definita sopra
        }

        public Corso GetByCode(string codice)
        {
            return Corsi.FirstOrDefault(c => c.CodiceCorso == codice);
        }

        public Corso Update(Corso item)
        {
            foreach (var c in Corsi)
            {
                if (c.CodiceCorso == item.CodiceCorso)
                {
                    c.Nome = item.Nome;
                    c.Descrizione = item.Descrizione;
                    return c;
                }

            }
            return null;
        }
    }
}

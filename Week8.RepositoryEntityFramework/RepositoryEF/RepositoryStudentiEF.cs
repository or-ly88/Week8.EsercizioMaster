using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Core.InterfaceRepositories;
using Week8.Core.Models;

namespace Week8.RepositoryEntityFramework.RepositoryEF
{
    public class RepositoryStudentiEF : IRepositoryStudenti
    {
        public Studente Add(Studente item)
        {
            using (var ctx = new Context())
            {
                ctx.Studenti.Add(item);
                ctx.SaveChanges();

            }
            return item;
        }

        public bool Delete(Studente item)
        {
            using (var ctx = new Context())
            {
                ctx.Studenti.Remove(item);
                ctx.SaveChanges();

            }
            return true;
        }

        public IList<Studente> Getall()
        {
            using (var ctx = new Context())
            {
                return ctx.Studenti.ToList();
            }
        }

        public Studente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Studente Update(Studente item)
        {
            throw new NotImplementedException();
        }
    }
}

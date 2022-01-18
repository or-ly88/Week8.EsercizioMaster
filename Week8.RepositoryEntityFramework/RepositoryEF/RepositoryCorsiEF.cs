using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Core.InterfaceRepositories;
using Week8.Core.Models;

namespace Week8.RepositoryEntityFramework.RepositoryEF
{
    public class RepositoryCorsiEF : IRepositoryCorsi
    {
        public Corso Add(Corso item)
        {
            using (var ctx = new Context())
            {
                ctx.Corsi.Add(item);
                ctx.SaveChanges();

            }
            return item;
        }

        public bool Delete(Corso item)
        {
            using (var ctx = new Context())
            {
                ctx.Corsi.Remove(item);
                ctx.SaveChanges();

            }
            return true;
        }

        public IList<Corso> Getall()
        {
            using (var ctx = new Context())
            {
                return ctx.Corsi.ToList();
            }
           // return ctx.Corsi.Iclude(c => c.Studenti).Include(c => c.Studenti);
        }

        public Corso GetByCode(string codice)
        {
            throw new NotImplementedException();
        }

        public Corso Update(Corso item)
        {
            using (var ctx = new Context())
            {
                ctx.Corsi.Update(item);
                ctx.SaveChanges();

            }
            return item;
        }
    }
}

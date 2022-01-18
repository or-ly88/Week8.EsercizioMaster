using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Core.InterfaceRepositories;
using Week8.Core.Models;

namespace Week8.RepositoryEntityFramework.RepositoryEF
{
    public class RepositoryDocentiEF : IRepositoryDocenti
    {
       

        public Docente Add(Docente item)
        {
            throw new NotImplementedException();
        }

        

        public bool Delete(Docente item)
        {
            throw new NotImplementedException();
        }

        

        public Docente GetById(int id)
        {
            throw new NotImplementedException();
        }

       

        public Docente Update(Docente item)
        {
            throw new NotImplementedException();
        }

        IList<Docente> IRepository<Docente>.Getall()
        {
            throw new NotImplementedException();
        }
    }
}

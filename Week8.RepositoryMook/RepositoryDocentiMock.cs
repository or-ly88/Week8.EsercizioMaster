using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Core.InterfaceRepositories;
using Week8.Core.Models;
using Week8.RepositoryEntityFramework.RepositoryEF;

namespace Week8.RepositoryMock
{
    public class RepositoryDocentiMock : IRepositoryDocenti
    {
        public Lezione Add(Lezione item)
        {
            throw new NotImplementedException();
        }

        public Docente Add(Docente item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Lezione item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Docente item)
        {
            throw new NotImplementedException();
        }

        public IList<Lezione> Getall()
        {
            throw new NotImplementedException();
        }

        public Docente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Lezione Update(Lezione item)
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

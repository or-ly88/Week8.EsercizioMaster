using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8.Core.Models;

namespace Week8.Core.InterfaceRepositories
{
    public interface IRepositoryStudenti : IRepository<Studente>
    {
        //oltre ai metodi dell IRepository generico, posso aggiungere altri metodi
        public Studente GetById(int id);
        Studente Update(Studente item);
    }
}

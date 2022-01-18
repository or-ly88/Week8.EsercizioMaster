using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.Core.InterfaceRepositories
{
    public interface IRepository<T>
    {
        //operazioni in comune o operazioni di base a tutte le entità\models,in genere sono le CRUD
        public IList<T> Getall();
        public T Add(T item);
        public T Update(T item);
        public bool Delete(T item);
    
    }
}

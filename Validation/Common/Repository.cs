using System.Collections.Generic;
using System.Linq;
using DataValidation.Models;

namespace DataValidation.Common
{
    public class Repository<T>: List<T>, ICollection<T> where T: IEntity
    {
        public T Get(int id)
        {
            return this.FirstOrDefault(x => x.Id == id);
        }

        void ICollection<T>.Add(T item)
        {
            item.Id = Count + 1;
            Add(item);
        }

    }
}
using System.Collections.Generic;
using DataValidation.Models;

namespace DataValidation.Common
{
    public interface ICustomerRepository: ICollection<Customer>
    {
        Customer Get(int id);
    }
}
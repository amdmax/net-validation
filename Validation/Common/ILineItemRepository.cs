using System.Collections.Generic;
using DataValidation.Models;

namespace DataValidation.Common
{
    public interface ILineItemRepository: ICollection<LineItem>
    {
        LineItem Get(int id);
    }
}
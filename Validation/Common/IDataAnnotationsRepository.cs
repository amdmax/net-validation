using System.Collections.Generic;
using DataValidation.Models;

namespace DataValidation.Common
{
    public interface IDataAnnotationsRepository: ICollection<DataAnnotation>
    {
        DataAnnotation Get(int id);
    }
}
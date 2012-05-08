using System;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace DataValidation.Models
{
    public class DataAnnotation: IEntity
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Email]
        public string Email { get; set; }

        public int Id { get; set; }
    }
}
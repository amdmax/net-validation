using System.Collections.Generic;
using System.ComponentModel;

namespace DataValidation.Models
{
    public class Customer: IEntity, IDataErrorInfo
    {
        private readonly Dictionary<string,string> _errors = new Dictionary<string, string>();

        private string _email;
        
        public string Email
        {
            get { return _email; }
            set
            {
                if (!value.Contains("@"))
                    _errors["Email"] = "Email has to contain @ char";

                _email = value;
            }
        }

        public int Id { get; set; }

        public string this[string columnName]
        {
            get { return _errors.ContainsKey(columnName) ? _errors[columnName] : string.Empty; }
        }

        public string Error
        {
            get { return string.Empty; }
        }
    }
}
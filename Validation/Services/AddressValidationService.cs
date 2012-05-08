using System;

namespace DataValidation.Services
{
    public class AddressValidationService : IAddressValidationService
    {
        public bool IsValidAddress(string address)
        {
            Random random = new Random();
            var value = random.Next(1);

            // we can have an HTTP connection to goole maps here and so on to get this value
            return value > 0;
        }
    }
}
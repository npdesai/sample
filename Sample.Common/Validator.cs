using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sample.Common
{
    public static class Validator
    {
        public static bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(email);
        }

        public static bool ValidatePhone(string phone)
        {
            Regex regex = new Regex(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(phone);
        }

        public static bool ValidateString(string name)
        {
            Regex regex = new Regex(@"^([\sA-Za-z]+)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(name);
        }
    }
}

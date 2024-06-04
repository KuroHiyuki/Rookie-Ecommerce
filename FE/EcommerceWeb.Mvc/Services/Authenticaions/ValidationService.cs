using System.Net.Mail;
using System.Text.RegularExpressions;

namespace EcommerceWeb.Mvc.Services.Authenticaions
{
    public class ValidationService
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            return Regex.IsMatch(phoneNumber, @"^0[0-9]{9}$");
        }

        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            return Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^\w\s]).{8,}$");
        }
    }
}

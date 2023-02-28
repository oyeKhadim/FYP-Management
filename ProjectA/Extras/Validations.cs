using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Extras
{
    public static class Validations
    {
        public static bool isNumber(string str)
        {
            //this funtion returns true if str consists of only digits
            bool flag = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (!(str[i] >= '0' && str[i] <= '9'))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public static bool IsValidEmail(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
    }
}

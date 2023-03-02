using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static bool validateTextBox(TextBox control, ErrorProvider errorProvider)
        {
            if (String.IsNullOrEmpty(control.Text))
            {
                errorProvider.SetError(control, "This Field cannot be Empty");
                return false;
            }
            else
            {
                errorProvider.SetError(control, null);
                return true;
            }
        }
        public static bool validateIntTextBox(TextBox control, ErrorProvider errorProvider)
        {
            if (!isNumber(control.Text))
            {
                errorProvider.SetError(control, "This Field only consists of digits");
                return false;

            }
            else
            {
                errorProvider.SetError(control, null);
                return true;

            }
        }
        public static bool validateEmailTextBox(TextBox control, ErrorProvider errorProvider)
        {
            if (!IsValidEmail(control.Text))
            {
                errorProvider.SetError(control, "Enter Valid Email Address");
                return false;

            }
            else
            {
                errorProvider.SetError(control, null);
                return true;

            }
        }
    }
}

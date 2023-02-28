using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.BL
{
    public class Student : Person
    {
        private string registrationNo;
        public Student() { }
        public Student(string registrationNo, int id, string firstName, string lastName, string contact, string email, int gender, string dateOfBirth) : base(id, firstName, lastName, contact, email, gender, dateOfBirth)
        {
            this.RegistrationNo = registrationNo;
        }

        public string RegistrationNo { get => registrationNo; set => registrationNo = value; }
    }
}

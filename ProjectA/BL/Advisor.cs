using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.BL
{
    public class Advisor : Person
    {
        private int designation;
        private int salary;
        public Advisor() { }
        public Advisor(int designation, int salary, int id, string firstName, string lastName, string contact, string email, int gender, string dateOfBirth) : base(id, firstName, lastName, contact, email, gender, dateOfBirth)
        {
            this.designation = designation;
            this.salary = salary;
        }

        public int Designation { get => designation; set => designation = value; }
        public int Salary { get => salary; set => salary = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.BL
{
    public class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        private string contact;
        private string email;
        private string dateOfBirth;
        private int gender;
        public Person() { }
        public Person(int id, string firstName, string lastName, string contact, string email, int gender, string dateOfBirth)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Contact = contact;
            this.Email = email;
            this.Gender = gender;
            this.dateOfBirth = dateOfBirth;

        }

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Email { get => email; set => email = value; }
        public int Gender { get => gender; set => gender = value; }
        public string DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
    }
}

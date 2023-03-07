using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
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
        public static int retrieveId()
        {
            //Getting latest autoincremented id
            SqlConnection con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select MAX(id) from Person", con);
            return (Int32)cmd.ExecuteScalar();
        }
        public static int addPerson(Person person)
        {
            //Adding data in person table
            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();
            cmd = new SqlCommand("Insert into Person values (@firstName, @lastName, @contact,@email,@dob,@gender)", con);
            cmd.Parameters.AddWithValue("@firstName", person.FirstName);
            //inserting null values in database if user has not provided full informations
            if (person.LastName == "")
            {
                cmd.Parameters.AddWithValue("@lastName", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@lastName", person.LastName);
            }
            if (person.Contact == "")
            {
                cmd.Parameters.AddWithValue("@contact", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@contact", person.Contact);
            }
            cmd.Parameters.AddWithValue("@email", person.Email);
            if (person.DateOfBirth != null) 
            {
                cmd.Parameters.AddWithValue("@dob", person.DateOfBirth);
            }
            else
            {
                cmd.Parameters.AddWithValue("@dob", DBNull.Value);

            }
            if (person.Gender == -1)
            {
                cmd.Parameters.AddWithValue("@gender", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@gender", person.Gender);
            }
            cmd.ExecuteNonQuery();
            //getting id of person which is auto genrated on above entry 
            return Person.retrieveId();
        }

        public static void updatePerson(Person person)
        {
            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();
            cmd = new SqlCommand("Update Person SET firstName=@firstName, lastName=@lastName, contact=@contact,email=@email,dateofbirth=@dob,gender=@gender where id=@id", con);
            cmd.Parameters.AddWithValue("@firstName", person.FirstName);
            cmd.Parameters.AddWithValue("@id", person.Id);
            //inserting null values in database if user has not provided full informations
            if (person.LastName == "")
            {
                cmd.Parameters.AddWithValue("@lastName", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@lastName", person.LastName);
            }
            if (person.Contact == "")
            {
                cmd.Parameters.AddWithValue("@contact", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@contact", person.Contact);
            }
            cmd.Parameters.AddWithValue("@email", person.Email);
            if (person.DateOfBirth != null)
            {
                cmd.Parameters.AddWithValue("@dob", person.DateOfBirth);
            }
            else
            {
                cmd.Parameters.AddWithValue("@dob", DBNull.Value);

            }
            if (person.Gender == -1)
            {
                cmd.Parameters.AddWithValue("@gender", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@gender", person.Gender);
            }
            cmd.ExecuteNonQuery();
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

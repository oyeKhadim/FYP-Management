using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectA.BL
{
    public class Project
    {
        private int id;
        private string title;
        private string description;
        public Project() { }
        public Project(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
    
        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public static DataTable searchWithTitle(string search)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                //SqlCommand cmd = new SqlCommand("Select * from Project where title LIKE '%'+@search+'%'", con);
                SqlCommand cmd = new SqlCommand("select p.id,p.Title,p.Description,\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Main Advisor' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Main Advisor],\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Co-Advisror' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Co-Advisror],\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Industry Advisor' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Industry Advisor]\r\nfrom Project p  where title LIKE '%'+@search+'%'", con);
                cmd.Parameters.AddWithValue("@search", search);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            return null;
        }

        internal static DataTable loadProjects()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                //SqlCommand cmd = new SqlCommand("Select * from Project", con);
                SqlCommand cmd = new SqlCommand("select p.id,p.Title,p.Description,\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Main Advisor' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Main Advisor],\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Co-Advisror' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Co-Advisror],\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Industry Advisor' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Industry Advisor]\r\nfrom Project p", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                return null;
            }
        }
    }
}

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
                SqlCommand cmd = new SqlCommand("select p.id,p.Title,p.Description,  (  select pe.FirstName+' '+pe.LastName  from ProjectAdvisor pa  join Person pe  on pe.Id=pa.AdvisorId  join Lookup l  on l.Id=pa.AdvisorRole  where l.Value='Main Advisor'   and p.Id=pa.ProjectId  )[Main Advisor],  (  select pe.FirstName+' '+pe.LastName  from ProjectAdvisor pa  join Person pe  on pe.Id=pa.AdvisorId  join Lookup l  on l.Id=pa.AdvisorRole  where l.Value='Co-Advisror'   and p.Id=pa.ProjectId  )[Co-Advisror],  (  select pe.FirstName+' '+pe.LastName  from ProjectAdvisor pa  join Person pe  on pe.Id=pa.AdvisorId  join Lookup l  on l.Id=pa.AdvisorRole  where l.Value='Industry Advisor'   and p.Id=pa.ProjectId  )[Industry Advisor]  from Project p  where title LIKE '%'+@search+'%'", con);
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

        internal static void addProject(Project project)
        {
            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();

            cmd = new SqlCommand("Insert into project values ( @description,@title)", con);
            cmd.Parameters.AddWithValue("@title", project.Title);
            //inserting null values in database if user has not provided full informations
            if (project.Description == "")
            {
                cmd.Parameters.AddWithValue("@description", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@description", project.Description);
            }
            cmd.ExecuteNonQuery();
        }
        internal static void updateProject(Project project)
        {
            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();


            cmd = new SqlCommand("Update Project SET description=@description,title=@title where id=@id", con);
            cmd.Parameters.AddWithValue("@id", project.Id);
            cmd.Parameters.AddWithValue("@title", project.Title);
            //inserting null values in database if user has not provided full informations
            if (project.Description == "")
            {
                cmd.Parameters.AddWithValue("@description", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@description", project.Description);
            }
            cmd.ExecuteNonQuery();
        }
        internal static DataTable loadProjects()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                //SqlCommand cmd = new SqlCommand("Select * from Project", con);
                SqlCommand cmd = new SqlCommand("select p.id,p.Title,p.Description,  (  select pe.FirstName+' '+pe.LastName  from ProjectAdvisor pa  join Person pe  on pe.Id=pa.AdvisorId  join Lookup l  on l.Id=pa.AdvisorRole  where l.Value='Main Advisor'   and p.Id=pa.ProjectId  )[Main Advisor],  (  select pe.FirstName+' '+pe.LastName  from ProjectAdvisor pa  join Person pe  on pe.Id=pa.AdvisorId  join Lookup l  on l.Id=pa.AdvisorRole  where l.Value='Co-Advisror'   and p.Id=pa.ProjectId  )[Co-Advisror],  (  select pe.FirstName+' '+pe.LastName  from ProjectAdvisor pa  join Person pe  on pe.Id=pa.AdvisorId  join Lookup l  on l.Id=pa.AdvisorRole  where l.Value='Industry Advisor'   and p.Id=pa.ProjectId  )[Industry Advisor]  from Project p", con);
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

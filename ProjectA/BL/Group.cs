using ProjectA.Extras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectA.BL
{
    public class Group
    {
        private int id;
        private DateTime createdDate;

        public int Id { get => id; set => id = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }

        internal static DataTable loadGroups()
        {
            try
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from [group]", con);
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

        internal static DataTable loadStudentsOfGroup(string groupId)
        {
            SqlConnection con= Configuration.getInstance().getConnection();
            int status = LookupClass.findId("active", "status");
            SqlCommand cmd = new SqlCommand("select FirstName+' '+LastName Name,RegistrationNo,pr.Title [Assigned Project] from GroupStudent gs  left join GroupProject gp on gp.GroupId=gs.GroupId  left join Project pr  on pr.Id=gp.ProjectId  Join Student s on s.Id=StudentId join person P on s.Id=p.id    where gs.groupid =@groupId and status=@status", con);
            cmd.Parameters.AddWithValue("@groupId", groupId);
            cmd.Parameters.AddWithValue("@status", status);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}

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
    public class GroupProject
    {
        private int groupId;
        private int projectId;
        private DateTime assignmentDate;

        public int GroupId { get => groupId; set => groupId = value; }
        public int ProjectId { get => projectId; set => projectId = value; }
        public DateTime AssignmentDate { get => assignmentDate; set => assignmentDate = value; }

   

        internal void assignProject()
        {
            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();
            cmd = new SqlCommand("Insert into GroupProject values ( @projectId,@groupId,@date)", con);
            cmd.Parameters.AddWithValue("@projectId", this.ProjectId);
            cmd.Parameters.AddWithValue("@groupId", this.GroupId);
            cmd.Parameters.AddWithValue("@date", this.AssignmentDate);
            cmd.ExecuteNonQuery();
        }
    }
}

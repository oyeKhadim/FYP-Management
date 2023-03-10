
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Extras
{
    public class Report
    {
        public static DataTable detailsOfProjects()
        {
            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();
            string query = "select p.Title,\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Main Advisor' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Main Advisor],\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Co-Advisror' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Co-Advisror],\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Industry Advisor' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Industry Advisor],\r\n\t\ts.RegistrationNo,gs.GroupId\r\nfrom Project p\r\nJoin GroupProject gp\r\non p.Id=gp.ProjectId\r\nJoin GroupStudent gs\r\non gs.GroupId=gp.GroupId\r\nJoin Student s \r\non s.Id=gs.StudentId";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable markSheet()
        {
            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();
            string query = "select s.RegistrationNo,p.Title [Project Title],Sum(ge.ObtainedMarks)ObtainedMarks,Sum(e.TotalMarks)TotalMarks\r\nfrom GroupStudent gs\r\njoin Student s \r\non s.Id=gs.StudentId\r\njoin GroupEvaluation ge\r\non ge.GroupId=gs.GroupId\r\njoin Evaluation e\r\non e.Id=ge.EvaluationId\r\njoin GroupProject gp\r\non gp.GroupId=gs.GroupId\r\njoin Project p\r\non p.Id=gp.ProjectId\r\ngroup by gs.GroupId,s.RegistrationNo,p.Title";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}

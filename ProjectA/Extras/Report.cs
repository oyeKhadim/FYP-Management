
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
        public static DataTable detailsOfProjectsWithStudents()
        {
            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();
            string query = "select p.Title,\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Main Advisor' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Main Advisor],\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Co-Advisror' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Co-Advisror],\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Industry Advisor' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Industry Advisor],\r\n\t\ts.RegistrationNo\r\nfrom Project p\r\nJoin GroupProject gp\r\non p.Id=gp.ProjectId\r\nJoin GroupStudent gs\r\non gs.GroupId=gp.GroupId\r\nJoin Student s \r\non s.Id=gs.StudentId";
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

        internal static DataTable detailsOfProjects()
        {
            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();
            string query = "select p.Title,\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Main Advisor' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Main Advisor],\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Co-Advisror' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Co-Advisror],\r\n\t\t(\r\n\t\tselect pe.FirstName+' '+pe.LastName\r\n\t\tfrom ProjectAdvisor pa\r\n\t\tjoin Person pe\r\n\t\ton pe.Id=pa.AdvisorId\r\n\t\tjoin Lookup l\r\n\t\ton l.Id=pa.AdvisorRole\r\n\t\twhere l.Value='Industry Advisor' \r\n\t\tand p.Id=pa.ProjectId\r\n\t\t)[Industry Advisor]\r\nfrom Project p";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        internal static DataTable studentsAndAssignedProjects()
        {
            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();
            string query = "select Distinct FirstName+' '+LastName Name,RegistrationNo,p.Title [Assigned Project] \r\nfrom Student s\r\nLeft join GroupStudent gs\r\non s.Id =gs.StudentId\r\nleft join GroupProject gp\r\non gp.GroupId=gs.GroupId\r\nleft join Project p\r\non p.Id=gp.ProjectId\r\njoin person pr\r\non s.Id=pr.Id";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        internal static DataTable studentsBelowAverageMarks()
        {
            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();
            string query = "SELECT p.FirstName+' '+p.LastName Name,S.RegistrationNo,\r\n(SELECT SUM(ObtainedMarks) FROM GroupEvaluation E WHERE E.GroupId=GE.GroupId)[Obtained Marks]\r\nFROM Student S \r\nJoin Person p\r\non p.Id=s.Id\r\nJOIN GroupStudent GS\r\nON S.Id=GS.StudentId\r\nJOIN GroupEvaluation GE\r\nON GS.GroupId=GE.GroupId\r\nWHERE (SELECT SUM(ObtainedMarks) FROM GroupEvaluation E WHERE E.GroupId=GE.GroupId)<\r\n\t\t(SELECT AVG(ObtainedMarks) FROM GroupEvaluation)";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        internal static DataTable studentsWithoutGroup()
        {
            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();
            string query = "Select S.ID,FirstName,LastName ,RegistrationNo \r\nfrom Student S Join Person P on S.id=P.id \r\nExcept \r\nSelect S.ID,FirstName,LastName ,RegistrationNo \r\nfrom Student S Join Person P on S.id=P.id  \r\nJoin GroupStudent gs on gs.StudentId=s.Id \r\nJoin Lookup l on l.id=gs.status \r\nwhere l.Value='active'";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        internal static DataTable studentsWithoutProject()
        {

            SqlCommand cmd;
            SqlConnection con = Configuration.getInstance().getConnection();
            string query = "select p.FirstName+' '+p.LastName Name,s.RegistrationNo\r\nfrom Student s\r\njoin person p\r\non s.Id=p.Id\r\nLeft join GroupStudent gs\r\non s.Id=gs.StudentId\r\nLeft Join GroupProject gp\r\non gp.GroupId=gs.GroupId\r\nwhere gs.GroupId is null or gp.ProjectId is null";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}

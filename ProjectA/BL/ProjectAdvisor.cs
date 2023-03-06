using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.BL
{
    public class ProjectAdvisor
    {
        private int advisorId;
        private int projectId;
        private int advisorRole;
        private DateTime assignmentDate;
        public ProjectAdvisor() { }
        public ProjectAdvisor(int advisorId,int projectId,int advisorRole,DateTime assignmentDate)
        {
            this.advisorId = advisorId;
            this.projectId = projectId;
            this.advisorRole = advisorRole;
            this.AssignmentDate = assignmentDate;
        }
        public int AdvisorId { get => advisorId; set => advisorId = value; }
        public int ProjectId { get => projectId; set => projectId = value; }
        public int AdvisorRole { get => advisorRole; set => advisorRole = value; }
        public DateTime AssignmentDate { get => assignmentDate; set => assignmentDate = value; }
    }
}

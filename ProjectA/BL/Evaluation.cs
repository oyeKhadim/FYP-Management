using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.BL
{
    public class Evaluation
    {
        private int id;
        private string name;
        private int totalMarks;
        private int totalWeightage;

        public Evaluation() { }
        public Evaluation(int id, string name, int totalMarks, int totalWeightage)
        {
            this.Id = id;
            this.Name = name;
            this.TotalMarks = totalMarks;
            this.TotalWeightage = totalWeightage;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int TotalMarks { get => totalMarks; set => totalMarks = value; }
        public int TotalWeightage { get => totalWeightage; set => totalWeightage = value; }
    }
}

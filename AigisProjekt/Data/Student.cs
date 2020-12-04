using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AigisProjekt.Data
{
    public class Student
    {
        public string Prename { get; set; }
        public string Name { get; set; }
        public string FullName => Prename + " "+Name;
        public DateTime DateOfBirth { get; set; }
        public int Id { get; set; }

        public ICollection<SubjectToStudent> SubjectToStudent { get; set; }
    }

}

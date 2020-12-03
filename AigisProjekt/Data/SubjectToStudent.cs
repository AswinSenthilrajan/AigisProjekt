using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AigisProjekt.Data
{
    public class SubjectToStudent
    {
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public Mark Mark { get; set; }
    }
}

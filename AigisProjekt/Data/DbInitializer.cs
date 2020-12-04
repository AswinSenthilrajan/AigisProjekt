using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AigisProjekt.Data
{
    public class DbInitializer
    {
        public static void Initialize(Database context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{Prename="Carson",Name="Alexander"},
            new Student{Prename="Meredith",Name="Alonso"},
            new Student{Prename="Arturo",Name="Anand"},
            new Student{Prename="Gytis",Name="Barzdukas"},
            };

            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var subjects = new Subject[]
            {
            new Subject{Id=1050,Name="Maths"},
            new Subject{Id=4022,Name="German"},
            new Subject{Id=4041,Name="English"},
            new Subject{Id=1045,Name="IT"}
            };
            foreach (Subject subj in subjects)
            {
                context.Subject.Add(subj);
            }
            context.SaveChanges();
            //---------------------------------------------
            var marks = new Mark[]
            {
            new Mark{Id=1050,SchoolMark="4"},
            new Mark{Id=4022,SchoolMark="5"},
            new Mark{Id=4041,SchoolMark="2"},
            new Mark{Id=1045,SchoolMark="6"}
            };
            foreach (Mark m in marks)
            {
                context.Mark.Add(m);
            }
            context.SaveChanges();
        }
    }
}

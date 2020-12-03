using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AigisProjekt.Data
{
    public class Database : DbContext
    {
        public Database(){
            //NOTHING
        }

        public Database(DbContextOptions<Database> options) : base(options)
        {
        }

        public DbSet<Mark> Mark { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<SubjectToStudent> SubjectToStudent { get; set; }
    }
}


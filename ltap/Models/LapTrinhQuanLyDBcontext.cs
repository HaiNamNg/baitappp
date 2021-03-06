using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ltap.Models
{
    public class LapTrinhQuanLyDBcontext: DbContext
    {
        public LapTrinhQuanLyDBcontext() : base("LapTrinhQuanLyDBcontext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<AccountModel> AccountModels { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
    
    }
}
//DESKTOP-GIPHEE4\SQLEXPRESS
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

        public virtual<acc> Students { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }

    }
}
//DESKTOP-GIPHEE4\SQLEXPRESS
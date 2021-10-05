﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ltap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(50)]
        public string Usename { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(10)]
        public string RoleID { get; set; }
        public string Username { get; internal set; }
    }
}
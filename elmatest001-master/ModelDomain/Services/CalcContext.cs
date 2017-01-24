using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Services
{
    public class CalcContext: DbContext
    {
        public CalcContext()
            : base("DefaultConnection") { }

        public DbSet<OperationResult> OperationResult { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<Users> Users { get; set; }
    }
}
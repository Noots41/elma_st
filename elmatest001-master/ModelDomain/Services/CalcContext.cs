﻿using Models;
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

        public DbSet<Operations> Operations { get; set; }
    }
}
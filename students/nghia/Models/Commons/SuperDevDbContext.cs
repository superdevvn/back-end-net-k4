﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class SuperDevDbContext : DbContext
    {
        public SuperDevDbContext() : base("DefaultConnection")
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoDijelovi1.Models;

namespace AutoDijelovi1.Models
{
    public class AutoDijelovi1Context : DbContext
    {
        public AutoDijelovi1Context (DbContextOptions<AutoDijelovi1Context> options)
            : base(options)
        {
        }

        public DbSet<AutoDijelovi1.Models.Auto> Auto { get; set; }

        public DbSet<AutoDijelovi1.Models.Skladiste> Skladiste { get; set; }
    }
}

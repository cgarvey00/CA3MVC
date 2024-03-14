using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CA3MVC.Models;

namespace CA3MVC.Data
{
    public class CA3MVCContext : DbContext
    {
        public CA3MVCContext (DbContextOptions<CA3MVCContext> options)
            : base(options)
        {
        }

        public DbSet<CA3MVC.Models.Zoo> Zoo { get; set; } = default!;
    }
}

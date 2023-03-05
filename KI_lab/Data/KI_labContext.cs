using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KI_lab.Models;

namespace KI_lab.Data
{
    public class KI_labContext : DbContext
    {
        public KI_labContext (DbContextOptions<KI_labContext> options)
            : base(options)
        {
        }

        public DbSet<KI_lab.Models.Movie> Movie { get; set; } = default!;
    }
}

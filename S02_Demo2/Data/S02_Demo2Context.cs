using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using S02_Demo2.Models;

namespace S02_Demo2.Data
{
    public class S02_Demo2Context : DbContext
    {
        public S02_Demo2Context (DbContextOptions<S02_Demo2Context> options)
            : base(options)
        {
        }

        public DbSet<S02_Demo2.Models.Boat> Boat { get; set; } = default!;
    }
}

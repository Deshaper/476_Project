using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC476.Models;

namespace MVC476.Data
{
    public class MVC476Context : DbContext
    {
        public MVC476Context (DbContextOptions<MVC476Context> options)
            : base(options)
        {
        }

        public DbSet<MVC476.Models.Test> Test { get; set; } = default!;
    }
}

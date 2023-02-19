using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC476.Models;

namespace MVC476.Data
{
    public class MVC476AccountContext : DbContext
    {
        public MVC476AccountContext (DbContextOptions<MVC476AccountContext> options)
            : base(options)
        {
        }

        public DbSet<MVC476.Models.Account> Account { get; set; } = default!;
    }
}

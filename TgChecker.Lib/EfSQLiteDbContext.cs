using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgChecker.Lib
{
    internal class EfSQLiteDbContext : DbContext
    {
        public EfSQLiteDbContext(DbContextOptions<EfSQLiteDbContext> opts) : base(opts)
        {
            Database.EnsureCreated();
        }


    }
}

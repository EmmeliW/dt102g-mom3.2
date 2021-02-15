using Microsoft.EntityFrameworkCore;
using EFprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFprojekt.Data
{
    public class RecordContext : DbContext
    {
        public RecordContext(DbContextOptions<RecordContext> options):base(options)
        {

        }
        public DbSet<Records> Records { get; set; }   
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Loans> Loans { get; set; }
    }
}

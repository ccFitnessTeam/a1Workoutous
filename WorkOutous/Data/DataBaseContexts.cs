using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkOutous.Models;

namespace WorkOutous.Data
{
    public class DataBaseContexts : DbContext
    {
        public DataBaseContexts(DbContextOptions<DataBaseContexts> options): base(options)
        {

        }
        //add model for db migration
        public DbSet<User> User { get; set; }

    }
}

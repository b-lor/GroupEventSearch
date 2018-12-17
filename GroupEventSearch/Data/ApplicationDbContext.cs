using System;
using System.Collections.Generic;
using System.Text;
using GroupEventSearch.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GroupEventSearch.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cities> Cities { get; set; }
        public DbSet<Cuisine> Cuisine { get; set; }
        public DbSet<Establishment> Establishment { get; set; }
    }
}

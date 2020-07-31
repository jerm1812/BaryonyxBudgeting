using System;
using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Users
{
    public class BaryonyxUserContext : DbContext
    {
        public BaryonyxUserContext(DbContextOptions<BaryonyxUserContext> options) : base(options) {}
        
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
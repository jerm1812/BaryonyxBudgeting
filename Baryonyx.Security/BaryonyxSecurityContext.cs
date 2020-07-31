using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Security
{
    public class BaryonyxSecurityContext : IdentityDbContext<IdentityUser>
    {
        public BaryonyxSecurityContext(DbContextOptions<BaryonyxSecurityContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
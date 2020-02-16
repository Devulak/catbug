using System;
using System.Collections.Generic;
using System.Text;
using catbug.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace catbug.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Entry> Entries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using catbug.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace catbug.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryCategory> EntryCategories { get; set; }
        public DbSet<LearningCycle> LearningCycles { get; set; }
        public DbSet<LearningObjective> LearningObjectives { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

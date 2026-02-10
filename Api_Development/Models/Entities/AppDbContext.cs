using System;
using System.Collections.Generic;
using Api_Development.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api_Development.Models.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }
    public virtual DbSet<Difficulty> Difficulties { get; set; }
    public virtual DbSet<Region> Regions { get; set; }
    public virtual DbSet<Walk> Walks { get; set; }
}

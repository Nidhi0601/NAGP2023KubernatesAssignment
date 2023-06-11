using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NAGP2023KubernatesAssignment.Models;

public partial class CoreDbContext : DbContext
{

    public CoreDbContext(DbContextOptions<CoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__Employee__C190170BBCBB9CFA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

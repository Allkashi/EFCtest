using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTest;

public partial class ExamContext : DbContext
{
    public ExamContext()
    {
    }

    public ExamContext(DbContextOptions<ExamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=Exam;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepId).HasName("PRIMARY");

            entity
                .ToTable("department", tb => tb.HasComment("Отдел"))
                .HasCharSet("cp1251")
                .UseCollation("cp1251_general_ci");

            entity.Property(e => e.DepId)
                .HasComment("Идентификатор отдела")
                .HasColumnType("int(11)")
                .HasColumnName("DEP_ID");
            entity.Property(e => e.DepName)
                .HasMaxLength(30)
                .HasComment("Наименование отдела")
                .HasColumnName("DEP_NAME");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PRIMARY");

            entity
                .ToTable("employee")
                .HasCharSet("cp1251")
                .UseCollation("cp1251_general_ci");

            entity.HasIndex(e => e.JobId, "employee_ibfk_1");

            entity.HasIndex(e => e.DepId, "employee_ibfk_2");

            entity.HasIndex(e => e.Manager, "employee_ibfk_3");

            entity.Property(e => e.EmpId)
                .HasComment("Идентификатор сотрудника")
                .HasColumnType("int(11)")
                .HasColumnName("EMP_ID");
            entity.Property(e => e.Bonus)
                .HasComment("Размер премии (%)")
                .HasColumnType("int(11)")
                .HasColumnName("BONUS");
            entity.Property(e => e.DateIn)
                .HasComment("Дата трудоустройства")
                .HasColumnName("DATE_IN");
            entity.Property(e => e.DepId)
                .HasComment("Идентификатор отдела")
                .HasColumnType("int(11)")
                .HasColumnName("DEP_ID");
            entity.Property(e => e.EmpName)
                .HasMaxLength(20)
                .HasComment("ФИО сотрудника")
                .HasColumnName("EMP_NAME");
            entity.Property(e => e.JobId)
                .HasComment("Идентификатор должности")
                .HasColumnType("int(11)")
                .HasColumnName("JOB_ID");
            entity.Property(e => e.Manager)
                .HasComment("Начальник сотрудника")
                .HasColumnType("int(11)")
                .HasColumnName("MANAGER");

            entity.HasOne(d => d.Dep).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepId)
                .HasConstraintName("employee_ibfk_2");

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("employee_ibfk_1");

            entity.HasOne(d => d.ManagerNavigation).WithMany(p => p.InverseManagerNavigation)
                .HasForeignKey(d => d.Manager)
                .HasConstraintName("employee_ibfk_3");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PRIMARY");

            entity
                .ToTable("job", tb => tb.HasComment("Должность"))
                .HasCharSet("cp1251")
                .UseCollation("cp1251_general_ci");

            entity.Property(e => e.JobId)
                .HasComment("Идентификатор должности")
                .HasColumnType("int(11)")
                .HasColumnName("JOB_ID");
            entity.Property(e => e.PosName)
                .HasMaxLength(20)
                .HasComment("Наименование должности")
                .HasColumnName("POS_NAME");
            entity.Property(e => e.Salary)
                .HasComment("Зарплата")
                .HasColumnType("int(11)")
                .HasColumnName("SALARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace physics_webserver.Models;

public partial class PhysicsDbContext : DbContext
{
    public PhysicsDbContext()
    {
    }

    public PhysicsDbContext(DbContextOptions<PhysicsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Theory> Theories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-2ARAE3C;Initial Catalog=physics_db;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK_AdminKey");

            entity.ToTable("_Admin");

            entity.Property(e => e.AdminId).ValueGeneratedOnAdd();
            entity.Property(e => e.AdminFullName).HasMaxLength(256);

            entity.HasOne(d => d.AdminNavigation).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminUserKey");
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK_AnswerKey");

            entity.ToTable("_Answers");

            entity.Property(e => e.AnswerCorrect).HasMaxLength(256);
            entity.Property(e => e.AnswerStudent).HasMaxLength(256);
            entity.Property(e => e.AnswerText).HasMaxLength(256);

            entity.HasOne(d => d.AnswerStudentNavigation).WithMany(p => p.Answers)
                .HasForeignKey(d => d.AnswerStudentId)
                .HasConstraintName("FK_AnswerStudentKey");

            entity.HasOne(d => d.AnswerTask).WithMany(p => p.Answers)
                .HasForeignKey(d => d.AnswerTaskId)
                .HasConstraintName("FK_AnswerTaskKey");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK_GroupKey");

            entity.ToTable("_Group");

            entity.HasOne(d => d.GroupStudent).WithMany(p => p.Groups)
                .HasForeignKey(d => d.GroupStudentId)
                .HasConstraintName("FK_GroupStudentKey");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK_MessageKey");

            entity.ToTable("_Message");

            entity.HasOne(d => d.MessageUser).WithMany(p => p.Messages)
                .HasForeignKey(d => d.MessageUserId)
                .HasConstraintName("FK_MessageUserKey");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_StudentKey");

            entity.ToTable("_Student");

            entity.Property(e => e.StudentId).ValueGeneratedOnAdd();
            entity.Property(e => e.StudentFullName).HasMaxLength(256);
            entity.Property(e => e.StudentGroup).HasMaxLength(256);

            entity.HasOne(d => d.StudentNavigation).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentUserKey");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK_TaskKey");

            entity.ToTable("_Task");

            entity.HasOne(d => d.TaskTeacher).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TaskTeacherId)
                .HasConstraintName("FK_TaskTeacherKey");

            entity.HasOne(d => d.TaskTheory).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TaskTheoryId)
                .HasConstraintName("FK_TaskTheoryKey");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK_TeacherKey");

            entity.ToTable("_Teacher");

            entity.Property(e => e.TeacherId).ValueGeneratedOnAdd();
            entity.Property(e => e.TeacherFullName).HasMaxLength(256);

            entity.HasOne(d => d.TeacherNavigation).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherUserKey");
        });

        modelBuilder.Entity<Theory>(entity =>
        {
            entity.HasKey(e => e.TheoryId).HasName("PK_TheoryKey");

            entity.ToTable("_Theory");

            entity.Property(e => e.TheorySection).HasMaxLength(256);
            entity.Property(e => e.TheoryTheme).HasMaxLength(256);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_UserKey");

            entity.ToTable("_User");

            entity.Property(e => e.UserLogin).HasMaxLength(256);
            entity.Property(e => e.UserPassword).HasMaxLength(256);
            entity.Property(e => e.UserRole).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

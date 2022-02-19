﻿// <auto-generated />
using System;
using Git.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Git.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Git.Data.Models.Commit", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepositoryId")
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("Git.Data.Models.Repository", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("Git.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Git.Data.Models.Commit", b =>
                {
                    b.HasOne("Git.Data.Models.User", "Creator")
                        .WithMany("Commits")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Git.Data.Models.Repository", "Repository")
                        .WithMany("Commits")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Creator");

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("Git.Data.Models.Repository", b =>
                {
                    b.HasOne("Git.Data.Models.User", "Owner")
                        .WithMany("Repositories")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Git.Data.Models.Repository", b =>
                {
                    b.Navigation("Commits");
                });

            modelBuilder.Entity("Git.Data.Models.User", b =>
                {
                    b.Navigation("Commits");

                    b.Navigation("Repositories");
                });
#pragma warning restore 612, 618
        }
    }
}
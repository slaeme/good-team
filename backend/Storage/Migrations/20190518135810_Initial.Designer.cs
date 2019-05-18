﻿// <auto-generated />
using System;
using GT.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GT.Storage.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190518135810_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GT.Storage.Models.Deed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedBy");

                    b.Property<int>("CurrentCountUsers");

                    b.Property<string>("DescriptionPrivate");

                    b.Property<string>("DescriptionPublic")
                        .IsRequired();

                    b.Property<int>("MaxCountUsers");

                    b.Property<int>("MinCountUsers");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("Deeds");
                });

            modelBuilder.Entity("GT.Storage.Models.UserDeed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DeedId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserDeeds");
                });

            modelBuilder.Entity("Storage.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bbmscore.Data;

#nullable disable

namespace bbmscore.Migrations
{
    [DbContext(typeof(bloodDbcontext))]
    [Migration("20240923053328_convbertdatatypeofphoneinttolong")]
    partial class convbertdatatypeofphoneinttolong
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("bbmscore.Models.Campain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organazation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CampainData");
                });

            modelBuilder.Entity("bbmscore.Models.Domine.Bloodstock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("bloodquantity")
                        .HasColumnType("int");

                    b.Property<string>("bloodtype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("containerno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bloodstocks");
                });

            modelBuilder.Entity("bbmscore.Models.Patients", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("bloodtype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("hospital")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}

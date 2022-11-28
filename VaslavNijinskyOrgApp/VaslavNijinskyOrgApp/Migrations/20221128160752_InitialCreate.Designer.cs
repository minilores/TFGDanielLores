﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaslavNijinskyOrgApp.Data;

namespace VaslavNijinskyOrgApp.Migrations
{
    [DbContext(typeof(EventDb))]
    [Migration("20221128160752_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("VaslavNijinskyOrgApp.Models.Choreography", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<int>("FinalMark")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GroupCoach")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFinalist")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("SchoolName")
                        .HasColumnType("TEXT");

                    b.Property<int>("SemifinalMark")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Choreography");
                });

            modelBuilder.Entity("VaslavNijinskyOrgApp.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("SchoolName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("VaslavNijinskyOrgApp.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("School");
                });
#pragma warning restore 612, 618
        }
    }
}

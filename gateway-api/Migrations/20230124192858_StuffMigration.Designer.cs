﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace gatewayapi.Migrations
{
    [DbContext(typeof(GeneralContext))]
    [Migration("20230124192858_StuffMigration")]
    partial class StuffMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("common.models.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CrewName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("common.models.CrewMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CrewId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Rank")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Species")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.ToTable("CrewMembers");
                });

            modelBuilder.Entity("common.models.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("common.models.CrewMember", b =>
                {
                    b.HasOne("common.models.Crew", null)
                        .WithMany("CrewMembers")
                        .HasForeignKey("CrewId");
                });

            modelBuilder.Entity("common.models.Crew", b =>
                {
                    b.Navigation("CrewMembers");
                });
#pragma warning restore 612, 618
        }
    }
}

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
    [Migration("20230125104948_ExpeditionsMigration")]
    partial class ExpeditionsMigration
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

                    b.Property<string>("ShuttleName")
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

            modelBuilder.Entity("common.models.Expedition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CrewId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ExpeditionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlanetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.HasIndex("ExpeditionId");

                    b.HasIndex("PlanetId");

                    b.ToTable("Expeditions");
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

            modelBuilder.Entity("common.models.Expedition", b =>
                {
                    b.HasOne("common.models.Crew", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("common.models.Expedition", null)
                        .WithMany("Expeditions")
                        .HasForeignKey("ExpeditionId");

                    b.HasOne("common.models.Planet", "Planet")
                        .WithMany("Expeditions")
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crew");

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("common.models.Crew", b =>
                {
                    b.Navigation("CrewMembers");
                });

            modelBuilder.Entity("common.models.Expedition", b =>
                {
                    b.Navigation("Expeditions");
                });

            modelBuilder.Entity("common.models.Planet", b =>
                {
                    b.Navigation("Expeditions");
                });
#pragma warning restore 612, 618
        }
    }
}

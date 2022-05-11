﻿// <auto-generated />
using System;
using CoterieApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoterieApp.Data.Migrations
{
    [DbContext(typeof(CoterieAppContext))]
    partial class CoterieAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("NOCASE")
                .HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("AssesmentCoterie.Domain.Entities.Business", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("BusinessFactor")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Business", (string)null);
                });

            modelBuilder.Entity("AssesmentCoterie.Domain.Entities.Quote", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Business")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsSuccesful")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Revenue")
                        .HasColumnType("REAL");

                    b.HasKey("TransactionId");

                    b.ToTable("Quotes", (string)null);
                });

            modelBuilder.Entity("AssesmentCoterie.Domain.Entities.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("FactorState")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("States", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
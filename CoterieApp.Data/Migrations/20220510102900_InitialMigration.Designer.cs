// <auto-generated />
using System;
using CoterieApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoterieApp.Data.Migrations
{
    [DbContext(typeof(CoterieAppContext))]
    [Migration("20220510102900_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

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

                    b.Property<Guid>("BussinessId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsSuccesful")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Revenue")
                        .HasColumnType("REAL");

                    b.HasKey("TransactionId");

                    b.HasIndex("BussinessId");

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

                    b.Property<Guid?>("QuoteTransactionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QuoteTransactionId");

                    b.ToTable("States", (string)null);
                });

            modelBuilder.Entity("AssesmentCoterie.Domain.Entities.Quote", b =>
                {
                    b.HasOne("AssesmentCoterie.Domain.Entities.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BussinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("AssesmentCoterie.Domain.Entities.State", b =>
                {
                    b.HasOne("AssesmentCoterie.Domain.Entities.Quote", null)
                        .WithMany("State")
                        .HasForeignKey("QuoteTransactionId");
                });

            modelBuilder.Entity("AssesmentCoterie.Domain.Entities.Quote", b =>
                {
                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}

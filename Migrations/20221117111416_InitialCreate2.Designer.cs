﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace mvc_ef.Migrations
{
    [DbContext(typeof(SqliteContext))]
    [Migration("20221117111416_InitialCreate2")]
    partial class InitialCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("LanguagePerson", b =>
                {
                    b.Property<int>("LanguagesLanguageId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PeoplePersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LanguagesLanguageId", "PeoplePersonId");

                    b.HasIndex("PeoplePersonId");

                    b.ToTable("LanguagePerson");
                });

            modelBuilder.Entity("mvc_ef.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("mvc_ef.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("mvc_ef.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LanguageId");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("mvc_ef.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.HasIndex("CityId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("LanguagePerson", b =>
                {
                    b.HasOne("mvc_ef.Models.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mvc_ef.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PeoplePersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mvc_ef.Models.City", b =>
                {
                    b.HasOne("mvc_ef.Models.Country", "Country")
                        .WithMany("City")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("mvc_ef.Models.Person", b =>
                {
                    b.HasOne("mvc_ef.Models.City", "City")
                        .WithMany("Person")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("mvc_ef.Models.City", b =>
                {
                    b.Navigation("Person");
                });

            modelBuilder.Entity("mvc_ef.Models.Country", b =>
                {
                    b.Navigation("City");
                });
#pragma warning restore 612, 618
        }
    }
}

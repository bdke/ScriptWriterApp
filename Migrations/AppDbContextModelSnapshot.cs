﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScriptWriterApp.Data;

#nullable disable

namespace ScriptWriterApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("ScriptWriterApp.Data.ChangeHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("FilePath")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LineNum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Origin")
                        .HasColumnType("TEXT");

                    b.Property<char?>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("ChangeHistories");
                });

            modelBuilder.Entity("ScriptWriterApp.Data.FoldersData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FolderName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FoldersDataID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("FoldersDataID");

                    b.ToTable("FolderDatas");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FolderName = "idk"
                        });
                });

            modelBuilder.Entity("ScriptWriterApp.Data.PagesData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FoldersDataID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<string>("Texts")
                        .HasColumnType("TEXT");

                    b.Property<string>("pTexts")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("FoldersDataID");

                    b.ToTable("PagesDatas");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Path = "/",
                            Texts = "my mom is beautiful",
                            pTexts = ""
                        });
                });

            modelBuilder.Entity("ScriptWriterApp.Data.FoldersData", b =>
                {
                    b.HasOne("ScriptWriterApp.Data.FoldersData", null)
                        .WithMany("Folders")
                        .HasForeignKey("FoldersDataID");
                });

            modelBuilder.Entity("ScriptWriterApp.Data.PagesData", b =>
                {
                    b.HasOne("ScriptWriterApp.Data.FoldersData", null)
                        .WithMany("Pages")
                        .HasForeignKey("FoldersDataID");
                });

            modelBuilder.Entity("ScriptWriterApp.Data.FoldersData", b =>
                {
                    b.Navigation("Folders");

                    b.Navigation("Pages");
                });
#pragma warning restore 612, 618
        }
    }
}

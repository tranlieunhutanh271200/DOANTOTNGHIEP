﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserCustomization.Persistence;

namespace UserCustomization.Migrations
{
    [DbContext(typeof(CustomizationDbContext))]
    partial class CustomizationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Service.Core.Models.Customization.Addon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ElementId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Addons");
                });

            modelBuilder.Entity("Service.Core.Models.Customization.Background", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BackgroundImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Backgrounds");
                });

            modelBuilder.Entity("Service.Core.Models.Customization.Color", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BackColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ForeColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableStripColor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("Service.Core.Models.Customization.DefaultRoute", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Route")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("DefaultRoutes");
                });

            modelBuilder.Entity("Service.Core.Models.Customization.Menu", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCollapsed")
                        .HasColumnType("bit");

                    b.HasKey("AccountId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Service.Core.Models.Customization.Addon", b =>
                {
                    b.HasOne("Service.Core.Models.Customization.Menu", "Menu")
                        .WithMany("Addons")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Service.Core.Models.Customization.Menu", b =>
                {
                    b.Navigation("Addons");
                });
#pragma warning restore 612, 618
        }
    }
}

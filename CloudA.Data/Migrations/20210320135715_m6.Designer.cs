﻿// <auto-generated />
using System;
using CloudA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CloudA.Data.Migrations
{
    [DbContext(typeof(CloudAContext))]
    [Migration("20210320135715_m6")]
    partial class m6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CloudA.Data.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventIdEvent")
                        .HasColumnType("int");

                    b.Property<int>("IdEvent")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("permission1")
                        .HasColumnType("bit");

                    b.Property<bool>("permission2")
                        .HasColumnType("bit");

                    b.HasKey("IdClient");

                    b.HasIndex("EventIdEvent");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("CloudA.Data.Data.Images", b =>
                {
                    b.Property<int>("IdImages")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventIdEvent")
                        .HasColumnType("int");

                    b.Property<int>("IdEvent")
                        .HasColumnType("int");

                    b.Property<string>("PathUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdImages");

                    b.HasIndex("EventIdEvent");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("CloudA.Data.Event", b =>
                {
                    b.Property<int>("IdEvent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRegister")
                        .HasColumnType("bit");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxNumOfPeople")
                        .HasColumnType("int");

                    b.Property<int>("NumOfRegistered")
                        .HasColumnType("int");

                    b.Property<string>("TitleEng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitlePL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleRos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEvent");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("CloudA.Data.Client", b =>
                {
                    b.HasOne("CloudA.Data.Event", "Event")
                        .WithMany("Clients")
                        .HasForeignKey("EventIdEvent");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("CloudA.Data.Data.Images", b =>
                {
                    b.HasOne("CloudA.Data.Event", "Event")
                        .WithMany("Images")
                        .HasForeignKey("EventIdEvent");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("CloudA.Data.Event", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}

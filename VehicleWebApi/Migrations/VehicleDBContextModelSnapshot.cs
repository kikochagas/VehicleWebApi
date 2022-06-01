﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleWebApi.Models;

namespace VehicleWebApi.Migrations
{
    [DbContext(typeof(VehicleDBContext))]
    partial class VehicleDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarsWebApi.Models.Tables.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b2dd001b-3c83-4bb3-a9c5-d3a77d55d0bd"),
                            Name = "Alfa Romeo 4C"
                        },
                        new
                        {
                            Id = new Guid("babaffff-615a-4d7d-a0dd-c3dcd3f3ffd8"),
                            Name = "Alfa Romeo Stelvio"
                        },
                        new
                        {
                            Id = new Guid("a88bfe7b-af13-48bc-ac04-7e8089b287a0"),
                            Name = "Peugeot 2008 Allure 1.2"
                        });
                });

            modelBuilder.Entity("CarsWebApi.Models.Tables.Vehicle", b =>
                {
                    b.Property<Guid>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestId");

                    b.HasIndex("ModelId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            RequestId = new Guid("cc97d34d-d5a1-4228-92b5-a7797b21b271"),
                            DeliveryDate = new DateTime(2022, 5, 13, 18, 18, 57, 367, DateTimeKind.Utc).AddTicks(6386),
                            ModelId = new Guid("b2dd001b-3c83-4bb3-a9c5-d3a77d55d0bd"),
                            Vin = "VN56RFF5656R6F"
                        },
                        new
                        {
                            RequestId = new Guid("b4b00d59-0fb8-4fe8-9ecb-1555f58bfb15"),
                            DeliveryDate = new DateTime(2022, 5, 13, 18, 18, 57, 367, DateTimeKind.Utc).AddTicks(6941),
                            ModelId = new Guid("a88bfe7b-af13-48bc-ac04-7e8089b287a0"),
                            Vin = "VN677BBB6B6BB"
                        },
                        new
                        {
                            RequestId = new Guid("f4ca36b9-ee67-4dbc-bed6-010406dda01a"),
                            DeliveryDate = new DateTime(2022, 5, 13, 18, 18, 57, 367, DateTimeKind.Utc).AddTicks(6944),
                            ModelId = new Guid("babaffff-615a-4d7d-a0dd-c3dcd3f3ffd8"),
                            Vin = "VN677HHTUY6BB"
                        });
                });

            modelBuilder.Entity("CarsWebApi.Models.Tables.Vehicle", b =>
                {
                    b.HasOne("CarsWebApi.Models.Tables.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Aleff.Pizzaria.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aleff.Pizzaria.Infra.Data.Migrations
{
    [DbContext(typeof(PizzariaDbContext))]
    partial class PizzariaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aleff.Pizzaria.Domain.Features.Flavors.Flavor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<double>("PreparationTime");

                    b.HasKey("Id");

                    b.ToTable("Flavors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Calabresa",
                            PreparationTime = 0.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Marguerita",
                            PreparationTime = 0.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Portuguesa",
                            PreparationTime = 5.0
                        });
                });

            modelBuilder.Entity("Aleff.Pizzaria.Domain.Features.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<int>("PizzaId");

                    b.Property<double>("PreparationTime");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Aleff.Pizzaria.Domain.Features.Pizzas.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Customizations");

                    b.Property<int>("FlavorId");

                    b.Property<int>("SizeId");

                    b.HasKey("Id");

                    b.HasIndex("FlavorId");

                    b.HasIndex("SizeId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("Aleff.Pizzaria.Domain.Features.Sizes.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ESize");

                    b.Property<double>("PreparationTime");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ESize = 1,
                            PreparationTime = 15.0,
                            Value = 20.0
                        },
                        new
                        {
                            Id = 2,
                            ESize = 2,
                            PreparationTime = 20.0,
                            Value = 30.0
                        },
                        new
                        {
                            Id = 3,
                            ESize = 3,
                            PreparationTime = 25.0,
                            Value = 40.0
                        });
                });

            modelBuilder.Entity("Aleff.Pizzaria.Domain.Features.Orders.Order", b =>
                {
                    b.HasOne("Aleff.Pizzaria.Domain.Features.Pizzas.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .HasConstraintName("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Aleff.Pizzaria.Domain.Features.Pizzas.Pizza", b =>
                {
                    b.HasOne("Aleff.Pizzaria.Domain.Features.Flavors.Flavor", "Flavor")
                        .WithMany("Pizzas")
                        .HasForeignKey("FlavorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Aleff.Pizzaria.Domain.Features.Sizes.Size", "Size")
                        .WithMany("Pizzas")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP3_Proyecto_Software.Context;

namespace TP3_Proyecto_Software.Migrations
{
    [DbContext(typeof(TrabajoPracticoContext))]
    [Migration("20210718074028_migracion")]
    partial class migracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TP3_Proyecto_Software.Entities.Comanda", b =>
                {
                    b.Property<string>("ComandaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("FormaEntregaId")
                        .HasColumnType("int");

                    b.Property<int>("PrecioTotal")
                        .HasColumnType("int");

                    b.HasKey("ComandaId");

                    b.HasIndex("FormaEntregaId");

                    b.ToTable("Comanda");
                });

            modelBuilder.Entity("TP3_Proyecto_Software.Entities.ComandaMercaderia", b =>
                {
                    b.Property<int>("ComandaMercaderiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComandaId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MercaderiaId")
                        .HasColumnType("int");

                    b.HasKey("ComandaMercaderiaId");

                    b.HasIndex("ComandaId");

                    b.HasIndex("MercaderiaId");

                    b.ToTable("ComandaMercaderia");
                });

            modelBuilder.Entity("TP3_Proyecto_Software.Entities.FormaEntrega", b =>
                {
                    b.Property<int>("FormaEntregaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FormaEntregaId");

                    b.ToTable("FormaEntrega");

                    b.HasData(
                        new
                        {
                            FormaEntregaId = 1,
                            Descripcion = "Salon"
                        },
                        new
                        {
                            FormaEntregaId = 2,
                            Descripcion = "Delivery"
                        },
                        new
                        {
                            FormaEntregaId = 3,
                            Descripcion = "Pedidos Ya"
                        });
                });

            modelBuilder.Entity("TP3_Proyecto_Software.Entities.Mercaderia", b =>
                {
                    b.Property<int>("MercaderiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Ingredientes")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<string>("Preparacion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("TipoMercaderiaId")
                        .HasColumnType("int");

                    b.HasKey("MercaderiaId");

                    b.HasIndex("TipoMercaderiaId");

                    b.ToTable("Mercaderia");

                    b.HasData(
                        new
                        {
                            MercaderiaId = 1,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=1",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Empanadas de carne",
                            Precio = 100,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 1
                        },
                        new
                        {
                            MercaderiaId = 2,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=2",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Empanadas de verdura",
                            Precio = 100,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 1
                        },
                        new
                        {
                            MercaderiaId = 3,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=3",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Milanesa",
                            Precio = 100,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 2
                        },
                        new
                        {
                            MercaderiaId = 4,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=4",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Huevo frito",
                            Precio = 100,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 2
                        },
                        new
                        {
                            MercaderiaId = 5,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=5",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Fideos",
                            Precio = 200,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 3
                        },
                        new
                        {
                            MercaderiaId = 6,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=6",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Ñoquis",
                            Precio = 200,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 3
                        },
                        new
                        {
                            MercaderiaId = 7,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=7",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Choripán",
                            Precio = 200,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 4
                        },
                        new
                        {
                            MercaderiaId = 8,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=8",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Asado",
                            Precio = 300,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 4
                        },
                        new
                        {
                            MercaderiaId = 9,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=9",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Pizza de muzzarella",
                            Precio = 200,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 5
                        },
                        new
                        {
                            MercaderiaId = 10,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=10",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Pizza de verduras",
                            Precio = 200,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 5
                        },
                        new
                        {
                            MercaderiaId = 11,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=11",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Sandwich de jamón",
                            Precio = 100,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 6
                        },
                        new
                        {
                            MercaderiaId = 12,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=12",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Sandwich de verdura",
                            Precio = 100,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 6
                        },
                        new
                        {
                            MercaderiaId = 13,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=13",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Ensalada común",
                            Precio = 100,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 7
                        },
                        new
                        {
                            MercaderiaId = 14,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=14",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Ensalada de frutas",
                            Precio = 100,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 7
                        },
                        new
                        {
                            MercaderiaId = 15,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=15",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Vino",
                            Precio = 200,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 8
                        },
                        new
                        {
                            MercaderiaId = 16,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=16",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Gaseosa",
                            Precio = 100,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 8
                        },
                        new
                        {
                            MercaderiaId = 17,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=17",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Cerveza común",
                            Precio = 200,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 9
                        },
                        new
                        {
                            MercaderiaId = 18,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=18",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Cerveza negra",
                            Precio = 200,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 9
                        },
                        new
                        {
                            MercaderiaId = 19,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=19",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Flan",
                            Precio = 200,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 10
                        },
                        new
                        {
                            MercaderiaId = 20,
                            Imagen = "https://localhost:5001/Home/Imagenes/?id=20",
                            Ingredientes = "(ingredientes)",
                            Nombre = "Helado",
                            Precio = 200,
                            Preparacion = "(preparacion)",
                            TipoMercaderiaId = 10
                        });
                });

            modelBuilder.Entity("TP3_Proyecto_Software.Entities.TipoMercaderia", b =>
                {
                    b.Property<int>("TipoMercaderiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TipoMercaderiaId");

                    b.ToTable("TipoMercaderia");

                    b.HasData(
                        new
                        {
                            TipoMercaderiaId = 1,
                            Descripcion = "Entrada"
                        },
                        new
                        {
                            TipoMercaderiaId = 2,
                            Descripcion = "Minutas"
                        },
                        new
                        {
                            TipoMercaderiaId = 3,
                            Descripcion = "Pastas"
                        },
                        new
                        {
                            TipoMercaderiaId = 4,
                            Descripcion = "Parrilla"
                        },
                        new
                        {
                            TipoMercaderiaId = 5,
                            Descripcion = "Pizzas"
                        },
                        new
                        {
                            TipoMercaderiaId = 6,
                            Descripcion = "Sandwich"
                        },
                        new
                        {
                            TipoMercaderiaId = 7,
                            Descripcion = "Ensaladas"
                        },
                        new
                        {
                            TipoMercaderiaId = 8,
                            Descripcion = "Bebidas"
                        },
                        new
                        {
                            TipoMercaderiaId = 9,
                            Descripcion = "Cerveza artesanal"
                        },
                        new
                        {
                            TipoMercaderiaId = 10,
                            Descripcion = "Postre"
                        });
                });

            modelBuilder.Entity("TP3_Proyecto_Software.Entities.Comanda", b =>
                {
                    b.HasOne("TP3_Proyecto_Software.Entities.FormaEntrega", "FormaEntrega")
                        .WithMany("Comandas")
                        .HasForeignKey("FormaEntregaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormaEntrega");
                });

            modelBuilder.Entity("TP3_Proyecto_Software.Entities.ComandaMercaderia", b =>
                {
                    b.HasOne("TP3_Proyecto_Software.Entities.Comanda", "Comanda")
                        .WithMany("ComandaMercaderias")
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP3_Proyecto_Software.Entities.Mercaderia", "Mercaderia")
                        .WithMany("ComandaMercaderias")
                        .HasForeignKey("MercaderiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comanda");

                    b.Navigation("Mercaderia");
                });

            modelBuilder.Entity("TP3_Proyecto_Software.Entities.Mercaderia", b =>
                {
                    b.HasOne("TP3_Proyecto_Software.Entities.TipoMercaderia", "TipoMercaderia")
                        .WithMany()
                        .HasForeignKey("TipoMercaderiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoMercaderia");
                });

            modelBuilder.Entity("TP3_Proyecto_Software.Entities.Comanda", b =>
                {
                    b.Navigation("ComandaMercaderias");
                });

            modelBuilder.Entity("TP3_Proyecto_Software.Entities.FormaEntrega", b =>
                {
                    b.Navigation("Comandas");
                });

            modelBuilder.Entity("TP3_Proyecto_Software.Entities.Mercaderia", b =>
                {
                    b.Navigation("ComandaMercaderias");
                });
#pragma warning restore 612, 618
        }
    }
}

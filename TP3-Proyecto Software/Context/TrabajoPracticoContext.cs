using TP3_Proyecto_Software.Entities;
using Microsoft.EntityFrameworkCore;

namespace TP3_Proyecto_Software.Context
{
    public class TrabajoPracticoContext : DbContext
    {
        public TrabajoPracticoContext(DbContextOptions<TrabajoPracticoContext> options)
            : base(options)
        {
        }

        public DbSet<Mercaderia> Mercaderia { get; set; }
        public DbSet<TipoMercaderia> TipoMercaderia { get; set; }
        public DbSet<FormaEntrega> FormaEntrega { get; set; }
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<ComandaMercaderia> ComandaMercaderia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=tp3ps;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comanda>().Property(b => b.Fecha).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<TipoMercaderia>().HasData(new TipoMercaderia[] {
                new TipoMercaderia{ TipoMercaderiaId=1,Descripcion="Entrada"},
                new TipoMercaderia{ TipoMercaderiaId=2,Descripcion="Minutas"},
                new TipoMercaderia{ TipoMercaderiaId=3,Descripcion="Pastas"},
                new TipoMercaderia{ TipoMercaderiaId=4,Descripcion="Parrilla"},
                new TipoMercaderia{ TipoMercaderiaId=5,Descripcion="Pizzas"},
                new TipoMercaderia{ TipoMercaderiaId=6,Descripcion="Sandwich"},
                new TipoMercaderia{ TipoMercaderiaId=7,Descripcion="Ensaladas"},
                new TipoMercaderia{ TipoMercaderiaId=8,Descripcion="Bebidas"},
                new TipoMercaderia{ TipoMercaderiaId=9,Descripcion="Cerveza artesanal"},
                new TipoMercaderia{ TipoMercaderiaId=10,Descripcion="Postre"},
            });

            modelBuilder.Entity<FormaEntrega>().HasData(new FormaEntrega[] {
                new FormaEntrega{ FormaEntregaId=1,Descripcion="Salon"},
                new FormaEntrega{ FormaEntregaId=2,Descripcion="Delivery"},
                new FormaEntrega{ FormaEntregaId=3,Descripcion="Pedidos Ya"},
            });

            modelBuilder.Entity<Mercaderia>().HasData(new Mercaderia[] {
                new Mercaderia{ MercaderiaId = 1, TipoMercaderiaId = 1, Nombre = "Empanadas de carne", Precio = 100, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=1"},
                new Mercaderia{ MercaderiaId = 2, TipoMercaderiaId = 1, Nombre = "Empanadas de verdura", Precio = 100, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=2"},
                new Mercaderia{ MercaderiaId = 3, TipoMercaderiaId = 2, Nombre = "Milanesa", Precio = 100, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=3"},
                new Mercaderia{ MercaderiaId = 4, TipoMercaderiaId = 2, Nombre = "Huevo frito", Precio = 100, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=4"},
                new Mercaderia{ MercaderiaId = 5, TipoMercaderiaId = 3, Nombre = "Fideos", Precio = 200, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=5"},
                new Mercaderia{ MercaderiaId = 6, TipoMercaderiaId = 3, Nombre = "Ñoquis", Precio = 200, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=6"},
                new Mercaderia{ MercaderiaId = 7, TipoMercaderiaId = 4, Nombre = "Choripán", Precio = 200, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=7"},
                new Mercaderia{ MercaderiaId = 8, TipoMercaderiaId = 4, Nombre = "Asado", Precio = 300, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=8"},
                new Mercaderia{ MercaderiaId = 9, TipoMercaderiaId = 5, Nombre = "Pizza de muzzarella", Precio = 200, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=9"},
                new Mercaderia{ MercaderiaId = 10, TipoMercaderiaId = 5, Nombre = "Pizza de verduras", Precio = 200, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=10"},
                new Mercaderia{ MercaderiaId = 11, TipoMercaderiaId = 6, Nombre = "Sandwich de jamón", Precio = 100, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=11"},
                new Mercaderia{ MercaderiaId = 12, TipoMercaderiaId = 6, Nombre = "Sandwich de verdura", Precio = 100, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=12"},
                new Mercaderia{ MercaderiaId = 13, TipoMercaderiaId = 7, Nombre = "Ensalada común", Precio = 100, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=13"},
                new Mercaderia{ MercaderiaId = 14, TipoMercaderiaId = 7, Nombre = "Ensalada de frutas", Precio = 100, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=14"},
                new Mercaderia{ MercaderiaId = 15, TipoMercaderiaId = 8, Nombre = "Vino", Precio = 200, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=15"},
                new Mercaderia{ MercaderiaId = 16, TipoMercaderiaId = 8, Nombre = "Gaseosa", Precio = 100, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=16"},
                new Mercaderia{ MercaderiaId = 17, TipoMercaderiaId = 9, Nombre = "Cerveza común", Precio = 200, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=17"},
                new Mercaderia{ MercaderiaId = 18, TipoMercaderiaId = 9, Nombre = "Cerveza negra", Precio = 200, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=18"},
                new Mercaderia{ MercaderiaId = 19, TipoMercaderiaId = 10, Nombre = "Flan", Precio = 200, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=19"},
                new Mercaderia{ MercaderiaId = 20, TipoMercaderiaId = 10, Nombre = "Helado", Precio = 200, Ingredientes = "(ingredientes)", Preparacion = "(preparacion)", Imagen = "https://localhost:5001/Home/Imagenes/?id=20"}
               
            });
        }
    }


}

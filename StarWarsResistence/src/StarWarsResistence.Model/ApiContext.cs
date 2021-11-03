using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using StarWarsResistence.Model.Entities;


namespace StarWarsResistence.Model
{
    // Add-Migration Initial -Context ApiContext -o Migrations
    // Add-Migration Initial -o Migrations
    // Scaffold-DbContext 'Server=(localdb)\\mssqllocaldb;Database=MyDb' Microsoft.EntityFrameworkCore.SqlServer -ContextDir "" -OutputDir Entities
    public class ApiContext : DbContext
    {
        public static string UsedSchema => "dbo";

        public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Rebelde> Rebeldes { get; set; }

        public virtual DbSet<Localizacao> Localizacao {get; set;}

        public virtual DbSet<Inventario> Inventario { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder
                .UseMySQL(
                    "server=localhost;database=StarWarsResistence;user=root;password=admin;",
                    sqlOptions => sqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, UsedSchema)
                );         
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Rebelde>().HasData(
            //    new Rebelde
            //    {
            //        Id = 1,
            //        nome = "Rebelde1",
            //        idade = 20,
            //        genero = Genero.Indefinido,
            //        localizacao = new Coordenadas(),//new Coordenadas(24.12345, 25.12345),
            //        statusRebelde = StatusRebelde.Aliado,
            //        listaInventario = new Inventario() //new Inventario(1, "arma",4,1)
            //    }
            //    ) ;
            //;

            modelBuilder.HasDefaultSchema(UsedSchema);
            modelBuilder.Entity<MyEntity>(e =>
            {
                e.ToTable(nameof(MyEntity), UsedSchema);
                e.HasKey(p => p.Id);
            });

            modelBuilder.HasDefaultSchema(UsedSchema);
            modelBuilder.Entity <Rebelde>(e =>
            {
                e.ToTable(nameof(Rebelde), UsedSchema);
                e.HasKey(p => p.Id);
            });

            modelBuilder.HasDefaultSchema(UsedSchema);
            modelBuilder.Entity<Localizacao>(e =>
            {
                e.ToTable(nameof(Localizacao), UsedSchema);
                e.HasKey(p => p.Id);
            });

            modelBuilder.HasDefaultSchema(UsedSchema);
            modelBuilder.Entity<Inventario>(e =>
            {
                e.ToTable(nameof(Inventario), UsedSchema);
                e.HasKey(p => p.Id);
            });

        }
    }
}

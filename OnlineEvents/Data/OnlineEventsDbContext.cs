using System;
using Microsoft.EntityFrameworkCore;
using OnlineEvents.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace OnlineEvents.Data
{
    public partial class OnlineEventsDbContext : DbContext
    {
        public OnlineEventsDbContext()
        {
        }

        public OnlineEventsDbContext(DbContextOptions<OnlineEventsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> OnlineEvents { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<PhotoAlbum> PhotoAlbum { get; set; }

        public virtual DbSet<Source> Sources { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database= OnlineEventsDB; Trusted_Connection=True; MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}



#region The Second version of Football Dbcontext which created Events Table
//namespace OnlineEvents.Data
//{
//    public partial class FootballDbContext : DbContext
//    {
//        public FootballDbContext()
//        {
//        }

//        public FootballDbContext(DbContextOptions<FootballDbContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Event> OnlineEvents { get; set; }
//        public virtual DbSet<Player> Players { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database= FootballDb; Trusted_Connection=True; MultipleActiveResultSets=true;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

//            modelBuilder.Entity<Event>(entity =>
//            {
//                entity.Property(e => e.Title)
//                    .IsRequired()
//                    .HasMaxLength(30);
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}

#endregion

#region The Original Football Dbcontext which created Player Table
//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;
//using OnlineEvents.Models;

//#nullable disable

//namespace OnlineEvents.Data
//{
//    public partial class FootballDbContext : DbContext
//    {
//        public FootballDbContext()
//        {
//        }

//        public FootballDbContext(DbContextOptions<FootballDbContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Player> Players { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database= FootballDb; Trusted_Connection=True; MultipleActiveResultSets=true;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

//            modelBuilder.Entity<Player>(entity =>
//            {
//                entity.Property(e => e.Name)
//                    .IsRequired()
//                    .HasMaxLength(50);
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
#endregion
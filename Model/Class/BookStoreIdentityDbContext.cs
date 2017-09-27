namespace Model.Class
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using Migrations;
    using Interface;

    public partial class BookStoreIdentityDbContext : DbContext, IBookStoreIdentityDbContext
    {
        static BookStoreIdentityDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreIdentityDbContext, Configuration>());
            Database.SetInitializer<BookStoreIdentityDbContext>(new CreateDatabaseIfNotExists<BookStoreIdentityDbContext>());
        }
        public BookStoreIdentityDbContext()
            : base("name=BookStoreIdentityDbContext")
        {
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<PhanQuyen>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.PhanQuyen)
                .HasForeignKey(e => e.IDRole);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }

        

    }
}

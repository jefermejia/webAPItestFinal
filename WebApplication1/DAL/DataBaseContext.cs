using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplication1.DAL.Entities;

namespace WebApplication1.DAL
{
    public class DataBaseContext :DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); //aqui se creo el indice del campo name para la tabla countries 
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique(); //aqui se creo el indice del campo name para la tabla cities
        }

        #region DbSets 
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
 
        #endregion
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Tutorial.Car.DB.Schema.Models;

namespace Tutorial.Car.DB.Schema
{
    public class DatabaseContext : DbContext
	{
		readonly string _connectionString = "Server=DESKTOP-T5MPARQ;Initial Catalog=Tutorial.Car.Dev;Integrated Security=True;MultipleActiveResultSets=True";

		public DatabaseContext() { }

		public DatabaseContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var dbConnection = new SqlConnection(_connectionString);
	
			optionsBuilder.UseSqlServer(dbConnection);
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

            builder.Entity<Models.Car>(rest =>
            {
                rest.HasKey(x => x.ID);

                rest.Property(x => x.CarModel)
                    .IsRequired(true);

                rest.HasIndex(x => x.CarModel)
                    .IsUnique(true);

				rest.Property(x => x.Count)
					.IsRequired(true);
			});
        }

        public DbSet<Models.Car> Channels { get; set; }
    }
}

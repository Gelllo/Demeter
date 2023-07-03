using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Demeter.Domain.FoodDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Demeter.Infrastracture
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Food> Foods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
                var connString = configuration.GetConnectionString("DemeterConnection");
                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().ToTable("Foods").Property(x => x.Nutrients).HasConversion(
                v => JsonSerializer.Serialize(v, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }),
                v => JsonSerializer.Deserialize<List<Nutrient>>(v, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }),
                new ValueComparer<List<Nutrient>>(
                    (c1, c2) => JsonSerializer.Serialize(c1, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }) == JsonSerializer.Serialize(c2, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()
                ));

            modelBuilder.Entity<Meal>().ToTable("Meals")
                .HasMany(x => x.Foods)
                .WithOne(x => x.Meal)
                .HasForeignKey(x => x.MealID)
                .IsRequired();
        }
    }
}
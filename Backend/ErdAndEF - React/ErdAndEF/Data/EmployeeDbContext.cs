using ErdAndEF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ErdAndEF.Data
{
    public class EmployeeDbContext : IdentityDbContext<ApplicationUser>
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<EmployeeProjects> EmployeeProjectsDBset { get; set; }

        public DbSet<EmployeeTask> EmployeeTasksDb { get; set; }

        public DbSet<ITStocks> ITStocksDb { get; set; }

        public DbSet<Jobs> JobsDb { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // step 3
            modelBuilder.Entity<EmployeeProjects>().HasKey(pk => new { pk.ProjectID, pk.EmployeeID });

            // Define relationships
            modelBuilder.Entity<EmployeeProjects>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(e => e.EmployeeID);

            modelBuilder.Entity<EmployeeProjects>()
                .HasOne(ep => ep.Project)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(e => e.ProjectID);

            // Seed initial data
            modelBuilder.Entity<EmployeeProjects>().HasData(
                new EmployeeProjects { EmployeeID = 6 , ProjectID = 1 },
                new EmployeeProjects { EmployeeID = 6, ProjectID = 2 },
                new EmployeeProjects { EmployeeID = 7, ProjectID = 1 }
            );

            // Seed employees data (just to test)
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 6, FirstName = "Ahmad", LastName = "Mohsen", Email = "Anymail@gmail.com", Phone = "022555554" },
                new Employee { Id = 7, FirstName = "Essa", LastName = "Mohsen", Email = "Anymail@gmail.com", Phone = "022555554" }
            );

            // Seed projects data
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, ProjectName = "Project A", Budget = "8000 JD", Hours = 120 },
                new Project { Id = 2, ProjectName = "Project B", Budget = "12000 JD", Hours = 180 },
                new Project { Id = 3, ProjectName = "Project C", Budget = "15000 JD", Hours = 160 }
            );

            // Seed IT stocks data
            modelBuilder.Entity<ITStocks>().HasData(
                new ITStocks { Id = 1, Name = "Laptop", Category = "Laptop", Description = "Dell Latitude 5500", QuantityInStock = 5 },
                new ITStocks { Id = 2, Name = "Battery", Category = "Battery", Description = "Dell XPS 13 Battery", QuantityInStock = 10 },
                new ITStocks { Id = 3, Name = "Screen", Category = "Screen", Description = "15.6 inch FHD Screen", QuantityInStock = 8 },
                new ITStocks { Id = 4, Name = "RAM", Category = "RAM", Description = "8GB DDR4 RAM", QuantityInStock = 20 },
                new ITStocks { Id = 5, Name = "Hard Drive", Category = "Storage", Description = "1TB SSD", QuantityInStock = 15 },
                new ITStocks { Id = 6, Name = "Keyboard", Category = "Keyboard", Description = "Mechanical Keyboard", QuantityInStock = 12 },
                new ITStocks { Id = 7, Name = "Charger", Category = "Charger", Description = "65W USB-C Charger", QuantityInStock = 18 },
                new ITStocks { Id = 8, Name = "Motherboard", Category = "Laptop", Description = "Dell Latitude Motherboard", QuantityInStock = 4 }
            );

            // Seed jobs data
            modelBuilder.Entity<Jobs>().HasData(
                new Jobs { Id = 1, Title = "Network Issue Resolution", Description = "Fix WiFi connectivity issue in the office.", ScheduledDate = "", Priority = "High" },
                new Jobs { Id = 2, Title = "Install Software", Description = "Install Visual Studio on employee laptops.", ScheduledDate = "", Priority = "High" },
                new Jobs { Id = 3, Title = "Hardware Upgrade", Description = "Replace faulty RAM in server rack 1.", ScheduledDate = "", Priority = "Medium" },
                new Jobs { Id = 4, Title = "Printer Maintenance", Description = "Perform routine maintenance on printers in all offices.", ScheduledDate = "", Priority = "Low" },
                new Jobs { Id = 5, Title = "User Account Setup", Description = "Create new user accounts for incoming employees.", ScheduledDate = "", Priority = "Medium" }
            );

            // Seed roles
            SeedRoles(modelBuilder, "Admin", "CanCreate", "CanDelete");
            SeedRoles(modelBuilder, "User", "CanDelete");
        }

        private static void SeedRoles(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            var claimRoles = permissions.Select(permission => new IdentityRoleClaim<string>
            {
                Id = Guid.NewGuid().GetHashCode(),
                RoleId = role.Id,
                ClaimValue = permission
            }).ToArray();

            modelBuilder.Entity<IdentityRole>().HasData(role);
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(claimRoles);
        }
    }
}

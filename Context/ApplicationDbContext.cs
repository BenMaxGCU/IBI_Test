using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechTestIBI.Models;

namespace TechTestIBI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractGroup> ContractGroups { get; set; }
        public DbSet<ContractGroupContract> ContractGroupContracts { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ContractOrganisation> Organisations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContractGroupContract>(
                build =>
                {
                    build.HasKey(table => new
                    {
                        table.ContractGroupId,
                        table.ContractId
                    });
                    build.HasOne<Contract>().WithOne().HasPrincipalKey<Contract>(x => x.ContractId).HasForeignKey<ContractGroupContract>(qe => qe.ContractId);
                    build.HasOne<ContractGroup>().WithOne().HasPrincipalKey<ContractGroup>(x => x.ContractGroupId).HasForeignKey<ContractGroupContract>(qe => qe.ContractGroupId);
                });

            modelBuilder.Entity<ContractGroup>().HasKey(s => new { s.ContractGroupId });

            // Seeding sample data for Users
            modelBuilder.Entity<User>().HasData(new User { UserId = Guid.NewGuid(), Name = "Jeff" });
            modelBuilder.Entity<User>().HasData(new User { UserId = Guid.NewGuid(), Name = "Chuck" });
            modelBuilder.Entity<User>().HasData(new User { UserId = Guid.NewGuid(), Name = "Sarah" });
            modelBuilder.Entity<User>().HasData(new User { UserId = Guid.NewGuid(), Name = "Morgan" });

            // Seeding sample data for Contract
            modelBuilder.Entity<Contract>().HasData(new Contract { ContractId = 01, StartDateTime = DateTime.Now, EndDateTime = new DateTime(2050, 6, 28), RegionId = 578 });
            modelBuilder.Entity<Contract>().HasData(new Contract { ContractId = 02, StartDateTime = DateTime.Now, EndDateTime = new DateTime(2050, 6, 28), RegionId = 246 });
            modelBuilder.Entity<Contract>().HasData(new Contract { ContractId = 03, StartDateTime = DateTime.Now, EndDateTime = new DateTime(2050, 6, 28), RegionId = 208 });

            // Service data
            modelBuilder.Entity<Service>().HasData(new Service { ServiceId = 101, ServiceNumber = 24, ContractId = 01 });
            modelBuilder.Entity<Service>().HasData(new Service { ServiceId = 102, ServiceNumber = 25, ContractId = 02 });
            modelBuilder.Entity<Service>().HasData(new Service { ServiceId = 103, ServiceNumber = 26, ContractId = 03 });

            // Contract Group data
            modelBuilder.Entity<ContractGroup>().HasData(new ContractGroup { ContractGroupId = 001, Name = "Group1", OrganisationId = 130 });
            modelBuilder.Entity<ContractGroup>().HasData(new ContractGroup { ContractGroupId = 002, Name = "Group2", OrganisationId = 113 });
            modelBuilder.Entity<ContractGroup>().HasData(new ContractGroup { ContractGroupId = 003, Name = "Group3", OrganisationId = 147 });

            // Region data
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 208, RegionName = "Denmark" });
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 246, RegionName = "Finland" });
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 578, RegionName = "Norway" });
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 752, RegionName = "Sweden" });

            // Organisation data
            modelBuilder.Entity<ContractOrganisation>().HasData(new ContractOrganisation { OrganisationId = 130, OrgName = "Sweden Rail" });
            modelBuilder.Entity<ContractOrganisation>().HasData(new ContractOrganisation { OrganisationId = 113, OrgName = "FinnRail" });
            modelBuilder.Entity<ContractOrganisation>().HasData(new ContractOrganisation { OrganisationId = 142, OrgName = "Norway Transport" });
            modelBuilder.Entity<ContractOrganisation>().HasData(new ContractOrganisation { OrganisationId = 147, OrgName = "Denmark Transport" });
        }
    }
}

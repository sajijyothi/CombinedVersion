using SCNEXTCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SCNEXTCoreApp.Models.Master;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SCNEXTCoreApp.Data.Master
{
    public class GeneralDbContext : DbContext
    {

        public GeneralDbContext(DbContextOptions<GeneralDbContext> options)
        : base(options)
        {
            //Database.EnsureCreated();

        }


        public DbSet<Brand> brand  {get; set;}

        public DbSet<Manufacturer> manufacturer{get; set;}

        public DbSet<Currency> currency {get; set;}

        public DbSet<Department> department {get; set;}

        public DbSet<JobStatus> jobStatus {get; set;}

        public DbSet<VehicleLicenceType> vehicleLicenceType {get; set;}

        public DbSet<Country> country {get; set;}

        public DbSet<State> state {get; set;}

        public DbSet<City> city {get; set;}

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        
        public DbSet<EmpSkillSet> EmpSkillSet { get; set; }

        public DbSet<VehPlatePrefix> VehPlatePrefix { get; set; }

        public DbSet<VehMake> VehMake { get; set; }

        public DbSet<VehBrand> VehBrand { get; set; }

        public DbSet<VehOwnrType> VehOwnrType { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<DgClassDangerous> DgClassDangerous { get; set; }

        public DbSet<ReOrderingFlowFreq> ReOrderingFlowFreq { get; set; }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        public DbSet<Address> Address { get; set; }
        public DbSet<Vehicletype> vehicletype
        {
            get; set;

        }
        public DbSet<pimcategory> pimcategory
        {
            get; set;

        }
        public DbSet<pimcategorytype> pimcategorytype
        {
            get; set;

        }
        public DbSet<vehowner> vehowner
        {
            get; set;

        }
        public DbSet<Uom> Uom { get; set; }

        public DbSet<taxmaster> taxmaster { get; set; }   

        public DbSet<VehPermit> VehPermit { get; set; }

        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<VehGearType> VehGearType { get; set; }

        public DbSet<binarea> binarea { get; set; }

        public DbSet<CompanyDet> CompanyDet { get; set; }

        public DbSet<OUType> OUType { get; set; }

        public DbSet<HSCode> HSCode { get; set; }

    }
}

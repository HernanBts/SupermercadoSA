using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SupermercadoSA.Models
{
    public class SupermercadoSAContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SupermercadoSAContext() : base("name=SupermercadoSAContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.Characteristic> Characteristics { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.Package> Packages { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.Bromatologist> Bromatologists { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.Purchase> Purchases { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.MR> MRs { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.Satisfy> Satisfies { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.Verification> Verifications { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.Control> Controls { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.File> Files { get; set; }

        public System.Data.Entity.DbSet<SupermercadoSA.Models.Batch> Batches { get; set; }
    }
}

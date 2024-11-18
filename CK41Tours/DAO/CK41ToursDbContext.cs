using CK41Tours.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CK41Tours.DAO
{
    public class CK41ToursDbContext:DbContext
    {
        public CK41ToursDbContext(DbContextOptions<CK41ToursDbContext> options) : base(options) { }
       public DbSet<DTEntity> DTs { get; set; }
        public DbSet<TGEntity> TGs {  get; set; }
        public DbSet<TMEntity> TMEs { get; set; }
        public DbSet<TTEntity> TTs { get; set; }
        public DbSet<DDEntity> DDs { get; set; }
    }
}

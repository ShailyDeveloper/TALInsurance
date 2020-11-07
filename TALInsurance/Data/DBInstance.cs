using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TALInsurance.Models;

namespace TALInsurance.Data
{
    public class DBInstance : DbContext
    {
        public DBInstance(DbContextOptions<DBInstance> pro) : base(pro)
        {

        }
        public DbSet<tblClientData> tblClientData { get; set; }
        public DbSet<tblOccupationMapping> tblOccupationMapping { get; set; }
        public DbSet<tblOccupationRating> tblOccupationRating { get; set; }
    }
}

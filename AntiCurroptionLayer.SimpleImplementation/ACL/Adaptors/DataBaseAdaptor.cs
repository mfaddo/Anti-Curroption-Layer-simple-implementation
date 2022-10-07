using AntiCurroptionLayer.SimpleImplementation.ACL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiCurroptionLayer.SimpleImplementation.ACL.Adaptors
{
    public class DataBaseAdaptor : DbContext
    {
        public DataBaseAdaptor() : base()
        {
        }
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         

            modelBuilder
                .Entity<Item>()
                .ToView("ITEMS_VIEW")
                .HasNoKey();

        }
    }
}

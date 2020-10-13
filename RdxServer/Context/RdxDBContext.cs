using Microsoft.EntityFrameworkCore;
using RdxServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Context
{
    public class RdxDBContext : DbContext
    {
        public RdxDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DeviceEvent> DeviceEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //.Entity<DeviceEvent>()
            //.Property(e => e.UnixTimestamp)
            //.HasConversion(v => v, v => DateTime.SpecifyKind(new DateTime(v), DateTimeKind.Utc).Ticks);
        }
    }
}


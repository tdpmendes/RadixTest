using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RdxServer.Context;
using RdxServer.Entities;
using RdxServer.Repositories;
using RdxServer.Repositories.Interfaces;

namespace RdxTests
{
    public class Tests
    {
        private RdxDBContext context;
        private IDeviceEventRepository repository;
        private readonly string ConnectionString = "Server=127.0.0.1,1433;Database=RdxServerDB;User=sa;Password=@dm1n1str@t0r;MultipleActiveResultSets=true";

        [OneTimeSetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<RdxDBContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            // this.optionsBuilder = optionsBuilder;
            context = new RdxDBContext(optionsBuilder.Options);

            repository = new DeviceEventRepository(context);
        }

        [Test]
        public void GetById()
        {
            DeviceEvent evt = repository.GetById(9).Result;
            Assert.IsNotNull(evt);
        }
    }
}
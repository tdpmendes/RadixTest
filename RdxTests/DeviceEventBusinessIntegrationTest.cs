using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RdxServer.Business;
using RdxServer.Business.Interfaces;
using RdxServer.Context;
using RdxServer.DTO;
using RdxServer.Repositories;
using RdxServer.Repositories.Interfaces;
using RdxServer.Validators;
using RdxServer.Validators.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RdxTests
{
    public class DeviceEventBusinessIntegrationTest
    {
        private RdxDBContext context;
        private IDeviceEventRepository repository;
        private IEventBusiness business;
        private IValidatable<DeviceEventDTO> validator;
        private readonly string ConnectionString = "Server=127.0.0.1,1433;Database=RdxServerDB;User=sa;Password=@dm1n1str@t0r;MultipleActiveResultSets=true";

        private string testTag = "brasil.sudeste.testSensor01";

        [OneTimeSetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<RdxDBContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            context = new RdxDBContext(optionsBuilder.Options);

            repository = new DeviceEventRepository(context);
            validator = new DeviceEventDTOValidator();
            business = new EventBusiness(validator, repository);

        }

        [Test]
        public void should_record_device_event_with_value_type_str_when_value_not_integer()
        {
            DeviceEventDTO request = new DeviceEventDTO();
            request.Timestamp = 1539112021301;
            request.Tag = testTag;
            request.Valor = "test";

            var response = business.ProcessEvent(request).Result;

            string[] tagSplit = testTag.Split('.');
            var dvcEvts = repository.FindBy(d => d.Country == tagSplit[0] && d.Region == tagSplit[1] && d.DeviceName == tagSplit[2] && d.ValueType == "STR").Result.ToList();

            Assert.IsTrue(dvcEvts.Any());
            Assert.AreEqual("success", response.ShortMessage);
        }

        [Test]
        public void should_record_device_event_with_value_type_int_when_value_is_int()
        {
            DeviceEventDTO request = new DeviceEventDTO();
            request.Timestamp = 1539112021301;
            request.Tag = testTag;
            request.Valor = "123";

            var response = business.ProcessEvent(request).Result;

            string[] tagSplit = testTag.Split('.');
            var dvcEvts = repository.FindBy(d => d.Country == tagSplit[0] && d.Region == tagSplit[1] && d.DeviceName == tagSplit[2] && d.ValueType == "INT").Result.ToList();

            Assert.IsTrue(dvcEvts.Any());

            Assert.AreEqual("success", response.ShortMessage);

        }

        [Test]
        public void should_record_device_event_with_status_error_when_value_is_empty()
        {
            DeviceEventDTO request = new DeviceEventDTO();
            request.Timestamp = 1539112021301;
            request.Tag = testTag;
            request.Valor = "";

            var response = business.ProcessEvent(request).Result;
            
            string[] tagSplit = testTag.Split('.');
            var dvcEvts = repository.FindBy(d => d.Country == tagSplit[0] && d.Region == tagSplit[1] && d.DeviceName == tagSplit[2] && d.Status == 1).Result.ToList();

            Assert.IsTrue(dvcEvts.Any());
            Assert.AreEqual("success", response.ShortMessage);

        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            string[] tagSplit = testTag.Split('.');
            var dvcEvts = repository.DeleteMany(d => d.Country == tagSplit[0] && d.Region == tagSplit[1] && d.DeviceName == tagSplit[2]);
        }
    }
}
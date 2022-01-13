using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RdxDevice.Config;
using RdxDevice.Helpers;
using RdxDevice.Message;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RdxDevice
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private static RdxDeviceConfig rdxDeviceConfig;
        private static RdxApiSettingsConfig rdxApiSettingsConfig;
        private static HttpClientHandler httpClientHandler = new HttpClientHandler();
        private static HttpClient client;

        public static RdxApiSettingsConfig RdxApiSettingsConfig { get => rdxApiSettingsConfig; set => rdxApiSettingsConfig = value; }

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => {
                    return true;   //Is valid
            };
            client = new HttpClient(httpClientHandler);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               //.AddUserSecrets<Program>()
               .AddEnvironmentVariables();

                IConfigurationRoot configuration = builder.Build();

                rdxDeviceConfig = new RdxDeviceConfig()
                {
                    Country = Environment.GetEnvironmentVariable("COUNTRY"),
                    DeviceName = Environment.GetEnvironmentVariable("DEVICE_NAME"),
                    MinValToSend = Environment.GetEnvironmentVariable("MIN_VAL_TO_SEND"),
                    MaxValToSend = Environment.GetEnvironmentVariable("MAX_VAL_TO_SEND"),
                    Region = Environment.GetEnvironmentVariable("REGION")
                };
                RdxApiSettingsConfig = new RdxApiSettingsConfig();

                //configuration.GetSection("DeviceProperties").Bind(rdxDeviceConfig);
                configuration.GetSection("ApiSettings").Bind(RdxApiSettingsConfig);

                client.BaseAddress = new Uri(RdxApiSettingsConfig.ApiBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var message = new DeviceMessage();

                int min;
                int max;

                int.TryParse(rdxDeviceConfig.MinValToSend, out min);
                int.TryParse(rdxDeviceConfig.MaxValToSend, out max);

                Random rand = new Random(DateTime.Now.Millisecond);

                message.Timestamp = DeviceHelpers.ToUnixTimeStamp(DateTime.Now);
                message.Tag = DeviceHelpers.TagFromConfig(rdxDeviceConfig);
                message.Valor = rand.Next(min, max).ToString();

                HttpResponseMessage response = client.PostAsync(RdxApiSettingsConfig.ApiRoute, 
                                                                new StringContent(JsonConvert.SerializeObject(message), 
                                                                Encoding.UTF8, 
                                                                "application/json")).Result;

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

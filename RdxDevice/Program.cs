using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RdxDevice.Config;
using RdxDevice.Helpers;
using RdxDevice.Message;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace RdxDevice
{
    class Program
    {
        private static RdxDeviceConfig rdxDeviceConfig;
        private static RdxApiSettingsConfig rdxApiSettingsConfig;

        private static HttpClient client = new HttpClient();

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddUserSecrets<Program>()
               .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            rdxDeviceConfig = new RdxDeviceConfig();
            rdxApiSettingsConfig = new RdxApiSettingsConfig();

            configuration.GetSection("DeviceProperties").Bind(rdxDeviceConfig);
            configuration.GetSection("ApiSettings").Bind(rdxApiSettingsConfig);

            client.BaseAddress = new Uri(rdxApiSettingsConfig.ApiBaseUrl);
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

            HttpResponseMessage response = client.PostAsync(rdxApiSettingsConfig.ApiRoute, new StringContent(JsonConvert.SerializeObject(message),Encoding.UTF8,"application/json")).Result;
        }
    }
}

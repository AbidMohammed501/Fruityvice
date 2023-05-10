using Microsoft.Extensions.Configuration;

namespace FruityviceAPI
{
    public class ConfigSettings
    {
        private readonly IConfiguration _configuration;
        public ConfigSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string EndpointUrl => _configuration.GetValue<string>("MySetting");

        //public string method()
        //{
        //    try
        //    {
        //        var mySettingValue = _configuration.GetValue<string>("MySetting");
        //        return mySettingValue;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}

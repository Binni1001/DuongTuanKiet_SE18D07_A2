using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DuongTuanKietWPF.DataAccess.Configuration
{
    public static class ConfigurationHelper
    {
        private static IConfiguration? _configuration;

        public static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                    _configuration = builder.Build();
                }
                return _configuration;
            }
        }

        public static string GetConnectionString(string name = "DefaultConnection")
        {
            return Configuration.GetConnectionString(name) 
                ?? throw new InvalidOperationException($"Connection string '{name}' not found.");
        }

        public static T GetSection<T>(string sectionName) where T : new()
        {
            var section = new T();
            Configuration.GetSection(sectionName).Bind(section);
            return section;
        }
    }

    public class AdminAccount
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

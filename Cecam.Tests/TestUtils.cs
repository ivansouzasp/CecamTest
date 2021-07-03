using System;
using Cecam.Utils;
using Microsoft.Extensions.Configuration;

namespace Cecam.Tests
{
    public class TestUtils
    {
        public static IConfiguration CreateConfigurationBuilder()
        {
            IConfiguration configuration = null;
            OperationalSystem operatingSystem = OperationalSystem.None;
            string basePath = string.Empty;
            Version environmmentVersion = System.Environment.Version;
            string systemEnvironmentVersion = string.Empty;
            try
            {
                operatingSystem = GeneralUtils.GetOperationalSystem();
                systemEnvironmentVersion = String.Format("{0}{1}{2}", environmmentVersion.Major.ToString(), ".", environmmentVersion.Minor.ToString());
                basePath = AppDomain.CurrentDomain.BaseDirectory;
                switch (operatingSystem)
                {
                    case OperationalSystem.Windows:
                        basePath = basePath.Replace($@"\bin\Debug\net{systemEnvironmentVersion}", String.Empty);
                        break;
                    case OperationalSystem.MAC:
                        basePath = basePath.Replace($@"/bin/Debug/net{systemEnvironmentVersion}", String.Empty);
                        break;
                }

                var builder = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json");
                configuration = builder.Build();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return configuration;
        }
    }
}

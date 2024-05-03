using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestore_prestiti_libri.Utilities
{
    internal class Config
    {
        #region singleton   
        /* quando creiamo un oggetto viene istanziato una sola volta */
        private static Config? istanza;
        private string? connectionString;

        public static Config getIstanza() { 
            if(istanza == null)
                istanza = new Config();

            return istanza;
        }

        private Config()
        {

        }
        #endregion
        public string? GetConnectionString()
        {
            if (connectionString == null)
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appSettings.json", optional: false, reloadOnChange: false);

                IConfiguration configuration = builder.Build();
#if DEBUG
                connectionString = configuration.GetConnectionString("ServerLocale");
#else
                connectionString = configuration.GetConnectionString("ServerRemota");
#endif
            }

            return connectionString;
        }
    }
}

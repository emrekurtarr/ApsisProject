using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.CardService.Configs
{
    public class DatabaseSettings : IDatabaseSettings
    {
        // Options Pattern
        public string CreditCardCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

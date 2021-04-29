using System;
using System.Collections.Generic;
using Acme.LoanCalculator.Core.Application;

namespace Acme.LoanCalculator.Infrastructure
{
    public class ConfigurationAdapterStub : IConfigurationPort
    {
        private static readonly Dictionary<string, string> ConfigSourceDictionary = new Dictionary<string, string>()
        {
            ["AnnualInterestRate"] = "5,00",
            ["InstallmentInterval"] = "Month",
            ["AdministrationFeeRate"] = "1,00",
            ["MaximumAdministrationFee"] = "10000"

        };

        public string GetConfigValue(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (ConfigSourceDictionary.TryGetValue(key, out var value))
            {
                return value;
            }
            return String.Empty;
        }
    }
}

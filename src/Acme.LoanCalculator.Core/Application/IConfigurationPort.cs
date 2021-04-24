namespace Acme.LoanCalculator.Core.Application
{
    public interface IConfigurationPort
    {
        public string GetConfigValue(string key);
    }
}
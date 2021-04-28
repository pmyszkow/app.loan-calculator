using Acme.LoanCalculator.Core.Application;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Infrastructure
{
    public class ConfigurationAdapterStub : IConfigurationPort
    {
        public Percent AnnualInterestRate => new Percent(5m);
        public TimeInterval InstallmentInterval => TimeInterval.Month;
        public Percent AdministrationFeeRate => new Percent(1m);
        public Money MaximumAdministrationFee => Money.FromDanishCrones(10000m);
    }
}

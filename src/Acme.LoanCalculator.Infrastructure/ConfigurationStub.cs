using System;
using Acme.LoanCalculator.Core.Application;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Infrastructure
{
    public class ConfigurationStub : IConfigurationPort
    {
        public Percent AnnualInterestRate => new Percent(5m);
        public TimeInterval PaymentInterval => TimeInterval.Month;
        public Percent CommisionRate => new Percent(1m);
        public Money MaximumCommision => new Money(10000m, Currency.DanishCrone);
    }
}

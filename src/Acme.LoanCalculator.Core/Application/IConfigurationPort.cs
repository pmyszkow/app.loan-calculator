using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Application
{
    public interface IConfigurationPort
    {
        Percent AnnualInterestRate { get; }

        TimeInterval PaymentInterval { get; }

        Percent CommisionRate { get; }

        Money MaximumCommision { get; }
    }
}
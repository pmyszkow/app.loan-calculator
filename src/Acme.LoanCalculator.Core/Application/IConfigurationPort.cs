using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Application
{
    public interface IConfigurationPort
    {
        Percent AnnualInterestRate { get; }

        TimeInterval InstallmentInterval { get; }

        Percent AdministrationFeeRate { get; }

        Money MaximumAdministrationFee { get; }
    }
}
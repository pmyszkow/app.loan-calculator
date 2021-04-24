using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public interface IAdministrationFeeCalculationPolicy
    {
        Money Calculate(Money due, AdministrationFeeTerms terms);
    }
}
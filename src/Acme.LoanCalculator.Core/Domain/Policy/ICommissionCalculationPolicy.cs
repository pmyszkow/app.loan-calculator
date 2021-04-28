using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public interface ICommissionCalculationPolicy
    {
        Money Calculate(Money due, CommissionTerms terms);
    }
}
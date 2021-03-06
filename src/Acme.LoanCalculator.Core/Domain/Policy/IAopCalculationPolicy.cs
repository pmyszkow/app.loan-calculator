using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public interface IAopCalculationPolicy
    {
        Percent Calculate(Money due, Money totalInterest, Money administrationFee, NaturalQuantity monthsCount);
    }
}
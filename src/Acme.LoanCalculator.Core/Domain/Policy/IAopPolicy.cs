using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public interface IAopPolicy
    {
        Percent Calculate(Money due, Money totalInterest, Money commission, NaturalQuantity monthsCount);
    }
}
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public interface IAopPolicy
    {
        Percent Calculate(Money debt, Money totalInterest, Money commission, Period duration);
    }
}
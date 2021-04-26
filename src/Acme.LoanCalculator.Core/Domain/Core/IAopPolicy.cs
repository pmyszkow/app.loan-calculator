using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public interface IAopPolicy
    {
        Percent Calculate(Money amount, Money totalInterest, Money commission, MonthsDuration duration);
    }
}
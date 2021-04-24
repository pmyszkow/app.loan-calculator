using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public interface ICommissionPolicy
    {
        Money Calculate(Money loanAmount);
    }
}
using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public interface IPaymentSeriesFactory
    {
        PaymentSeries Generate(Money loanAmount, MonthsDuration duration, AnnualInterestRate interestRate);
    }
}
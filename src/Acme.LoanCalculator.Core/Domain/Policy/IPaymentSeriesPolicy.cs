using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public interface IPaymentSeriesPolicy
    {
        PaymentSeries Generate(Money debt, Period duration, Percent cycleInterestRate);
    }
}
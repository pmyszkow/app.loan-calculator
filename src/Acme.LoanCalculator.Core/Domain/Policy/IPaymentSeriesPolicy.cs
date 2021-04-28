using System.Collections.Generic;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public interface IPaymentSeriesPolicy
    {
        IList<Payment> Generate(Money dueAmount, NaturalQuantity cyclesCount, Percent cycleInterestRate);
    }
}
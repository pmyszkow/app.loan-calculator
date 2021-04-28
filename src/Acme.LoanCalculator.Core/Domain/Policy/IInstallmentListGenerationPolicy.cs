using System.Collections.Generic;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public interface IInstallmentListGenerationPolicy
    {
        IList<Installment> Generate(Money dueAmount, NaturalQuantity installmentsCount, Percent installmentInterestRate);
    }
}
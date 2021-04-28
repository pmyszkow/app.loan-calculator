using System;
using System.Collections.Generic;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public class InstallmentListGenerationPolicy : IInstallmentListGenerationPolicy
    {
        public IList<Installment> Generate(Money dueAmount, NaturalQuantity installmentsCount, Percent installmentInterestRate)
        {
            if (dueAmount == null) throw new ArgumentNullException(nameof(dueAmount));
            if (installmentsCount == null) throw new ArgumentNullException(nameof(installmentsCount));
            if (installmentInterestRate == null) throw new ArgumentNullException(nameof(installmentInterestRate));

            var installments = new List<Installment>();
            Money remainingDueAmount = dueAmount;

            decimal installmentValue = CalculateInstallmentTotalAmount(dueAmount.Value, installmentsCount.Value, Convert.ToDouble(installmentInterestRate.DecimalFraction));
            Money installmentTotalAmount = new Money(installmentValue, dueAmount.Currency);

            for (var installmentNumber = 1; installmentNumber <= installmentsCount.Value; installmentNumber++)
            {
                bool isLastInstallment = installmentNumber == installmentsCount.Value;

                Money installmentInterestPart = remainingDueAmount * installmentInterestRate;
                Installment currentInstallment = isLastInstallment
                    ? new Installment(new NaturalQuantity(installmentNumber), remainingDueAmount, installmentInterestPart)
                    : Installment.FromTotalAmountAndInterestPart(new NaturalQuantity(installmentNumber), installmentTotalAmount, installmentInterestPart);

                installments.Add(currentInstallment);

                remainingDueAmount -= currentInstallment.CapitalPart;
            }

            return installments;
        }

        private decimal CalculateInstallmentTotalAmount(decimal dueAmount, int cyclesCount, double cycleInterestRate)
        {
            var poweredElement = Math.Pow(1 + cycleInterestRate, cyclesCount);

            var factor = (cycleInterestRate * poweredElement) / (poweredElement - 1);

            return dueAmount * Convert.ToDecimal(factor);
        }
    }
}
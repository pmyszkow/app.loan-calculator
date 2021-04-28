using System;
using System.Collections.Generic;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public class AnnuityPaymentSeriesPolicy : IPaymentSeriesPolicy
    {
        public IList<Payment> Generate(Money dueAmount, NaturalQuantity cyclesCount, Percent cycleInterestRate)
        {
            if (dueAmount == null) throw new ArgumentNullException(nameof(dueAmount));
            if (cyclesCount == null) throw new ArgumentNullException(nameof(cyclesCount));
            if (cycleInterestRate == null) throw new ArgumentNullException(nameof(cycleInterestRate));

            var paymentsList = new List<Payment>();
            var remainingDue = dueAmount;

            var annuityPaymentAmount = CalculateCyclePaymentAmount(dueAmount.Value, cyclesCount.Value, Convert.ToDouble(cycleInterestRate.DecimalFraction));
            var annuityPayment = new Money(annuityPaymentAmount, dueAmount.Currency);

            for (var cycleNumber = 1; cycleNumber <= cyclesCount.Value; cycleNumber++)
            {
                var isLastCycle = cycleNumber == cyclesCount.Value;

                var cycleInterest = remainingDue * cycleInterestRate.DecimalFraction;
                var cyclePayment = isLastCycle
                    ? new Payment(cycleNumber, remainingDue, cycleInterest)
                    : Payment.FromTotalAndInterest(cycleNumber, annuityPayment, cycleInterest);

                paymentsList.Add(cyclePayment);

                remainingDue -= cyclePayment.Installment;
            }

            return paymentsList;
        }

        private decimal CalculateCyclePaymentAmount(decimal dueAmount, int cyclesCount, double cycleInterestRate)
        {
            var poweredElement = Math.Pow(1 + cycleInterestRate, cyclesCount);

            var factor = (cycleInterestRate * poweredElement) / (poweredElement - 1);

            return dueAmount * Convert.ToDecimal(factor);
        }
    }
}
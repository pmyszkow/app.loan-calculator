using System;
using System.Collections.Generic;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public class AnnuityPaymentSeriesPolicy : IPaymentSeriesPolicy
    {
        public PaymentSeries Generate(Money debt, Period duration, Percent cycleInterestRate)
        {
            if (debt == null) throw new ArgumentNullException(nameof(debt));
            if (duration == null) throw new ArgumentNullException(nameof(duration));
            if (cycleInterestRate == null) throw new ArgumentNullException(nameof(cycleInterestRate));

            var cyclePayments = new List<Payment>();
            var remainingDebt = debt;

            decimal annuityPaymentAmount = CalculateCyclePaymentAmount(debt.Amount, duration.Cycles, Convert.ToDouble(cycleInterestRate.DecimalFraction));
            var annuityPayment = new Money(annuityPaymentAmount, debt.Currency);

            for (var cycleNumber = 1; cycleNumber <= duration.Cycles; cycleNumber++)
            {
                var isLastCycle = cycleNumber == duration.Cycles;

                var cycleInterest = remainingDebt * cycleInterestRate.DecimalFraction;
                var cyclePayment = isLastCycle
                    ? new Payment(cycleNumber, remainingDebt, cycleInterest)
                    : Payment.FromTotalAndInterest(cycleNumber, annuityPayment, cycleInterest);

                cyclePayments.Add(cyclePayment);

                remainingDebt -= cyclePayment.Installment;
            }

            return new PaymentSeries(cyclePayments);
        }

        private decimal CalculateCyclePaymentAmount(decimal debt, int cycles, double cycleRate)
        {
            double poweredElement = Math.Pow(1 + cycleRate, cycles);

            double factor = (cycleRate * poweredElement) / (poweredElement - 1);

            return debt * Convert.ToDecimal(factor);
        }
    }
}
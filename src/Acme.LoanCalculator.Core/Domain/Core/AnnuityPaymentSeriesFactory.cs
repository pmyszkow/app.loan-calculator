using System;
using System.Collections.Generic;
using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public sealed class AnnuityPaymentSeriesFactory : IPaymentSeriesFactory
    {
        public PaymentSeries Generate(Money loanAmount, Duration duration, AnnualInterestRate interestRate)
        {
            var paymentList = new List<Payment>();
            Money remainingLoanAmount = loanAmount;

            var annuityAmount =  CalculateAnnuityPayment(loanAmount.Amount, (double) interestRate.GetMonthPercents().GetRate(), duration.Months);
            Money cyclePayment = new  Money(annuityAmount, loanAmount.Currency);

            for (int i = 1; i <= duration.Months; i++)
            {
                var currentInterest = loanAmount * interestRate.GetMonthPercents().GetRate();
                var currentPayment = Payment.FromTotalAndInterest(i, cyclePayment, currentInterest);
                paymentList.Add(currentPayment);

                remainingLoanAmount = remainingLoanAmount - currentPayment.Instalment;
            }

            return new PaymentSeries(paymentList);
        }

        private decimal CalculateAnnuityPayment(decimal loanAmount, double cycleRate, int cyclesCount)
        {
            double poweredElement = Math.Pow(1 + cycleRate, cyclesCount);

            double annuityFactor = (cycleRate * poweredElement) / (poweredElement - 1);

            return loanAmount * Convert.ToDecimal(annuityFactor);
        }
    }
}
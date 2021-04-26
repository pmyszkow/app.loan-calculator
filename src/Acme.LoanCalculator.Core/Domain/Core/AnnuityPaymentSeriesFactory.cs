﻿using System;
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

            var annuityAmount =  CalculateAnnuityPayment(loanAmount.Amount, (double) interestRate.GetMonthlyPercentage().GetRate(), duration.MonthCount);
            Money cyclePayment = new  Money(annuityAmount, loanAmount.Currency);

            for (int i = 1; i <= duration.MonthCount; i++)
            {
                var currentInterest = loanAmount * interestRate.GetMonthlyPercentage().GetRate();
                var currentPayment = Payment.FromChargeAndInterest(cyclePayment, currentInterest, i);
                paymentList.Add(currentPayment);

                remainingLoanAmount = remainingLoanAmount - currentPayment.Installment;
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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public sealed class LoanCalculationBuilder
    {
        private readonly ICommissionPolicy _commissionPolicy;
        private readonly IAopPolicy _aopPolicy;

        public LoanCalculationBuilder(ICommissionPolicy commissionPolicy, IAopPolicy aopPolicy)
        {
            _commissionPolicy = commissionPolicy ?? throw new ArgumentNullException(nameof(commissionPolicy));
            _aopPolicy = aopPolicy ?? throw new ArgumentNullException(nameof(aopPolicy));
            Amount = Money.Zero;
            Currency = Currency.Default;
            Commission= Money.Zero;
            Duration = MonthsDuration.Zero;
            InterestRate = AnnualInterestRate.Zero;
            PaymentSeries = new PaymentSeries(new ReadOnlyCollection<Payment>(new List<Payment>()), Money.Zero);
            Aop = PercentRate.Zero;
        }

        private Money Amount { get; set; }

        private Currency Currency { get; set; }

        private Money Commission { get; set; }

        private MonthsDuration Duration { get; set; }

        private AnnualInterestRate InterestRate { get; set; }

        private PaymentSeries PaymentSeries { get; set; }

        private PercentRate Aop { get; set; }

        public LoanCalculationBuilder WithAmount(Money amount)
        {
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            Currency = amount.Currency;
            Commission = _commissionPolicy.Calculate(amount);
            return this;
        }

        public LoanCalculationBuilder WithDuration(MonthsDuration duration)
        {
            Duration = duration ?? throw new ArgumentNullException(nameof(duration));
            return this;
        }

        public LoanCalculationBuilder WithInterestRate(AnnualInterestRate interestRate)
        {
            InterestRate = interestRate ?? throw new ArgumentNullException(nameof(interestRate));
            return this;
        }

        public LoanCalculation Build()
        {
            var paymentSeriesBuilder = new PaymentSeriesBuilder();
            PaymentSeries = paymentSeriesBuilder.Build();

            var totalInterest = PaymentSeries.TotalInterest;
            Aop = _aopPolicy.Calculate(Amount, totalInterest, Commission, Duration);

            return new LoanCalculation(Amount, Currency, Duration, Commission, InterestRate, PaymentSeries, Aop);
        }
    }
}
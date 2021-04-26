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
        private readonly IPaymentSeriesFactory _paymentSeriesFactory;

        public LoanCalculationBuilder(ICommissionPolicy commissionPolicy, IAopPolicy aopPolicy, IPaymentSeriesFactory paymentSeriesFactory)
        {
            _commissionPolicy = commissionPolicy ?? throw new ArgumentNullException(nameof(commissionPolicy));
            _aopPolicy = aopPolicy ?? throw new ArgumentNullException(nameof(aopPolicy));
            _paymentSeriesFactory = paymentSeriesFactory ?? throw new ArgumentNullException(nameof(paymentSeriesFactory));
            Amount = Money.Zero;
            Currency = Currency.Default;
            Commission= Money.Zero;
            Duration = MonthsDuration.Zero;
            InterestRate = AnnualInterestRate.Zero;
            PaymentSeries = new PaymentSeries(new ReadOnlyCollection<Payment>(new List<Payment>()));
            Aop = Percent.Zero;
        }

        private Money Amount { get; set; }

        private Currency Currency { get; set; }

        private Money Commission { get; set; }

        private MonthsDuration Duration { get; set; }

        private AnnualInterestRate InterestRate { get; set; }

        private PaymentSeries PaymentSeries { get; set; }

        private Percent Aop { get; set; }

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
            PaymentSeries = _paymentSeriesFactory.Generate(Amount, Duration, InterestRate);

            return new LoanCalculation(Amount, Currency, Duration, Commission, InterestRate, PaymentSeries, Aop);
        }
    }
}
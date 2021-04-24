using Acme.LoanCalculator.Core.Domain.Capability;
using Acme.LoanCalculator.Core.Domain.Policy;
using NUnit.Framework;

namespace Acme.LoanCalculator.Core.Tests.Policy
{
    [TestFixture]
    public class AdministrationFeeCalculationPolicy_Calculate_Should
    {
        private AdministrationFeeTerms _feeTerms;
        private Percent _feeRate;
        private Money _maximumFee;

        [SetUp]
        public void SetUp()
        {
            _feeRate = new Percent(1.0m);
            _maximumFee = new Money(10000m, Currency.DanishCrone);
            _feeTerms = new AdministrationFeeTerms(_feeRate, _maximumFee);
        }

        [Test]
        public void Calculated_fee_if_is_lower_than_maximum_fee()
        {
            var feeCalculationPolicy = new AdministrationFeeCalculationPolicy();

            var dueAmount = new Money(500000m, Currency.DanishCrone);
            var expectedFee = dueAmount * _feeRate;

            var calculatedFee = feeCalculationPolicy.Calculate(dueAmount, _feeTerms);

            Assert.IsTrue(calculatedFee == expectedFee);
        }

        [Test]
        public void Maximum_fee_if_calculated_is_greater_than_maximum_fee()
        {
            var feeCalculationPolicy = new AdministrationFeeCalculationPolicy();

            var dueAmount = new Money(5000000m, Currency.DanishCrone);

            var calculatedFee = feeCalculationPolicy.Calculate(dueAmount, _feeTerms);

            Assert.IsTrue(calculatedFee == _maximumFee);
        }
    }
}
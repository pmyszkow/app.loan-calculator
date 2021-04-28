using System;
using System.ComponentModel;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Application
{
    public class PaymentOverviewOutput
    {
        public PaymentOverviewOutput(Money dueAmount, NaturalQuantity installmentsCount, Percent annualInterestRate, TimeInterval installmentsInterval, Percent administrationFeeRate, Money maximumAdministrationFee, Percent aop, Money totalInterestAmount, Money administrationFee, Money totalInstallmentAmount)
        {
            if (!Enum.IsDefined(typeof(TimeInterval), installmentsInterval))
                throw new InvalidEnumArgumentException(nameof(installmentsInterval), (int) installmentsInterval,
                    typeof(TimeInterval));
            DueAmount = dueAmount ?? throw new ArgumentNullException(nameof(dueAmount));
            InstallmentsCount = installmentsCount ?? throw new ArgumentNullException(nameof(installmentsCount));
            AnnualInterestRate = annualInterestRate ?? throw new ArgumentNullException(nameof(annualInterestRate));
            InstallmentsInterval = installmentsInterval;
            AdministrationFeeRate = administrationFeeRate ?? throw new ArgumentNullException(nameof(administrationFeeRate));
            MaximumAdministrationFee = maximumAdministrationFee ?? throw new ArgumentNullException(nameof(maximumAdministrationFee));
            Aop = aop ?? throw new ArgumentNullException(nameof(aop));
            TotalInterestAmount = totalInterestAmount ?? throw new ArgumentNullException(nameof(totalInterestAmount));
            AdministrationFee = administrationFee ?? throw new ArgumentNullException(nameof(administrationFee));
            TotalInstallmentAmount = totalInstallmentAmount ?? throw new ArgumentNullException(nameof(totalInstallmentAmount));
        }

        public Money DueAmount { get; }

        public NaturalQuantity InstallmentsCount { get; }

        public Percent AnnualInterestRate { get; }

        public TimeInterval InstallmentsInterval { get; }

        public Percent AdministrationFeeRate { get; }

        public Money MaximumAdministrationFee { get; }

        public Percent Aop { get; }

        public Money TotalInterestAmount { get; }

        public Money AdministrationFee { get; }

        public Money TotalInstallmentAmount { get; }
    }
}
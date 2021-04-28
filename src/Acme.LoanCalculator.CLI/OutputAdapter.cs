using System;
using Acme.LoanCalculator.Core.Application;

namespace Acme.LoanCalculator.CLI
{
    public class OutputAdapter : IOutputPort
    {
        public void Write(PaymentOverviewOutput output)
        {
            Console.WriteLine("Housing loan payment overview");
            Console.WriteLine();

            Console.WriteLine("Loan parameters:");
            Console.WriteLine("=============================================");
            Console.WriteLine($"Due amount: {output.DueAmount}");
            Console.WriteLine($"Installments count: {output.InstallmentsCount}");
            Console.WriteLine("=============================================");
            Console.WriteLine();

            Console.WriteLine($"Loan terms:");
            Console.WriteLine("=============================================");
            Console.WriteLine($"Annual interest rate: {output.AnnualInterestRate}");
            Console.WriteLine($"Installments interval: {output.InstallmentsInterval}");
            Console.WriteLine("=============================================");
            Console.WriteLine();

            Console.WriteLine("Administration fee terms");
            Console.WriteLine("=============================================");
            Console.WriteLine($"Administration fee rate: {output.AdministrationFeeRate}");
            Console.WriteLine($"Max administration fee: {output.MaximumAdministrationFee}");
            Console.WriteLine("=============================================");
            Console.WriteLine();

            Console.WriteLine("Cost overview");
            Console.WriteLine("=============================================");
            Console.WriteLine($"Total installment amount: {output.TotalInstallmentAmount}");
            Console.WriteLine($"Aop: {output.Aop}");
            Console.WriteLine($"TotalAmount interest: {output.TotalInterestAmount}");
            Console.WriteLine($"TotalAmount administration fee: {output.AdministrationFee}");
            Console.WriteLine("=============================================");
        }
    }
}
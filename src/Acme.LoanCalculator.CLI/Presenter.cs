using System;
using Acme.LoanCalculator.Core.Application;

namespace Acme.LoanCalculator.CLI
{
    public class Presenter : IPresenter
    {
        public void Display(PaymentOverviewOutput output)
        {
            Console.WriteLine("Housing loan payment overview");
            
            Console.WriteLine("=========================");
            Console.WriteLine("Loan parameters:");
            Console.WriteLine($"Due amount: {output.DueAmount}");
            Console.WriteLine($"Payments count: {output.CyclesCount}");
            
            Console.WriteLine("=========================");
            Console.WriteLine($"Loan terms");
            Console.WriteLine($"Annual interest rate: {output.AnnualInterestRate}");
            Console.WriteLine($"Payment interval: {output.PaymentsInterval}");

            Console.WriteLine("=========================");
            Console.WriteLine("Commission terms");
            Console.WriteLine($"Commission rate: {output.CommisionRate}");
            Console.WriteLine($"Max comision: {output.MaximumCommision}");

            Console.WriteLine("=========================");
            Console.WriteLine("Cost overview");
            Console.WriteLine($"AOP: {output.Aop}");
            Console.WriteLine($"Total interest: {output.TotalInterest}");
            Console.WriteLine($"Total commission: {output.TotalCommission}");
        }
    }
}
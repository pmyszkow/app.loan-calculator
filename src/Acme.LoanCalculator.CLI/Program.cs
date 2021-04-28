using System;
using Acme.LoanCalculator.Core.Application;
using Acme.LoanCalculator.Infrastructure;

namespace Acme.LoanCalculator.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var controler =
                new Controller(new CalculateLoanPaymentOverviewUseCase(new Presenter(), new ConfigurationStub()));

            controler.CalculateLoan(500000, 120);

            Console.ReadKey();
        }
    }
}

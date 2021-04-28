using System;
using Acme.LoanCalculator.Core.Application;
using Acme.LoanCalculator.Core.Domain.Capability;
using Acme.LoanCalculator.Core.Domain.Policy;
using Acme.LoanCalculator.Infrastructure;
using Autofac;

namespace Acme.LoanCalculator.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var iocBuilder = new ContainerBuilder();
            iocBuilder.RegisterType<OutputAdapter>().As<IOutputPort>();
            iocBuilder.RegisterType<ConfigurationAdapterStub>().As<IConfigurationPort>();
            iocBuilder.RegisterType<GeneratePaymentOverviewUseCase>().As<IGeneratePaymentOverviewUseCase>();
            iocBuilder.RegisterType<LoanSimulationFactory>().As<ILoanSimulationFactory>();
            iocBuilder.RegisterType<PaymentOverviewFactory>().As<IPaymentOverviewFactory>();
            iocBuilder.RegisterType<AdministrationFeeCalculationPolicy>().As<IAdministrationFeeCalculationPolicy>();
            iocBuilder.RegisterType<AopCalculationPolicy>().As<IAopCalculationPolicy>();
            iocBuilder.RegisterType<InstallmentListGenerationPolicy>().As<IInstallmentListGenerationPolicy>();
            iocBuilder.RegisterType<PaymentOverviewController>();

            IContainer iocContainer = iocBuilder.Build();

            using (var scope = iocContainer.BeginLifetimeScope())
            {
                var controler = scope.Resolve<PaymentOverviewController>();
                controler.Generate(500000, 120);
            }

            Console.ReadKey();
        }
    }
}

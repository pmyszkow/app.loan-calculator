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
        private static IContainer _iocContainer;

        static void Main(string[] args)
        {
            BootstrapContainer();

            using (var scope = _iocContainer.BeginLifetimeScope())
            {
                var controller = scope.Resolve<PaymentOverviewController>();

                decimal dueValue = Decimal.Parse(args[0]);

                double paymentPeriod = Double.Parse(args[1]);

                controller.Generate(dueValue, paymentPeriod);
            }

            Console.ReadKey();
        }

        private static void BootstrapContainer()
        {
            var iocBuilder = new ContainerBuilder();

            RegisterComponents(iocBuilder);

            _iocContainer = iocBuilder.Build();
        }

        private static void RegisterComponents(ContainerBuilder builder)
        {
            builder.RegisterType<OutputAdapter>().As<IOutputPort>();
            builder.RegisterType<ConfigurationAdapterStub>().As<IConfigurationPort>();
            builder.RegisterType<GeneratePaymentOverviewUseCase>().As<IGeneratePaymentOverviewUseCase>();
            builder.RegisterType<LoanSimulationFactory>().As<ILoanSimulationFactory>();
            builder.RegisterType<PaymentOverviewFactory>().As<IPaymentOverviewFactory>();
            builder.RegisterType<AdministrationFeeCalculationPolicy>().As<IAdministrationFeeCalculationPolicy>();
            builder.RegisterType<AopCalculationPolicy>().As<IAopCalculationPolicy>();
            builder.RegisterType<InstallmentListGenerationPolicy>().As<IInstallmentListGenerationPolicy>();
            builder.RegisterType<PaymentOverviewController>();
        }
    }
}

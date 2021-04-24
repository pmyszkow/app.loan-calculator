namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public interface IPaymentOverviewFactory
    {
        PaymentOverview Create(LoanSimulation simulation, AdministrationFeeTerms administrationFeeTerms);
    }
}
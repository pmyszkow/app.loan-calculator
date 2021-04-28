namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public interface ILoanSimulationFactory
    {
        LoanSimulation Create(Loan debt, LoanTerms terms);
    }
}
namespace Acme.LoanCalculator.Core.Application
{
    public interface IOutputPort
    {
        void Write(PaymentOverviewOutput output);
    }
}
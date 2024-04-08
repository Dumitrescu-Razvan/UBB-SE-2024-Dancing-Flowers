namespace App.Domain
{
    public interface IPayment
    {
        // As far as I know, interface can't have fields, so I removed the fields from the interface.

        public void Pay(float amount);
        public void AddFunds(float amount);
        public void GetBalance();
    }

}
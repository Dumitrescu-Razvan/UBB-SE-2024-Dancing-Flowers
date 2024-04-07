namespace App.Domain
{
    public interface IPayment
    {
        float Balance { get; set; } = new float();

        public void Pay(float amount);
        public void AddFunds(float amount);
        public void GetBalance();
    }
    
}

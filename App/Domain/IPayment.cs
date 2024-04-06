public interface IPayment
{
    float Balance { get; set; }

    public void Pay(float amount);
    public void AddFunds(float amount);
    public void GetBalance();
}
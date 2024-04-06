public class PayPal : IPayment
{
    private string Email { get; set; }
    private float Balance { get; set; }

    public PayPal(string email)
    {
        (bool validEmail, string message) = IsValidEmail(email);
        if (validEmail)
        {
                this.Email = email;
        }
        else
        {
            throw new Exception(message);
        }

    }
    public static (bool, string) IsValidEmail(string email)
    {
        string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        if (!Regex.IsMatch(email, emailPattern))
        {
            return (false, "Invalid Email");
        }

        return (true, "Valid Email");
    }

    public void Pay(float amount)
    {
        if (amount > this.Balance)
        {
            throw new Exception("Insufficient funds");
        }
        this.Balance -= amount;
        
    }

    public void AddFunds(float amount)
    {
        this.Balance += amount;
    }

    public void getBalance()
    {
        return this.Balance;
    }


}
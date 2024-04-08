namespace App.Domain
{

    /*
     * For some reason PayPal extended App. I changed it to extend IPayment
     * also added an ID field because it didn't have one
     */
    public class PayPal : IPayment
    {
        private string Email { get; set; } = new string();
        private float Balance { get; set; } = new float();
        private int Id { get; } = new int();

        public PayPal(int id, string email, float balance)
        {
            this.Email = email;
            this.Balance = balance;
            this.Id = id;
        }

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
}
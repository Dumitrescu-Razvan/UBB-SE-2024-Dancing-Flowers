namespace App.Domain
{
    public class Card : IPayment
    {
        private string CardNumber { get; set; } = new string();
        private string Cvv { get; set; } = new string();
        private string ExpirationDate { get; set; } = new string();
        private float Balance { get; set; } = new float();
        private int Id { get; } = new int();

        public Card(int id, string cardNumber, string cvv, string expirationDate, int currentBalance)
        {
    
            this.CardNumber = cardNumber;
            this.Cvv = cvv;
            this.ExpirationDate = expirationDate;
            this.Balance = currentBalance;
            this.Id = id;
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

        public void GetBalance()
        {
            return this.Balance;
        }
    }

}
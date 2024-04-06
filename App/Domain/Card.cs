namespace App.Domain{
    public class Card : IPayment{
        private string CardNumber{get;set;};
        private string Cvv{get;set;};
        private string ExpirationDate{get;set;};
        private float Balance{get;set;};

        public Card(string cardNumber, string cvv, string expirationDate, int currentBalance) : base(currentBalance){
            CardNumber = cardNumber;
            Cvv = cvv;
            ExpirationDate = expirationDate;
        }

        public void Pay(float amount){
            if(amount > this.Balance){
                throw new Exception("Insufficient funds");
            }
            this.Balance -= amount;
        }

        public void AddFunds(float amount){
            this.Balance += amount;
        }

        public void GetBalance(){
            return this.Balance;
        }
    }

}
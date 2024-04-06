public class Card : IPayment
{
    private string CardNumber;

    private string Cvv;

    private string ExpirationDate;


    public Card(string cardNumber, string cvv, string expirationDate, int currentBalance) : base(currentBalance)
    {
        CardNumber = cardNumber;
        Cvv = cvv;
        ExpirationDate = expirationDate;
    }
}
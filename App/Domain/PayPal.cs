public class PayPal : IPayment
{
    private string Email{get; set;}

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

    public PayPal(string email, int currentBalance) : base(currentBalance)
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
    
    public override string ToString()
    {
        return "PayPal{" +
               "Email='" + Email + '\'' +
               '}';
    }
    
    public static (bool, string) IsValidEmail(string email)
    {
        // check that the email does not contain any spaces
        if (email.Contains(' '))
        {
            return (false, "The Email cannot contain spaces");
        }
        // the email cannot be less than 5 characters because "@.domain" has at least 4 characters
        if (email.Length < 5)
        {
            return (false, "The Email is too short");
        }
        // the email must contain an @
        if (!email.Contains("@"))
        {
            return (false, "The Email does not contain @");
        }
        // the email must contain a . after the @
        if (email.LastIndexOf(".") < email.LastIndexOf("@"))
        {
            return (false, "The Email does not have a domain extension");
        }

        return (true, "Valid Email");
    }
    
    
}
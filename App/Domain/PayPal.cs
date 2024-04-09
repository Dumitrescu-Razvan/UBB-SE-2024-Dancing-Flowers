using System;

namespace App.Domain
{

    public class PayPal : Payment
    {
        private string email { get; set; } = string.Empty;

        public PayPal(string email) : base()
        {
            this.email = email;
        }

        public PayPal(int id, float balance, string email) : base(id, balance)
        {
            this.email = email;
        }

    }
}
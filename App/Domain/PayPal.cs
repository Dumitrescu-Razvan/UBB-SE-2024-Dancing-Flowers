using System;

namespace App.Domain
{

    public class PayPal : Payment
    {
        private string email { get; set; } = new string();

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
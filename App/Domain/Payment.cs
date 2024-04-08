using System;

namespace App.Domain
{
    public abstract class Payment
    {
        private float balance { get; set; } = new float();
        private int id { get; } = new int();

        public Payment(int id, float balance)
        {
            this.balance = balance;
            this.id = id;
        }

        public Payment() 
        {
            this.balance = 0;
        }
            
    
    }

}
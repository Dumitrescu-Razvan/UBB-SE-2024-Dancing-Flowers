
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class IPayment {

	private double currentBalance;

	private List<double> transactions = new List<double>();
	
	// Simply creates a new IPayment object with a current balance of 0
    public IPayment() {
		this.currentBalance = 0;
    }
	
	// Creates a new IPayment object with a specified current balance
	 public IPayment(int currentBalance) {
		this.currentBalance = currentBalance;
    }

    
    public Boolean ProcessPayment(double amount) {
        if (this.currentBalance >= amount) {
            this.currentBalance -= amount;
            this.transactions.Add(amount);
            return true;
        }
        return false;
    }

}
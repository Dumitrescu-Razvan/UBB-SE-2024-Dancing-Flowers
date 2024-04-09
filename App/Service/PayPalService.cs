using System;
using App.Domain;
using App.Repository;
using System.Collections.Generic;

namespace App.Service
{
	public class PayPalService
	{
        private readonly PayPalRepository _payPalRepository;


        //new instance of PayPalService class
        public PayPalService(PayPalRepository payPalRepository)
        {
            _payPalRepository = payPalRepository;
        }

        //add a new PayPal account to system
        public void AddPayPalAccount(PayPal paypalAccount)
        {
            try { _payPalRepository.Add(paypalAccount); }
            catch (ArgumentException ex) { Comsole.WriteLine($"PayPal add error."); }
        }

        //retrieve a specific PayPal account by its Id
        public PayPal GetPayPalAccountById(int id)
        {
            return _payPalRepository.Find(paypal => paypal.Id == id);
        }

        //update PayPal account information
        public void UpdatePayPalAccount(PayPal updatedPayPalAccount)
        {
            try
            {
                PayPal paypalAccountToUpdate = _payPalRepository.Find(paypal => paypal.Id == updatedPayPalAccount.Id);
                if (paypalAccountToUpdate != null)
                {
                    paypalAccountToUpdate.Balance = updatedPayPalAccount.Balance;
                    paypalAccountToUpdate.Email = updatedPayPalAccount.Email;
                }
                else
                {
                    throw new ArgumentException("PayPal account not found");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //remove PayPal account from system
        public void RemovePayPalAccount(int id)
        {
            try
            {
                PayPal paypalAccountToRemove = _payPalRepository.Find(paypal => paypal.Id == id);
                if (paypalAccountToRemove != null)
                {
                    _payPalRepository.Remove(paypalAccountToRemove);
                }
                else
                {
                    throw new ArgumentException("PayPal account not found");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}

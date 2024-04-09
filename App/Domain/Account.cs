using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.IO.Pipes;

namespace App.Domain
{
    public abstract class Account
    {
        /*
         * 
         * Abstract class account.
         * Base class for all account types.
         * holds the properties of the account: username, password (hashed), salt, email, phone, age, zone
         * 
         * if no salt is provided, it generates a new salt
         * 
         */

        // Member variables, setter and getter methods
        public int id { get; } //Modified from guid to int

        public string username { get; set; } = string.Empty;
        public string passwordHash { get; set; } = string.Empty;
        public string salt { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;

        protected private List<Payment> payments { get; set; } = new List<Payment>();

        //Constructor
        public Account(int id, string username, string password, string email, string salt)
        {
            //set all the properties
            this.username = username;
            this.email = email;
            this.salt = salt;
            this.id = id;

            // Generate salt if no salt is provided, else use the one provided
            this.salt = salt == null ? generateSalt() : salt;

            // Hash the password with salt
            this.passwordHash = this.hashPassword(password, this.salt);
        }

        // Method to change password
        public bool changePassword(string oldPassword, string newPassword)
        {
            /*
             * @param oldPassword: string
             * @param newPassword: string
             * @return bool
             *
             * Method to change password
             * Verifies the old password
             * Generates a new salt for the new password
             * Hashes the new password with the new salt
             *
             *Returns true if the password is changed successfully, else false
             *
             */
            // Verify old password
            if (verifyPassword(oldPassword))
            {
                // Generate new salt for the new password
                this.salt = generateSalt();

                // Hash the new password with new salt hash the password with salt
                this.passwordHash = hashPassword(newPassword, this.salt);
                return true;
            }
            return false;
        }

        // Method to verify password
        public bool verifyPassword(string password)
        {
            /*
             * @param password: string
             * @return bool
             * Method to verify password
             * Hashes the entered password with stored salt
             * Compares with stored password hash
             *
             * Returns true if the password is correct, else false
             *
             */

            // Hash the entered password with stored salt
            string enteredPasswordHash = hashPassword(password, this.salt);
            // Compare with stored password hash
            return enteredPasswordHash == this.passwordHash;
        }

        // Method to generate salt
        private string generateSalt()
        {
            // Generate a cryptographically strong random salt
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Method to hash password with salt
        public string hashPassword(string password, string salt)
        {
            /*
             * @param password: string
             * @param salt: string
             * @return string
             *
             * Method to hash password with salt
             * Combines password and salt
             * Computes SHA256 hash
             * Converts hash to string
             *
             * Returns the hashed password
             *
             */

            // Combine password and salt
            string saltedPassword = password + salt;
            // Compute SHA256 hash
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                // Convert hash to string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }



        }

        // Method to add payment
        public void addPayment(Payment payment)
        {
            /*
            * @param payment: IPayment
            * @return bool
            *
            * Method to add payment
            * Adds the payment to the list of payments
            *
            * Returns true if the payment is added successfully, else false
            *
            */
            try
            {
                this.payments.Add(payment);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

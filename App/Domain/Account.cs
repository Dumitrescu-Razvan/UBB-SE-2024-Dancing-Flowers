using System;
using System.Security.Cryptography;
using System.Text;

namespace app.Domain
{
public abstract class Account
{
    /*
     * 
     * Abstract class account.
     * Base class for all account types.
     * holds theproperties of the account: username, password (hased), salt, email, phone, age, zone
     * 
     * if no salt is provided, it generates a new salt
     * 
     */

    // Member variables, setter and getter methods
    public static Guid guid { get; };

    protected private string username { get; set; } = new string("");
    protected private string passwordHash { get; set; } = new string("");
    protected private string salt { get; set; } = new string("");
    protected private string email { get; set; } = new string("");
    protected private string phone { get; set; } = new string("");

    //Constructor
    public Account(string username, string password, string email, string phone, string salt, Guid guid)
    {
        //set all the properties
        this.username = username;
        this.email = email;
        this.phone = phone;
        this.salt = salt;
        this.guid = guid;

        // Generate salt if no salt is provided, else use the one provided
        this.salt = salt == null ? generateSalt() : salt;

        // Hash the password with salt
        this.passwordHash = HashPassword(password, this.salt);
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
        if (VerifyPassword(oldPassword))
        {
            // Generate new salt for the new password
            this.salt = GenerateSalt();

            // Hash the new password with new salt hash the password with salt
            this.passwordHash = HashPassword(newPassword, this.salt);
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
        string enteredPasswordHash = HashPassword(password, this.salt);
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
    private string hashPassword(string password, string salt)
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
}
}

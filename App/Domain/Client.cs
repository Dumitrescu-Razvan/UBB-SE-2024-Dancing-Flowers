using System;
using System.Collections.Generic;

namespace App.Domain
{

    public class Client : Account
    {
        public string companyName { get; set; } = string.Empty;
        public string contactEmail { get; set; } = string.Empty;
        public string businessEmail { get; set; } = string.Empty;
        public string artistName { get; set; } = string.Empty;

        protected private List<Ad> ads { get; set; } = new List<Ad>();
        protected private List<Contract> contracts { get; set; } = new List<Contract>();

        public Client(int id, string username, string password,string email, string salt,string artistName) : 
            base(id ,username, password, email, salt)
        {
            this.companyName = companyName;
            this.contactEmail = contactEmail;
            this.businessEmail = businessEmail;
            this.artistName = artistName;


        }

        public void purchaseAdd(Ad ad)
        {
            /*
             * @param ad: Ad
             * @return bool
             *
             * Method to purchase an ad
             * Adds the ad to the list of ads
             *
             * Returns true if the ad is purchased successfully, else false
             */
            try
            {
                ads.Add(ad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool cancelAdd(Ad ad)
        {
            /*
             * @param ad: Ad
             * @return bool
             *
             * Method to cancel an ad
             * Removes the ad from the list of ads
             *
             * Returns true if the ad is canceled successfully, else false
             */
            if (ads.Remove(ad))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addContract(Contract contract)
        {
            /*
             * @param contract: Contract
             * @return bool
             *
             * Method to purchase a contract
             * Adds the contract to the list of contracts
             
             * Returns true if the contract is purchased successfully, else false
             */
            try
            {
                contracts.Add(contract);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool cancelContract(Contract contract)
        {
            /*
             * @param contract: Contract
             * @return bool
             *
             * Method to cancel a contract
             * Removes the contract from the list of contracts
             *
             * Returns true if the contract is canceled successfully, else false
             */

            if (contracts.Remove(contract))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
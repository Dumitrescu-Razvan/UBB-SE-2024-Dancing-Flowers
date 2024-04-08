namespace App.Domain
{
   
    public class Client : Account
    {
        protected private string companyName { get; set; } = new string();
        protected private string contactEmail { get; set; } = new string();
        protected private string businessEmail { get; set; } = new string();

        protected private list<Ad> ads { get; set; } = new list<Ad>();
        protected private list<Contract> contracts { get; set; } = new list<Contract>();

        public Client(int id, string username, string password, string phone, string zone, string salt, string companyName, string contactEmail, string businessEmail) : base(id, username, password, contactEmail, phone, zone, salt)
        {
            this.companyName = companyName;
            this.contactEmail = contactEmail;
            this.businessEmail = businessEmail;
        }

        public bool purchaseAdd(Ad ad)
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
            if (ads.Add(ad))
            {
                return true;
            }
            else
            {
                return false;
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

        public bool addContract(Contract contract)
        {
            /*
             * @param contract: Contract
             * @return bool
             *
             * Method to purchase a contract
             * Adds the contract to the list of contracts
             
             * Returns true if the contract is purchased successfully, else false
             */
            if (contracts.Add(contract))
            {
                return true;
            }
            else
            {
                return false;
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
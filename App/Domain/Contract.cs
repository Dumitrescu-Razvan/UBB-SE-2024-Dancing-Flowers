using System;
using System.Security.Cryptography;
using System.Text;

namespace App.Domain
{
   public class Contract
    {
       private int id { get; }
       private List<Client> clients { get; set; } = new List<Client>();
        private Song song { get; set; } = new Song();

        Contract(int id)
        {
            this.id = id;
        }

        Contract(int id, Song song)
        {
            this.id = id;
            this.song = song;
        }

        Contract(int id, List<Client> clients, Song song)
        {
            //Constructor with all the attributes
            this.id = id;
            this.clients = clients;
            this.song = song;
        }

        public void AddClient(Client client)
        {
            /*
             * Adds a client to the list of clients envolved in the contract
             */
            clients.Add(client);
        }

        public void RemoveClient(Client client)
        {
            /*
             * Removes a client from the list of clients envolved in the contract
             */
            clients.Remove(client);
        }

    }
}

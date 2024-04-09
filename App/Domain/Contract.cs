using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace App.Domain
{
    public class Contract
    {
        public int id { get; }
        public List<Client> clients { get; set; } = new List<Client>();
        public Song song { get; set; }

        public Contract(int id)
        {
            this.id = id;
            clients = new List<Client>();
            song = null;
        }

        public Contract(int id, List<Client> clients, Song song)
        {
            //Constructor with all the attributes
            this.id = id;
            this.clients = clients;
            this.song = song;
        }

        public void AddClient(Client client)
        {
            /*
             * Adds a client to the list of clients involved in the contract
             */
            clients.Add(client);
        }

        public void RemoveClient(Client client)
        {
            /*
             * Removes a client from the list of clients involved in the contract
             */
            clients.Remove(client);
        }

    }
}

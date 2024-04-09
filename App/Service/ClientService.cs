using System;
using App.Domain;
using App.Repository;
using System.Collections.Generic;

namespace App.Service
{
	public class ClientService
	{
        private readonly ClientRepository _clientRepository;

        //new instance of ClientService class
        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        //add new client to system
        public void AddClient(Client client)
        {
            try { _clientRepository.Add(client); }
            catch (ArgumentException ex){ Comsole.WriteLine($"Client add error."); }
        }

        //handle ad purchasing by a client
        public void purchaseAdd(Ad ad)
        {
            try
            {
                Client client = _clientRepository.Find(client => client.Id == clientId);
                if (client != null) { return client.purchaseAd(ad); }
                else { throw new ArgumentException("Client not found"); }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message );
                return false;
            }
        }

        //retrieve all clients
        public List<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        //retrieve a specific client by its Id
        public Client GetClientById(int id)
        {
            return _clientRepository.Find(client => client.Id == id);
        }

        //update client information
        public void UpdateClient(Client updatedClient)
        {
            try
            {
                Client clienttoUpdate = _clientRepository.Find(client => client.Id == updatedClient.Id);
                if (clienttoUpdate != null)
                {
                    clientToUpdate.username = updatedClient.username;
                    clientToUpdate.password = updatedClient.password;
                    clientToUpdate.phone = updatedClient.phone;
                    clientToUpdate.zone = updatedClient.zone;
                    clientToUpdate.companyName = updatedClient.companyName;
                    clientToUpdate.contactEmail = updatedClient.contactEmail;
                    clientToUpdate.businessEmail = updatedClient.businessEmail;
                }
                else
                {
                    throw new ArgumentExcpetion("Client not found");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //remove client from system
        public void RemoveClient(int id)
        {
            try
            {
                Client clientToRemove = _clientRepository.Find(client => client.Id == id);
                if (clientToRemove != null)
                {
                    clients.Remove(clientToRemove);
                }
                else
                {
                    throw new ArgumentException("Client not found");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //handle canceling an ad by client
        public bool CancelAd(int clientId,Ad ad)
        {
            try
            {
                Client client = _clientRepository.Find(client => client.Id == clientId);
                if (client != null)
                {
                    return client.CancelAd(ad);
                }
                else
                {
                    throw new ArgumentException("Client not found");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        //handle adding a contract for a client
        public bool AddContract(int clientId, Contract contract)
        {
            try
            {
                Client client = _clientRepository.Find(client => client.Id == clientId);
                if (client != null)
                {
                    return client.AddContract(contract);
                }
                else
                {
                    throw new ArgumentException("Client not found");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        //handle canceling a contract for a client
        public bool CancelContract(int clientId,Contract contract)
        {
            try
            {
                Client client = _clientRepository.Find(client => client.Id == clientId);
                if (client != null)
                {
                    return client.CancelContract(contract);
                }
                else
                {
                    throw new ArgumentException("Client not found");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}

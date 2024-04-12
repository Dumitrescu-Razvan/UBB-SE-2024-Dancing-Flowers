using System;
using App.Domain;
using App.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Service
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public bool IsValidCreateAcc(string email, string username, string password, string confirmPassword)
        {
            if (email == null || username == null || password == null || confirmPassword == null)
            {
                return false;
            }
            if (email == "" || username == "" || password == "" || confirmPassword == "")
            {
                return false;
            }
            if (password != confirmPassword)
            {
                return false;
            }
            return true;
        }

        public bool CreateAccount(string email, string username, string password, string confirmPassword, string artistName)
        {
            if (IsValidCreateAcc(email, username, password, confirmPassword))
            {
                var client = new Client(1, username, password, email, "", artistName);
                return true;
            }
            return false;
        }

        public bool IsValidLogin(string _username, string _password)
        {
            var client = _clientRepository.getByUsername(_username);
            return client.passwordHash == client.hashPassword(_password, client.salt);
        }

        public ObservableCollection<string> GetAllClients()
        {
            List<Client> clients = _clientRepository.getAll();
            ObservableCollection<string> clientList = new ObservableCollection<string>();
            foreach (var client in clients)
            {
                clientList.Add(client.artistName);

            }
            return clientList;
        }
    }
}

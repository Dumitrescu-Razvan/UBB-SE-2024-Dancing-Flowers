using System;
using System.Collections.Generic;
using App.Domain;
using App.Repository;

namespace App.Service
{
    public class ContractService
    {
        private readonly ContractRepository _contractRepository;

        public ContractService(ContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        /// <summary>
        /// Creates a new contract.
        /// </summary>
        /// <param name="id">The ID of the contract.</param>
        /// <param name="clients">The list of clients associated with the contract.</param>
        /// <param name="song">The song associated with the contract.</param>
        public void CreateContract(string id,List<Client> clients, Song song)
        {    
            try
            {
                var contract = new Contract(id,clients,song);
  
                _contractRepository.Add(contract);
            }
            catch (Exception ex)
            {
                throw new Exception($"Contract creation failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a contract by ID.
        /// </summary>
        /// <param name="id">The ID of the contract to delete.</param>
        public void DeleteContract(string id)
        {
            try
            {
                var contract = _contractRepository.getById(id);
                if (contract == null)
                {
                   throw new Exception("Contract not found.");
                }
                _contractRepository.Delete(contract);
               
            }
            catch (Exception ex)
            {
               throw new Exception($"Contract deletion failed: {ex.Message}");
            }
        }


        /// <summary>
        /// Updates a contract with new clients and song.
        /// </summary>
        /// <param name="id">The ID of the contract to update.</param>
        /// <param name="clients">The updated list of clients associated with the contract.</param>
        /// <param name="song">The updated song associated with the contract.</param>
        public void UpdateContract(string id, List<Client> clients, Song song)
        {
            try
            {
                var contract = _contractRepository.getById(id);
                if (contract == null)
                {
                    throw new Exception("Contract not found.");
                }
                contract.clients = clients;
                contract.song = song;
                _contractRepository.Update(contract);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"User update failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all contracts.
        /// </summary>
        /// <returns> A list of contracts </returns>
        public List<Contract> GetAllContracts()
        {
            return _contractRepository.getAll();
        }

        /// <summary>
        /// Retrieves a contract by ID.
        /// </summary>
        /// <param name="id">The ID of the contract to retrieve.</param>
        /// <returns>The contract with the specified ID.</returns>
        public Contract GetContractById(string id)
        {
            return _contractRepository.getById(id);
        }

        /// <summary>
        /// Adds a client to the contract.
        /// </summary>
        /// <param name="id">The ID of the contract.</param>
        /// <param name="client">The client to add.</param>
        public void AddClientToContract(string id, Client client)
        {
            try
            {
                var contract = _contractRepository.getById(id);
                contract.Add(client);
                _contractRepository.Update(contract);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add client to the contract: {ex.Message}");
            }
        }

        /// <summary>
        /// Removes a client from the contract.
        /// </summary>
        /// <param name="id">The ID of the contract.</param>
        /// <param name="client">The client to remove.</param>
        public void RemoveClientFromContract(string id, Client client)
        {
            try
            {
                var contract = _contractRepository.getById(id);
                contract.Remove(client);
                _contractRepository.Update(contract);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to remove client from the contract: {ex.Message}");
            }
        }
    }
}

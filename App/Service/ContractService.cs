/*using System;
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

        public void CreateContract(List<Client> clients, Song song)
        {    
            try
            {
                var contract = new Contract(Guid.NewGuid());
                contract.clients = clients;
                contract.song = song;
                _contractRepository.Add(contract);
            }
            catch (Exception ex)
            {
                throw new Exception($"Contract creation failed: {ex.Message}");
            }
        }

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
        public List<Contract> GetAllContracts()
        {
            return _contractRepository.getAll();
        }

    }
}
*/
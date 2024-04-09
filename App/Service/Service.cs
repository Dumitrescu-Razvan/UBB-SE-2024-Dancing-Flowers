using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using App.Service;
using App.Domain;
using App.Repository;
using System.Collections.ObjectModel;

namespace App.Service
{
    internal class Service
    {
        private readonly SongService _songService;
        private readonly ClientService _clientService;
        private readonly Admin _admin;
        private readonly UserService _userService;
        private readonly UserRepository _userRepository;
        private readonly ClientRepository _clientRepository;

        private Account activeUser;

        public Service(SongService songService, ClientService clientService, Admin admin, UserService userService)
        {
            _songService = songService;
            _clientService = clientService;
            _admin = admin;
            _userService = userService;
        }
        public void CreateAccount(string email, string username, string password, string confirmPassword, bool isClient)
        {
            if (isClient)
            {

            }
            else
            {

            }
        }

        public bool Login(string username, string password)
        {
            var user = _userRepository.getByUsername(username);
            var client = _clientRepository.getByUsername(username);
            if (user == null && client == null)
            {

                return false;
            }
            else if (user != null)
            {
                if (_userService.IsValidLogin(username, password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (_clientService.IsValidLogin(username, password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public ObservableCollection<string> getSongs()
        {
            return _songService.getSongs();
        }
    }
}

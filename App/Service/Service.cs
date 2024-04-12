using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Service;
using App.Domain;
using App.Repository;
using System.Collections.ObjectModel;
using ISSProject;

namespace App.Service
{
    public class Service
    {
        private static string connectionString = "Server=172.30.242.1;Database=Music;User Id=SA;Password=Password123;TrustServerCertificate=true";
        private SongRepository songRepo;
        private ClientRepository clientRepo;
        private UserRepository userRepo;

        private readonly SongService _songService;
        private readonly ClientService _clientService;
        private readonly Admin _admin;
        private readonly UserService _userService;

        private Account activeUser;

        public Service()
        {
            songRepo = new SongRepository(connectionString);
            clientRepo = new ClientRepository(connectionString);
            userRepo = new UserRepository(connectionString);
            _songService = new SongService(songRepo);
            _clientService = new ClientService(clientRepo);
            _admin = new Admin();
            _userService = new UserService(userRepo);

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
            var user = userRepo.getByUsername(username);
            var client = clientRepo.getByUsername(username);

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

        public bool CreateAccount(string email, string username, string password, string confirmPassword, bool isClient, string location = "", int age = 0, string artistName = "")
        {
            if (isClient)
            {

                _clientService.CreateAccount(email, username, password, confirmPassword, artistName);
                return true;

            }
            else
            {
                _userService.CreateAccount(email, username, password, confirmPassword, location, age);
                return true;

            }
            return false;
        }
        public ObservableCollection<string> GetSongs()
        {
            return _songService.getSongs();
        }

        public ObservableCollection<string> GetClients()
        {
            return _clientService.GetAllClients();
        }

    }
}
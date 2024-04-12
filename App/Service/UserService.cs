using System;
using System.Collections.Generic;
using App.Domain;
using App.Repository;

namespace App.Service
{
    public class UserService
    {
        public readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private bool IsValidCreateAcc(string email, string username, string password, string confirmPassword )
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

        public bool CreateAccount(string email, string username, string password, string confirmPassword, string location, int age)
        {
            if (IsValidCreateAcc(email, username, password, confirmPassword))
            {
                var user = new User(1, username, password, email, "", location, age, "bronze", false);
                _userRepository.Add(user);
                return true;
            }
            return false;
        }

        public bool IsValidLogin(string _username, string _password)
        {
            var user = _userRepository.getByUsername(_username);
            return user.passwordHash == user.hashPassword(_password, user.salt);

        }

        public bool isAdmin(string username)
        {
            var user = _userRepository.getByUsername(username);
            return user.isAdmin;
        }

    }
}

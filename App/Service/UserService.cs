using System;
using System.Collections.Generic;
using App.Domain;
using App.Repository;

namespace App.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the UserService class.
        /// </summary>
        /// <param name="userRepository">The repository for user data.</param>
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Purchases a subscription for a user.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="subscriptionTier">The tier of the subscription to purchase.</param>
        /// <exception cref="Exception">Thrown when user not found or subscription purchase fails.</exception>
        public void purchaseSubscription(string id ,string subscriptionTier)
        {
            try
            {

                var user = _userRepository.getById(id);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                user.PurchaseSubscription(subscriptionTier);
                _userRepository.Update(user);
            }
            catch (Exception ex)
            {
               throw new Exception($"Subscription purchase failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Cancels the subscription of a user.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="username">The username of the user.</param>
        /// <exception cref="Exception">Thrown when user not found or subscription cancellation fails.</exception>
        public void CancelSubscription(string id,string username)
        {
            try
            {
                var user = _userRepository.getById(id);

                if (user == null)
                {
                   throw new Exception("User not found.");
                }

                user.CancelSubscription();
                _userRepository.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Subscription cancellation failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates a playlist for a user.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="playlist">The playlist to be created.</param>
        /// <exception cref="Exception">Thrown when user not found or playlist creation fails.</exception>
        public void CreatePlaylist(string id, Playlist playlist)
        {
            try
            {
                var user = _userRepository.getById(id);

                if (user == null)
                {
                    
                    throw new Exception("User not found.");
                }

                user.CreatePlaylist(playlist);
                _userRepository.Update(user);

               
            }
            catch (Exception ex)
            {
                throw new Exception($"Playlist creation failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a playlist of a user.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="playlist">The playlist to be deleted.</param>
        /// <exception cref="Exception">Thrown when user not found or playlist deletion fails.</exception>
        public void DeletePlaylist(string id, Playlist playlist)
        {
            try
            {
                var user = _userRepository.getById(id);

                if (user == null)
                {
                   throw new Exception("User not found.");
                }

                user.DeletePlaylist(playlist);
                _userRepository.Update(user);

               
            }
            catch (Exception ex)
            {
                throw new Exception($"Playlist deletion failed: {ex.Message}");
            }
        }


        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="email">The email address of the user.</param>
        /// <param name="phone">The phone number of the user.</param>
        /// <param name="zone">The time zone of the user.</param>
        /// <param name="salt">The salt value for password hashing.</param>
        /// <param name="location">The location of the user.</param>
        /// <param name="age">The age of the user.</param>
        /// <param name="subscriptionTier">The initial subscription tier of the user.</param>
        /// <exception cref="Exception">Thrown when user creation fails.</exception>
        public void CreateUser(string username, string password, string email, string phone, string zone, string salt, string location, int age, string subscriptionTier)
        {
            try
            {
                var user = new User(username, password, email, phone, zone, salt, location, age, subscriptionTier, Guid.NewGuid());
                _userRepository.Add(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"User creation failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <exception cref="Exception">Thrown when user not found or user deletion fails.</exception>
        public void DeleteUser(string id)
        {
            try
            {
                var user = _userRepository.getById(id);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                _userRepository.Delete(user);
                
            }
            catch (Exception ex)
            {
                throw new Exception($"User deletion failed: {ex.Message}");
            }
        }


        /// <summary>
        /// Updates user information.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="username">The new username of the user.</param>
        /// <param name="password">The new password of the user.</param>
        /// <param name="email">The new email address of the user.</param>
        /// <param name="phone">The new phone number of the user.</param>
        /// <param name="zone">The new time zone of the user.</param>
        /// <param name="salt">The new salt value for password hashing.</param>
        /// <param name="location">The new location of the user.</param>
        /// <param name="age">The new age of the user.</param>
        /// <param name="subscriptionTier">The new subscription tier of the user.</param>
        /// <exception cref="Exception">Thrown when user not found or user update fails.</exception>
        public void UpdateUser(string id, string username, string password, string email, string phone, string zone, string salt, string location, int age, string subscriptionTier)
        {
            try
            {
                var user = _userRepository.getById(id);

                if (user == null)
                {
                   throw new Exception("User not found.");
                }

                user.Username = username;
                user.Password = password;
                user.Email = email;
                user.Phone = phone;
                user.Zone = zone;
                user.Salt = salt;
                user.Location = location;
                user.Age = age;
                user.SubscriptionTier = subscriptionTier;

                _userRepository.Update(user);
               
            }
            catch (Exception ex)
            {
                throw new Exception($"User update failed: {ex.Message}");
            }
        }


        /// <summary>
        /// Changes the password of a user.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="oldPassword">The current password of the user.</param>
        /// <param name="newPassword">The new password to be set.</param>
        /// <exception cref="Exception">Thrown when user not found or password change fails.</exception>
        public void ChangePassword(string id, string oldPassword, string newPassword)
        {
            try
            {
                var user = _userRepository.getById(id);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                user.ChangePassword(oldPassword, newPassword);
                _userRepository.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Password change failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all users from the repository.
        /// </summary>
        /// <returns>A list of all users.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while retrieving users.</exception>
        public List<User> GetAllUsers()
        {
            try
            {
                var users = _userRepository.GetAll();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get all users: {ex.Message}");
            }
        }
    }
}

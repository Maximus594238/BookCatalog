using BookCatalog.Logic.Models;
using BookCatalog.Logic.Repositories;
using BookCatalog.Logic.Helpers; 
using System;

namespace BookCatalog.Logic.Services
{
    public class AuthService
    {
        private UserRepository userRepository;
        private User currentUser;

        public AuthService()
        {
            userRepository = new UserRepository();
        }

        public User GetCurrentUser()
        {
            return currentUser;
        }

        public bool IsAuthenticated()
        {
            return currentUser != null;
        }

        public int Register(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
                return -2;

            if (login.Length < 3)
                return -3;

            if (string.IsNullOrWhiteSpace(password))
                return -4;

            if (password.Length < 4)
                return -5;

            if (userRepository.UserExists(login))
                return 0;

            string hash = PasswordHelper.HashPassword(password);
            int result = userRepository.Create(login, hash);

            return result > 0 ? 1 : -1;
        }

        public int Authenticate(string login, string password)
        {
            User user = userRepository.GetByLogin(login);

            if (user == null)
                return 0;

            if (!user.GetIsActive())
                return -1;

            bool isValid = PasswordHelper.VerifyPassword(password, user.GetPasswordHash());

            if (!isValid)
                return 0;

            currentUser = user;
            return 1;
        }

        public void Logout()
        {
            currentUser = null;
        }
    }
}
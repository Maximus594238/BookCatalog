using System;

namespace BookCatalog.Logic.Models
{
    public class User
    {
        private int id;
        private string login;
        private string passwordHash;
        private string role;
        private bool isActive;
        private DateTime createdAt;

        public User() { }

        public User(int id, string login, string passwordHash, string role, bool isActive, DateTime createdAt)
        {
            this.id = id;
            this.login = login;
            this.passwordHash = passwordHash;
            this.role = role;
            this.isActive = isActive;
            this.createdAt = createdAt;
        }

        public int GetId()
        {
            return id;
        }
        public void SetId(int value)
        {
            id = value;
        }

        public string GetLogin()
        {
            return login;
        }
        public void SetLogin(string value)
        {
            login = value;
        }

        public string GetPasswordHash()
        {
            return passwordHash;
        }
        public void SetPasswordHash(string value)
        {
            passwordHash = value;
        }

        public string GetRole()
        {
            return role;
        }
        public void SetRole(string value)
        {
            role = value;
        }

        public bool GetIsActive()
        {
            return isActive;
        }
        public void SetIsActive(bool value)
        {
            isActive = value;
        }

        public DateTime GetCreatedAt()
        {
            return createdAt;
        }
        public void SetCreatedAt(DateTime value)
        {
            createdAt = value;
        }
    }
}
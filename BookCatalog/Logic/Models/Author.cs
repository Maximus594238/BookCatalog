using System;

namespace BookCatalog.Logic.Models
{
    public class Author
    {
        private int id;
        private string firstName;
        private string lastName;
        private DateOnly? birthDate;
        private string biography;

        public Author() { }

        public Author(int id, string firstName, string lastName, DateOnly? birthDate, string biography)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.biography = biography;
        }

        public int GetId()
        {
            return id;
        }
        public void SetId(int value)
        {
            id = value;
        }

        public string GetFirstName()
        {
            return firstName;
        }
        public void SetFirstName(string value)
        {
            firstName = value;
        }

        public string GetLastName()
        {
            return lastName;
        }
        public void SetLastName(string value)
        {
            lastName = value;
        }

        public string GetFullName()
        {
            return $"{lastName} {firstName}";
        }

        public DateOnly? GetBirthDate()
        {
            return birthDate;
        }
        public void SetBirthDate(DateOnly? value)
        {
            birthDate = value;
        }

        public string GetBiography()
        {
            return biography;
        }
        public void SetBiography(string value)
        {
            biography = value;
        }
    }
}
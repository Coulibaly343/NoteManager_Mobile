using System;

namespace NoteManager.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        public User()
        {
        }

        public User(string name, string surname, string login, string password)
        {
            SetName(name);
            SetSurname(surname);
            SetLogin(login);
            SetPassword(password);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name cannot be empty.");
            Name = name;
        }

        public void SetSurname(string surname)
        {
            if (string.IsNullOrEmpty(surname))
                throw new ArgumentNullException("Surname cannot be empty.");
            Surname = surname;
        }

        public void SetLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new ArgumentNullException("Login cannot be empty.");
            Login = login;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Password cannot be empty.");
            Password = password;
        }

    }
}

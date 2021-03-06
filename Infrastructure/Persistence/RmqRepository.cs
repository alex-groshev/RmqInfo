﻿namespace Infrastructure.Persistence
{
    public abstract class RmqRepository
    {
        protected string BaseAddress { get; private set; }
        protected string Login { get; private set; }
        protected string Password { get; private set; }

        protected RmqRepository()
            : this("http://localhost:15672/api/", "guest", "guest") { }

        protected RmqRepository(string baseAddress, string login, string password)
        {
            BaseAddress = baseAddress;
            Login = login;
            Password = password;
        }
    }
}

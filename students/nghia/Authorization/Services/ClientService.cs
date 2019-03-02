using System;
using Models;
using Repositories;
using Services.Exceptions;
using Utilities;

namespace Services
{
    public class ClientService : BaseService<Client, ClientRepository>
    {
        private static ClientService instance { get; set; }

        public static ClientService Instance
        {
            get
            {
                if (instance == null) instance = new ClientService();
                return instance;
            }
        }
    }
}

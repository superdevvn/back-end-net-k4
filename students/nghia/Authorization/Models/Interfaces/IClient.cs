using System;

namespace Models.Interfaces
{
    public interface IClient
    {
        Guid clientId { get; set; }
        string clientCode { get; set; }
    }
}

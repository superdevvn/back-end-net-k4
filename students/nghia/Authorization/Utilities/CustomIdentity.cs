using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Utilities
{
    public class CustomIdentity : List<Claim>
    {
        public Guid ClientId { get; set; }
        public string ClientCode { get; set; }
        public bool IsMasterClient { get; set; }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public bool IsMasterUser { get; set; }

        public CustomIdentity(ClaimsIdentity identity)
        {
            var clientId = identity.FindFirst("ClientId")?.Value;
            var clientCode = identity.FindFirst("ClientCode")?.Value;
            var isMasterClient = identity.FindFirst("IsMasterClient")?.Value;

            var userId = identity.FindFirst("UserId")?.Value;
            var username = identity.FindFirst("Username")?.Value;
            var isMasterUser = identity.FindFirst("IsMasterUser")?.Value;

            if (string.IsNullOrWhiteSpace(clientId) ||
                string.IsNullOrWhiteSpace(clientCode) ||
                string.IsNullOrWhiteSpace(isMasterClient) ||
                string.IsNullOrWhiteSpace(userId) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(isMasterUser)) throw new InvalidTokenException();

            Guid result = Guid.Empty;
            bool flag = false;

            if (!Guid.TryParse(clientId, out result)) throw new InvalidTokenException();
            ClientId = result;

            if (!bool.TryParse(isMasterClient, out flag)) throw new InvalidTokenException();
            IsMasterClient = flag;

            if (!Guid.TryParse(userId, out result)) throw new InvalidTokenException();
            UserId = result;

            if (!bool.TryParse(isMasterUser, out flag)) throw new InvalidTokenException();
            IsMasterUser = flag;

            Username = username;
            ClientCode = clientCode;

            Add(new Claim("ClientId", ClientId.ToString()));
            Add(new Claim("ClientCode", ClientCode.ToString()));
            Add(new Claim("IsMasterClient", IsMasterClient.ToString()));

            Add(new Claim("UserId", UserId.ToString()));
            Add(new Claim("Username", Username));
            Add(new Claim("IsMasterUser", IsMasterUser.ToString()));
        }

        public CustomIdentity(Guid clientId, string clientCode, bool isMasterClient, Guid userId, string username, bool isMasterUser)
        {
            ClientId = clientId;
            ClientCode = clientCode;
            IsMasterClient = isMasterClient;

            UserId = userId;
            Username = username;
            IsMasterUser = isMasterUser;

            Add(new Claim("ClientId", ClientId.ToString()));
            Add(new Claim("ClientCode", ClientCode.ToString()));
            Add(new Claim("IsMasterClient", IsMasterClient.ToString()));

            Add(new Claim("UserId", UserId.ToString()));
            Add(new Claim("Username", Username));
            Add(new Claim("IsMasterUser", IsMasterUser.ToString()));
        }

        public static string[] Keys
        {
            get
            {
                return new string[] { "ClientId", "ClientCode", "IsMasterClient", "UserId", "Username", "IsMasterUser" };
            }
        }
    }
}

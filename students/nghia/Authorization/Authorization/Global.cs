using Models;
using Services;
using Services.Exceptions;

namespace Authorization
{
    public static class Global
    {
        public static void InitalizeDatabase()
        {
            var clientService = new ClientService();
            var userService = new UserService();
            try
            {
                clientService.First("code", "MASTER");
            }
            catch (NotFoundException)
            {
                var masterClient = new Client
                {
                    code = "MASTER",
                    name = "Master Client",
                    description = string.Empty,
                    isMaster = true
                };
                masterClient = clientService.Save(masterClient, false);

                var masterUser = new User
                {
                    clientId = masterClient.id,
                    username = "MasterAdmin",
                    password = "e10adc3949ba59abbe56e057f20f883e", // 123456
                    isMaster = true,
                    isActivated = true
                };
                userService.Save(masterUser, false);
            }
        }
    }
}
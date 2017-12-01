using Reminder.Common.Enums;
using System.Text;
using Newtonsoft.Json;
using System.ServiceModel;

namespace Reminder.Data.Clients
{
    public class UserClient : IUserClient
    {
        public LoginResult Login(string login, string password)
        {
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.Login(login,password);
                    //TO DO
                    LoginResult result = (LoginResult)resultDto;
              
                    client.Close();

                    return result;
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    log4net.LogManager.GetLogger("LOGGER").Error(ex.Detail.Message);
                }
            }
            
            return LoginResult.EmptyCredentials;
        }
    }
}

using Reminder.Service.ModelDto.Dto;
using System.ServiceModel;

namespace Reminder.Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        UserDto GetCurrentUser(string login, string password);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        int Registration(string login, string password, string email);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        UserDto[] GetUsers();

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        UserDto EditeUser(int id);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        RoleDto[] GetRoles();

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        int UpdateUser(int id, string login, string email, int roleId);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        int DeleteUser(int id);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        int UpdateProfile(int id, string login, string email);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        int UpdatePassword(int id, string password);
    }
}

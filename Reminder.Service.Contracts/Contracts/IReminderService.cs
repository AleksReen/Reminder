using Reminder.Service.Contracts.Models.Dto;
using Reminder.Service.ModelDto.Dto;
using System.ServiceModel;

namespace Reminder.Service
{
    [ServiceContract]
    public interface IReminderService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        MyReminderDto [] GetAllReminders(int userId);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        CategoryDto [] GetAllCategories();

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        ReminderInfoDto GetReminderInfo(int reminderId);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        UserDto GetCurrentUser(string login, string password);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        ServerResultDto AddCategory(string categoryName);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        ServerResultDto EditeCategory(int categoryId, string categoryName);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        ServerResultDto DeleteCategory(int categoryId);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        ServerResultDto Registration(string login, string password, string email);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        UserDto[] GetUsers();

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        UserDto EditeUser(int id);
    }
}

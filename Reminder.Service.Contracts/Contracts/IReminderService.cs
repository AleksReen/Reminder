using Reminder.Service.Contracts.Models.Dto;
using Reminder.Service.ModelDto.Dto;
using System.ServiceModel;

namespace Reminder.Service
{
    [ServiceContract]
    public interface IReminderService
    {
        //method invokes a list of reminders
        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        MyReminderDto [] GetAllReminders(int userId);

        //method enumerates a list of categories
        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        CategoryDto [] GetAllCategories();

        //return Reminder description
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

    }
}

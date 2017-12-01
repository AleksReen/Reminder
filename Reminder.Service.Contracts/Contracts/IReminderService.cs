using Reminder.Service.Contracts.Models.Dto;
using Reminder.Service.ModelDto.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace Reminder.Service
{
    [ServiceContract]
    public interface IReminderService
    {
        //method invokes a list of reminders
        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        MyReminderDto [] GetAllReminders();

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
        LoginResultDto Login(string login, string password);

    }
}

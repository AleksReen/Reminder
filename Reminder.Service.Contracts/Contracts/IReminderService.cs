using Reminder.Service.Contracts.Models.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace Reminder.Service
{
    [ServiceContract]
    public interface IReminderService
    {
        //method invokes a list of reminders
        [OperationContract]
        MyReminderDto [] GetAllReminders();

        //method enumerates a list of categories
        [OperationContract]
        CategoryDto [] GetAllCategories();

        //return Reminder description
        [OperationContract]
        ReminderInfoDto GetReminderInfo(int reminderId);
    }
}

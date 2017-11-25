using Reminder.Service.Contracts.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Reminder.Service
{
    [ServiceContract]
    public interface IReminderService
    {
        //method invokes a list of reminders
        [OperationContract]
        List<MyReminderDto> GetAllReminders();

        //method enumerates a list of categories
        [OperationContract]
        List<CategoryDto> GetAllCategories();

        //return Reminder description
        [OperationContract]
        ReminderInfoDto GetReminderInfo(int reminderId);
    }
}

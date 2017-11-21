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
        [OperationContract]
        //method invokes a list of reminders
        IEnumerable<MyReminderDto> GetMyReminder();

        [OperationContract]
        //method enumerates a list of categories
        IEnumerable<CategoryDto> GetCategory();
    }
}

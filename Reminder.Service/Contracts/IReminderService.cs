using Reminder.Service.Contracts.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Service.Contracts
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

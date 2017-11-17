﻿using Reminder.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data.DataProviders
{
    public interface IDataProvider
    {
        List<Category> getCategory();
        List<MyReminder> getMyReminder();
    }
}

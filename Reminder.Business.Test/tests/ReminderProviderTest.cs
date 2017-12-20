using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reminder.Data.Repository;
using Reminder.Business.Providers;
using Reminder.Common.Entity;
using System.Collections.Generic;
using Reminder.Common.Enums;

namespace Reminder.Business.Test
{
    [TestClass]
    public class ReminderProviderTest
    {
        private Mock<IDataRepository> _dataProvider;
        private ReminderProvider testClass;

        private MyReminder[] remindersList = {
            new MyReminder {ReminderId = 1, Title = "Починить автомобиль", Date = Convert.ToDateTime("2017-11-20"), ReminderTime = Convert.ToDateTime("2017-11-16 16:00:00"), Image = @"..\Images\No-image-found.jpg", Category = new Category { CategoryId = 3 }, UserId = 1},
            new MyReminder {ReminderId = 2, Title = "Встретить босса", Date = Convert.ToDateTime("2017-11-15"), ReminderTime = Convert.ToDateTime("2017-11-14 12:00:00"), Image = @"..\Images\No-image-found.jpg", Category = new Category { CategoryId = 4 }, UserId = 1},
            new MyReminder {ReminderId = 3, Title = "Починить полку", Date = Convert.ToDateTime("2017-11-20"), ReminderTime = Convert.ToDateTime("2017-11-16 16:00:00"), Image = @"..\Images\No-image-found.jpg", Category = new Category { CategoryId = 3 }, UserId = 1},
            new MyReminder {ReminderId = 4, Title = "Забрать ребёнка из школы", Date = Convert.ToDateTime("2017-11-18"), ReminderTime = Convert.ToDateTime("2017-11-17 12:30:00"), Image = @"..\Images\No-image-found.jpg", Category = new Category { CategoryId = 2 }, UserId = 1},
            new MyReminder {ReminderId = 5, Title = "Кемпинг", Date = Convert.ToDateTime("2017-11-10"), ReminderTime = Convert.ToDateTime("2017-11-09 13:00:00"), Image = @"..\Images\No-image-found.jpg", Category = new Category { CategoryId = 5 }, UserId = 1},
        };

        private MyReminder tR = new MyReminder { ReminderId = 1, Title = "test", Date = Convert.ToDateTime("2017-11-20"), ReminderTime = Convert.ToDateTime("2017-11-16 16:00:00"), Image = @"..\Images\No-image-found.jpg", Category = new Category { CategoryId = 3 }, UserId = 1 };

        [TestInitialize]
        public void TestInitialize()
        {
            _dataProvider = new Mock<IDataRepository>();
            testClass = new ReminderProvider(_dataProvider.Object);
        }

        [TestMethod]
        public void ReminderProvider_GetReminderInfo_ById()
        {
            var info = new ReminderInfo
            {
                Reminder = new MyReminder {
                    ReminderId = 1,
                    Title = "Починить автомобиль",
                    Date = Convert.ToDateTime("2017-11-20"),
                    ReminderTime = Convert.ToDateTime("2017-11-16 16:00:00"),
                    Image = @"..\Images\No-image-found.jpg",
                    Category = new Category { CategoryId = 3, CategoryName = "Meetings" },
                    UserId = 1 },

                Actions = new List<string>() { "Позвонить механику", "Взять с собой инструмент" },
                Description = "Мастер Андрей, подготовит список нужных деталей для покупки в магазине"
            };

            _dataProvider
                .Setup(e => e.GetReminderInfo(It.IsAny<int>()))
                .Returns((int number) =>
                {
                    if (number != info.Reminder.ReminderId)
                    {
                        throw new ArgumentException();
                    }
                    return info;
                });
            var result = testClass.GetReminderInfo(1);
            Assert.IsTrue(result == info);
        }

        [TestMethod]
        public void ReminderProvider_GetReminders_PassUserId()
        {
            var userId = 1;

            _dataProvider
                .Setup(e => e.GetMyReminders(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    if (id != userId)
                    {
                        throw new ArgumentException();
                    }
                    return remindersList;
                });

            var result = testClass.GetReminders(1);
            Assert.IsTrue(result == remindersList);
        }

        [TestMethod]
        public void ReminderProvider_AddReminder_GetResultFromServer_PassParam()
        {
            var result = testClass.AddReminder(tR.Title, tR.Date, tR.ReminderTime,tR.Image, tR.Category.CategoryId, tR.UserId, null, null);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == ServerResponse.NoError);
        }

        [TestMethod]
        public void ReminderProvider_UpdateReminder_GetResultFromServer_PassParam()
        {
            var result = testClass.UpdateReminder(tR.ReminderId, tR.Title, tR.Date, tR.ReminderTime, tR.Image, tR.Category.CategoryId, null, null);

            Assert.IsNotNull(result);
            Assert.IsTrue(result == ServerResponse.NoError);
        }

        [TestMethod]
        public void ReminderProvider_DeleteReminder_GetResultFromServer_PassParamId()
        {
            _dataProvider
                .Setup(e => e.DeleteReminder(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    if (id != tR.ReminderId)
                    {
                        throw new ArgumentException();
                    }
                    return tR.Image;
                });

            var result = testClass.DeleteReminder(1);
            Assert.IsTrue(result == tR.Image);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Business.Providers;
using Moq;
using Reminder.WebUI.Controllers;
using Reminder.Common.Entity;
using System.Web.Mvc;
using Reminder.WebUI.Models.ViewsModels;

namespace Reminder.WebUI.Test
{
    [TestClass]
    public class SearchControllerTest
    {
        private Mock<ICategoryProvider> categoryProvider;
        private Mock<IReminderProvider> reminderProvider;
        private SearchController controller;


        private MyReminder[] remindersList = {
            new MyReminder {ReminderId = 1, Title = "Починить автомобиль", Date = Convert.ToDateTime("2017-11-20"), ReminderTime = Convert.ToDateTime("2017-11-16 16:00:00"), Image = @"..\Images\No-image-found.jpg", CategoryId = 3, UserId = 1},
            new MyReminder {ReminderId = 2, Title = "Встретить босса", Date = Convert.ToDateTime("2017-11-15"), ReminderTime = Convert.ToDateTime("2017-11-14 12:00:00"), Image = @"..\Images\No-image-found.jpg", CategoryId = 4, UserId = 1},
            new MyReminder {ReminderId = 3, Title = "Починить полку", Date = Convert.ToDateTime("2017-11-20"), ReminderTime = Convert.ToDateTime("2017-11-16 16:00:00"), Image = @"..\Images\No-image-found.jpg", CategoryId = 3, UserId = 1},
            new MyReminder {ReminderId = 4, Title = "Забрать ребёнка из школы", Date = Convert.ToDateTime("2017-11-18"), ReminderTime = Convert.ToDateTime("2017-11-17 12:30:00"), Image = @"..\Images\No-image-found.jpg", CategoryId = 2, UserId = 1},
            new MyReminder {ReminderId = 5, Title = "Кемпинг", Date = Convert.ToDateTime("2017-11-10"), ReminderTime = Convert.ToDateTime("2017-11-09 13:00:00"), Image = @"..\Images\No-image-found.jpg", CategoryId = 5, UserId = 1},
        };

        [TestInitialize]
        public void TestInitialize()
        {
            categoryProvider = new Mock<ICategoryProvider>();
            reminderProvider = new Mock<IReminderProvider>();
            controller = new SearchController(categoryProvider.Object, reminderProvider.Object);
        }
  
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SearchController_GetSearchResult_PassNullFilter()
        {
            controller.GetSearchResult(null);
        }

        [TestMethod]
        public void SearchController_GetSearchResult_PassAllDefaultNullEmptyFilterParams()
        {
            var expected = "Sorry, you do not have any reminders matching the parameters";
            var filter = new ViewFilter() { Name = "", Category = 0, Date = default(DateTime) };
            PartialViewResult result = controller.GetSearchResult(filter) as PartialViewResult;
            string actual = result.ViewBag.Message as string;

            Assert.AreEqual(expected, actual);
        }
    }
}

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

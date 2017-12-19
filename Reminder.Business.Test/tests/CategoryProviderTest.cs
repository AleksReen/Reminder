using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Data.Repository;
using Moq;
using Reminder.Business.Model;
using Reminder.Common.Enums;
using Reminder.Common.Entity;

namespace Reminder.Business.Test
{
    [TestClass]
    public class CategoryProviderTest
    {
        private Mock<IDataRepository> _dataProvider;
        private CategoryProvider testClass;

        private Category[] categoryList = {
            new Category { CategoryId = 1, CategoryName = "Meetings" },
            new Category { CategoryId = 2, CategoryName = "Family" },
            new Category { CategoryId = 3, CategoryName = "Home" },
            new Category { CategoryId = 4, CategoryName = "Business" },
            new Category { CategoryId = 5, CategoryName = "Rest" }
        };

        [TestInitialize]
        public void TestInitialize()
        {
            _dataProvider = new Mock<IDataRepository>();
            testClass = new CategoryProvider(_dataProvider.Object);
        }


        [TestMethod]
        public void CategoryProvider_AddCategory_GetResultFromServer_PassRightParam()
        {
           var result = testClass.AddCategory("TestCategory");
           Assert.IsNotNull(result);
           Assert.IsTrue(result == ServerResponse.NoError);
        }

        [TestMethod]
        public void CategoryProvider_DeleteCategory_GetResultFromServer_PassParam()
        {
            var result = testClass.DeleteCategory(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == ServerResponse.NoError);
        }

        [TestMethod]
        public void CategoryProvider_EditeCategory_GetResultFromServer_PassParam()
        {
            var result = testClass.EditeCategory(1, "TestCategory");
            Assert.IsNotNull(result);
            Assert.IsTrue(result == ServerResponse.NoError);
        }

        [TestMethod]
        public void CategoryProvider_GetCategories_GetAllCategory()
        {
            _dataProvider
                .Setup(e => e.GetCategories())
                .Returns(() =>
                {
                    return categoryList;
                });
            var result =  testClass.GetCategories();
            Assert.IsTrue(result == categoryList);
        }
    }
}

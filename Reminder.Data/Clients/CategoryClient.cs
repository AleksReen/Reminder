using System.Collections.Generic;
using Reminder.Common.Entity;
using System.ServiceModel;

namespace Reminder.Data.Clients
{
    public class CategoryClient: ICategoryClient
    {
        public IReadOnlyList<Category> GetCategories()
        {
            var result = new List<Category>();
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var categoriesDto = client.GetAllCategories();

                    if (categoriesDto != null)
                    {
                        foreach (var category in categoriesDto)
                        {
                            var cat = new Category()
                            {
                                CategoryId = category.CategoryId,
                                CategoryName = category.CategoryName
                            };
                            result.Add(cat);
                        }
                    }

                    client.Close();
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    log4net.LogManager.GetLogger("LOGGER").Error(ex.Detail.Message);
                }
            }
            return result;
        }
    }
}

using System.Collections.Generic;
using Reminder.Common.Entity;
using Reminder.Service.ModelDto.Dto;
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
                client.Open();

                try
                {
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
                }
                catch (FaultException<ServiceErrorDto> ex)
                {
                    
                    throw;
                }
                
                client.Close();
            }
            return result;
        }
    }
}

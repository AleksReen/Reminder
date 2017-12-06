using System.Collections.Generic;
using Reminder.Common.Entity;
using System.ServiceModel;
using Reminder.Common.Enums;
using System;

namespace Reminder.Data.Clients
{
    public class CategoryClient: ICategoryClient
    {
        public ServerResponse AddCategory(string categoryName)
        {
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.AddCategory(categoryName);

                    if (resultDto.Result == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }

                    client.Close();

                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    log4net.LogManager.GetLogger("LOGGER").Error(ex.Detail.Message);
                }
            }

            return ServerResponse.DataBaseError;
        }

        public ServerResponse DeleteCategory(int categoryId)
        {
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.DeleteCategory(categoryId);

                    if (resultDto.Result == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }

                    client.Close();

                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    log4net.LogManager.GetLogger("LOGGER").Error(ex.Detail.Message);
                }
            }

            return ServerResponse.DataBaseError;
        }

        public ServerResponse EditeCategory(int categoryId, string categoryName)
        {
            using (var client = new ReminderService.ReminderServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.EditeCategory(categoryId, categoryName);

                    if (resultDto.Result == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }

                    client.Close();

                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    log4net.LogManager.GetLogger("LOGGER").Error(ex.Detail.Message);
                }
            }

            return ServerResponse.DataBaseError;
        }

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

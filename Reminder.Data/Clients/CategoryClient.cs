﻿using System.Collections.Generic;
using Reminder.Common.Entity;
using System.ServiceModel;
using Reminder.Common.Enums;
using log4net;

namespace Reminder.Data.Clients
{
    public class CategoryClient: ICategoryClient
    {
        private ILog logger;

        public CategoryClient()
        {
            logger = LogManager.GetLogger("LOGGER");
        }

        public ServerResponse AddCategory(string categoryName)
        {
            using (var client = new ReminderService.CategoryServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.AddCategory(categoryName);

                    client.Close();

                    if (resultDto == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }

                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }

            return ServerResponse.DataBaseError;
        }

        public ServerResponse DeleteCategory(int categoryId)
        {
            using (var client = new ReminderService.CategoryServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.DeleteCategory(categoryId);

                    client.Close();

                    if (resultDto == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }

                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }

            return ServerResponse.DataBaseError;
        }

        public ServerResponse EditeCategory(int categoryId, string categoryName)
        {
            using (var client = new ReminderService.CategoryServiceClient())
            {
                try
                {
                    client.Open();

                    var resultDto = client.EditeCategory(categoryId, categoryName);

                    client.Close();

                    if (resultDto == (int)ServerResponse.NoError)
                    {
                        return ServerResponse.NoError;
                    }
                }
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }

            return ServerResponse.DataBaseError;
        }

        public IReadOnlyList<Category> GetCategories()
        {
            var result = new List<Category>();
            using (var client = new ReminderService.CategoryServiceClient())
            {
                try
                {
                    client.Open();

                    var categoriesDto = client.GetAllCategories();

                    client.Close();

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
                catch (FaultException<ReminderService.ServiceErrorDto> ex)
                {
                    logger.Error(ex.Detail.Message);
                }
            }
            return result;
        }
    }
}

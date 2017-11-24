﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminder.Data.ReminderService;
using Reminder.Domain.Entity;

namespace Reminder.Data.Clients
{
    public class CategoryClient: ICategoryClient
    {
        public List<Category> GetCategories()
        {
            var result = new List<Category>();
            using (var client = new ReminderService.ReminderServiceClient())
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
            return result;
        }
    }
}

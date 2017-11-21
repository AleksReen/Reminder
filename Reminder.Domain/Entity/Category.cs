using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Domain.Entity
{
    //essence describing Category
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public Category()
        {

        }
        public Category(int id, string name)
        {
            this.CategoryId = id;
            this.Name = name;
        }
    }
}

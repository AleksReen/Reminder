using System.Runtime.Serialization;

namespace Reminder.Service.Contracts.Models.Dto
{
    [DataContract]
    public class CategoryDto
    {
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
    }
}
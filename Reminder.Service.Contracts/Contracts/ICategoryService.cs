using Reminder.Service.Contracts.Models.Dto;
using Reminder.Service.ModelDto.Dto;
using System.ServiceModel;

namespace Reminder.Service.Contracts.Contracts
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        CategoryDto[] GetAllCategories();

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        int AddCategory(string categoryName);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        int EditeCategory(int categoryId, string categoryName);

        [OperationContract]
        [FaultContract(typeof(ServiceErrorDto))]
        int DeleteCategory(int categoryId);
    }
}

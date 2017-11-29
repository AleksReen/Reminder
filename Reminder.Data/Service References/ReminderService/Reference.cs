﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reminder.Data.ReminderService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReminderService.IReminderService")]
    public interface IReminderService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetAllReminders", ReplyAction="http://tempuri.org/IReminderService/GetAllRemindersResponse")]
        Reminder.Service.Contracts.Models.Dto.MyReminderDto[] GetAllReminders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetAllReminders", ReplyAction="http://tempuri.org/IReminderService/GetAllRemindersResponse")]
        System.Threading.Tasks.Task<Reminder.Service.Contracts.Models.Dto.MyReminderDto[]> GetAllRemindersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetAllCategories", ReplyAction="http://tempuri.org/IReminderService/GetAllCategoriesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Reminder.Service.ModelDto.Dto.ServiceErrorDto), Action="http://tempuri.org/IReminderService/GetAllCategoriesServiceErrorDtoFault", Name="ServiceErrorDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.ModelDto.Dto")]
        Reminder.Service.Contracts.Models.Dto.CategoryDto[] GetAllCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetAllCategories", ReplyAction="http://tempuri.org/IReminderService/GetAllCategoriesResponse")]
        System.Threading.Tasks.Task<Reminder.Service.Contracts.Models.Dto.CategoryDto[]> GetAllCategoriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetReminderInfo", ReplyAction="http://tempuri.org/IReminderService/GetReminderInfoResponse")]
        Reminder.Service.Contracts.Models.Dto.ReminderInfoDto GetReminderInfo(int reminderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetReminderInfo", ReplyAction="http://tempuri.org/IReminderService/GetReminderInfoResponse")]
        System.Threading.Tasks.Task<Reminder.Service.Contracts.Models.Dto.ReminderInfoDto> GetReminderInfoAsync(int reminderId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReminderServiceChannel : Reminder.Data.ReminderService.IReminderService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReminderServiceClient : System.ServiceModel.ClientBase<Reminder.Data.ReminderService.IReminderService>, Reminder.Data.ReminderService.IReminderService {
        
        public ReminderServiceClient() {
        }
        
        public ReminderServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReminderServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReminderServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReminderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Reminder.Service.Contracts.Models.Dto.MyReminderDto[] GetAllReminders() {
            return base.Channel.GetAllReminders();
        }
        
        public System.Threading.Tasks.Task<Reminder.Service.Contracts.Models.Dto.MyReminderDto[]> GetAllRemindersAsync() {
            return base.Channel.GetAllRemindersAsync();
        }
        
        public Reminder.Service.Contracts.Models.Dto.CategoryDto[] GetAllCategories() {
            return base.Channel.GetAllCategories();
        }
        
        public System.Threading.Tasks.Task<Reminder.Service.Contracts.Models.Dto.CategoryDto[]> GetAllCategoriesAsync() {
            return base.Channel.GetAllCategoriesAsync();
        }
        
        public Reminder.Service.Contracts.Models.Dto.ReminderInfoDto GetReminderInfo(int reminderId) {
            return base.Channel.GetReminderInfo(reminderId);
        }
        
        public System.Threading.Tasks.Task<Reminder.Service.Contracts.Models.Dto.ReminderInfoDto> GetReminderInfoAsync(int reminderId) {
            return base.Channel.GetReminderInfoAsync(reminderId);
        }
    }
}

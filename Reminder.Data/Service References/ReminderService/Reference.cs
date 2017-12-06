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
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MyReminderDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.Contracts.Models.Dto")]
    [System.SerializableAttribute()]
    public partial class MyReminderDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CategoryIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ReminderIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ReminderTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CategoryId {
            get {
                return this.CategoryIdField;
            }
            set {
                if ((this.CategoryIdField.Equals(value) != true)) {
                    this.CategoryIdField = value;
                    this.RaisePropertyChanged("CategoryId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Image {
            get {
                return this.ImageField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageField, value) != true)) {
                    this.ImageField = value;
                    this.RaisePropertyChanged("Image");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ReminderId {
            get {
                return this.ReminderIdField;
            }
            set {
                if ((this.ReminderIdField.Equals(value) != true)) {
                    this.ReminderIdField = value;
                    this.RaisePropertyChanged("ReminderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ReminderTime {
            get {
                return this.ReminderTimeField;
            }
            set {
                if ((this.ReminderTimeField.Equals(value) != true)) {
                    this.ReminderTimeField = value;
                    this.RaisePropertyChanged("ReminderTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceErrorDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.ModelDto.Dto")]
    [System.SerializableAttribute()]
    public partial class ServiceErrorDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DetailsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Details {
            get {
                return this.DetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailsField, value) != true)) {
                    this.DetailsField = value;
                    this.RaisePropertyChanged("Details");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CategoryDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.Contracts.Models.Dto")]
    [System.SerializableAttribute()]
    public partial class CategoryDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CategoryIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CategoryId {
            get {
                return this.CategoryIdField;
            }
            set {
                if ((this.CategoryIdField.Equals(value) != true)) {
                    this.CategoryIdField = value;
                    this.RaisePropertyChanged("CategoryId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CategoryName {
            get {
                return this.CategoryNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryNameField, value) != true)) {
                    this.CategoryNameField = value;
                    this.RaisePropertyChanged("CategoryName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReminderInfoDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.Contracts.Models.Dto")]
    [System.SerializableAttribute()]
    public partial class ReminderInfoDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ActionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Reminder.Data.ReminderService.MyReminderDto ReminderField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Actions {
            get {
                return this.ActionsField;
            }
            set {
                if ((object.ReferenceEquals(this.ActionsField, value) != true)) {
                    this.ActionsField = value;
                    this.RaisePropertyChanged("Actions");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Category {
            get {
                return this.CategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryField, value) != true)) {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Reminder.Data.ReminderService.MyReminderDto Reminder {
            get {
                return this.ReminderField;
            }
            set {
                if ((object.ReferenceEquals(this.ReminderField, value) != true)) {
                    this.ReminderField = value;
                    this.RaisePropertyChanged("Reminder");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.ModelDto.Dto")]
    [System.SerializableAttribute()]
    public partial class UserDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] RolesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login {
            get {
                return this.LoginField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginField, value) != true)) {
                    this.LoginField = value;
                    this.RaisePropertyChanged("Login");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Roles {
            get {
                return this.RolesField;
            }
            set {
                if ((object.ReferenceEquals(this.RolesField, value) != true)) {
                    this.RolesField = value;
                    this.RaisePropertyChanged("Roles");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServerResultDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.ModelDto.Dto")]
    [System.SerializableAttribute()]
    public partial class ServerResultDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ResultField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReminderService.IReminderService")]
    public interface IReminderService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetAllReminders", ReplyAction="http://tempuri.org/IReminderService/GetAllRemindersResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Reminder.Data.ReminderService.ServiceErrorDto), Action="http://tempuri.org/IReminderService/GetAllRemindersServiceErrorDtoFault", Name="ServiceErrorDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.ModelDto.Dto")]
        Reminder.Data.ReminderService.MyReminderDto[] GetAllReminders(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetAllReminders", ReplyAction="http://tempuri.org/IReminderService/GetAllRemindersResponse")]
        System.Threading.Tasks.Task<Reminder.Data.ReminderService.MyReminderDto[]> GetAllRemindersAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetAllCategories", ReplyAction="http://tempuri.org/IReminderService/GetAllCategoriesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Reminder.Data.ReminderService.ServiceErrorDto), Action="http://tempuri.org/IReminderService/GetAllCategoriesServiceErrorDtoFault", Name="ServiceErrorDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.ModelDto.Dto")]
        Reminder.Data.ReminderService.CategoryDto[] GetAllCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetAllCategories", ReplyAction="http://tempuri.org/IReminderService/GetAllCategoriesResponse")]
        System.Threading.Tasks.Task<Reminder.Data.ReminderService.CategoryDto[]> GetAllCategoriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetReminderInfo", ReplyAction="http://tempuri.org/IReminderService/GetReminderInfoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Reminder.Data.ReminderService.ServiceErrorDto), Action="http://tempuri.org/IReminderService/GetReminderInfoServiceErrorDtoFault", Name="ServiceErrorDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.ModelDto.Dto")]
        Reminder.Data.ReminderService.ReminderInfoDto GetReminderInfo(int reminderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetReminderInfo", ReplyAction="http://tempuri.org/IReminderService/GetReminderInfoResponse")]
        System.Threading.Tasks.Task<Reminder.Data.ReminderService.ReminderInfoDto> GetReminderInfoAsync(int reminderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetCurrentUser", ReplyAction="http://tempuri.org/IReminderService/GetCurrentUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Reminder.Data.ReminderService.ServiceErrorDto), Action="http://tempuri.org/IReminderService/GetCurrentUserServiceErrorDtoFault", Name="ServiceErrorDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.ModelDto.Dto")]
        Reminder.Data.ReminderService.UserDto GetCurrentUser(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetCurrentUser", ReplyAction="http://tempuri.org/IReminderService/GetCurrentUserResponse")]
        System.Threading.Tasks.Task<Reminder.Data.ReminderService.UserDto> GetCurrentUserAsync(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/AddCategory", ReplyAction="http://tempuri.org/IReminderService/AddCategoryResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Reminder.Data.ReminderService.ServiceErrorDto), Action="http://tempuri.org/IReminderService/AddCategoryServiceErrorDtoFault", Name="ServiceErrorDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.ModelDto.Dto")]
        Reminder.Data.ReminderService.ServerResultDto AddCategory(string categoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/AddCategory", ReplyAction="http://tempuri.org/IReminderService/AddCategoryResponse")]
        System.Threading.Tasks.Task<Reminder.Data.ReminderService.ServerResultDto> AddCategoryAsync(string categoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/EditeCategory", ReplyAction="http://tempuri.org/IReminderService/EditeCategoryResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Reminder.Data.ReminderService.ServiceErrorDto), Action="http://tempuri.org/IReminderService/EditeCategoryServiceErrorDtoFault", Name="ServiceErrorDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.ModelDto.Dto")]
        Reminder.Data.ReminderService.ServerResultDto EditeCategory(int categoryId, string categoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/EditeCategory", ReplyAction="http://tempuri.org/IReminderService/EditeCategoryResponse")]
        System.Threading.Tasks.Task<Reminder.Data.ReminderService.ServerResultDto> EditeCategoryAsync(int categoryId, string categoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/DeleteCategory", ReplyAction="http://tempuri.org/IReminderService/DeleteCategoryResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Reminder.Data.ReminderService.ServiceErrorDto), Action="http://tempuri.org/IReminderService/DeleteCategoryServiceErrorDtoFault", Name="ServiceErrorDto", Namespace="http://schemas.datacontract.org/2004/07/Reminder.Service.ModelDto.Dto")]
        Reminder.Data.ReminderService.ServerResultDto DeleteCategory(int categoryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/DeleteCategory", ReplyAction="http://tempuri.org/IReminderService/DeleteCategoryResponse")]
        System.Threading.Tasks.Task<Reminder.Data.ReminderService.ServerResultDto> DeleteCategoryAsync(int categoryId);
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
        
        public Reminder.Data.ReminderService.MyReminderDto[] GetAllReminders(int userId) {
            return base.Channel.GetAllReminders(userId);
        }
        
        public System.Threading.Tasks.Task<Reminder.Data.ReminderService.MyReminderDto[]> GetAllRemindersAsync(int userId) {
            return base.Channel.GetAllRemindersAsync(userId);
        }
        
        public Reminder.Data.ReminderService.CategoryDto[] GetAllCategories() {
            return base.Channel.GetAllCategories();
        }
        
        public System.Threading.Tasks.Task<Reminder.Data.ReminderService.CategoryDto[]> GetAllCategoriesAsync() {
            return base.Channel.GetAllCategoriesAsync();
        }
        
        public Reminder.Data.ReminderService.ReminderInfoDto GetReminderInfo(int reminderId) {
            return base.Channel.GetReminderInfo(reminderId);
        }
        
        public System.Threading.Tasks.Task<Reminder.Data.ReminderService.ReminderInfoDto> GetReminderInfoAsync(int reminderId) {
            return base.Channel.GetReminderInfoAsync(reminderId);
        }
        
        public Reminder.Data.ReminderService.UserDto GetCurrentUser(string login, string password) {
            return base.Channel.GetCurrentUser(login, password);
        }
        
        public System.Threading.Tasks.Task<Reminder.Data.ReminderService.UserDto> GetCurrentUserAsync(string login, string password) {
            return base.Channel.GetCurrentUserAsync(login, password);
        }
        
        public Reminder.Data.ReminderService.ServerResultDto AddCategory(string categoryName) {
            return base.Channel.AddCategory(categoryName);
        }
        
        public System.Threading.Tasks.Task<Reminder.Data.ReminderService.ServerResultDto> AddCategoryAsync(string categoryName) {
            return base.Channel.AddCategoryAsync(categoryName);
        }
        
        public Reminder.Data.ReminderService.ServerResultDto EditeCategory(int categoryId, string categoryName) {
            return base.Channel.EditeCategory(categoryId, categoryName);
        }
        
        public System.Threading.Tasks.Task<Reminder.Data.ReminderService.ServerResultDto> EditeCategoryAsync(int categoryId, string categoryName) {
            return base.Channel.EditeCategoryAsync(categoryId, categoryName);
        }
        
        public Reminder.Data.ReminderService.ServerResultDto DeleteCategory(int categoryId) {
            return base.Channel.DeleteCategory(categoryId);
        }
        
        public System.Threading.Tasks.Task<Reminder.Data.ReminderService.ServerResultDto> DeleteCategoryAsync(int categoryId) {
            return base.Channel.DeleteCategoryAsync(categoryId);
        }
    }
}

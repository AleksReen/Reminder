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
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ReminderIdField;
        
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
        Reminder.Data.ReminderService.MyReminderDto[] GetAllReminders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetAllReminders", ReplyAction="http://tempuri.org/IReminderService/GetAllRemindersResponse")]
        System.Threading.Tasks.Task<Reminder.Data.ReminderService.MyReminderDto[]> GetAllRemindersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetAllCategories", ReplyAction="http://tempuri.org/IReminderService/GetAllCategoriesResponse")]
        Reminder.Data.ReminderService.CategoryDto[] GetAllCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetAllCategories", ReplyAction="http://tempuri.org/IReminderService/GetAllCategoriesResponse")]
        System.Threading.Tasks.Task<Reminder.Data.ReminderService.CategoryDto[]> GetAllCategoriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetReminderDescription", ReplyAction="http://tempuri.org/IReminderService/GetReminderDescriptionResponse")]
        Reminder.Data.ReminderService.ReminderInfoDto GetReminderDescription(int reminderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReminderService/GetReminderDescription", ReplyAction="http://tempuri.org/IReminderService/GetReminderDescriptionResponse")]
        System.Threading.Tasks.Task<Reminder.Data.ReminderService.ReminderInfoDto> GetReminderDescriptionAsync(int reminderId);
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
        
        public Reminder.Data.ReminderService.MyReminderDto[] GetAllReminders() {
            return base.Channel.GetAllReminders();
        }
        
        public System.Threading.Tasks.Task<Reminder.Data.ReminderService.MyReminderDto[]> GetAllRemindersAsync() {
            return base.Channel.GetAllRemindersAsync();
        }
        
        public Reminder.Data.ReminderService.CategoryDto[] GetAllCategories() {
            return base.Channel.GetAllCategories();
        }
        
        public System.Threading.Tasks.Task<Reminder.Data.ReminderService.CategoryDto[]> GetAllCategoriesAsync() {
            return base.Channel.GetAllCategoriesAsync();
        }
        
        public Reminder.Data.ReminderService.ReminderInfoDto GetReminderDescription(int reminderId) {
            return base.Channel.GetReminderDescription(reminderId);
        }
        
        public System.Threading.Tasks.Task<Reminder.Data.ReminderService.ReminderInfoDto> GetReminderDescriptionAsync(int reminderId) {
            return base.Channel.GetReminderDescriptionAsync(reminderId);
        }
    }
}

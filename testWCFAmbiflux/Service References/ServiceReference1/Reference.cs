﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.586
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testWCFAmbiflux.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/AmbifluxWcfService")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string firstnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string lastnameField;
        
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
        public string firstname {
            get {
                return this.firstnameField;
            }
            set {
                if ((object.ReferenceEquals(this.firstnameField, value) != true)) {
                    this.firstnameField = value;
                    this.RaisePropertyChanged("firstname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string lastname {
            get {
                return this.lastnameField;
            }
            set {
                if ((object.ReferenceEquals(this.lastnameField, value) != true)) {
                    this.lastnameField = value;
                    this.RaisePropertyChanged("lastname");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ResourceRecord", Namespace="http://schemas.datacontract.org/2004/07/AmbifluxWcfService")]
    [System.SerializableAttribute()]
    public partial class ResourceRecord : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LocationIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ResourceIdField;
        
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
        public int LocationId {
            get {
                return this.LocationIdField;
            }
            set {
                if ((this.LocationIdField.Equals(value) != true)) {
                    this.LocationIdField = value;
                    this.RaisePropertyChanged("LocationId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ResourceId {
            get {
                return this.ResourceIdField;
            }
            set {
                if ((this.ResourceIdField.Equals(value) != true)) {
                    this.ResourceIdField = value;
                    this.RaisePropertyChanged("ResourceId");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderHeaderRecord", Namespace="http://schemas.datacontract.org/2004/07/AmbifluxWcfService")]
    [System.SerializableAttribute()]
    public partial class OrderHeaderRecord : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerFirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerLastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ObjetDemandeExpressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrderDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrderNoField;
        
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
        public string CustomerFirstName {
            get {
                return this.CustomerFirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerFirstNameField, value) != true)) {
                    this.CustomerFirstNameField = value;
                    this.RaisePropertyChanged("CustomerFirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerLastName {
            get {
                return this.CustomerLastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerLastNameField, value) != true)) {
                    this.CustomerLastNameField = value;
                    this.RaisePropertyChanged("CustomerLastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ObjetDemandeExpress {
            get {
                return this.ObjetDemandeExpressField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjetDemandeExpressField, value) != true)) {
                    this.ObjetDemandeExpressField = value;
                    this.RaisePropertyChanged("ObjetDemandeExpress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrderDate {
            get {
                return this.OrderDateField;
            }
            set {
                if ((object.ReferenceEquals(this.OrderDateField, value) != true)) {
                    this.OrderDateField = value;
                    this.RaisePropertyChanged("OrderDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderId {
            get {
                return this.OrderIdField;
            }
            set {
                if ((this.OrderIdField.Equals(value) != true)) {
                    this.OrderIdField = value;
                    this.RaisePropertyChanged("OrderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrderNo {
            get {
                return this.OrderNoField;
            }
            set {
                if ((object.ReferenceEquals(this.OrderNoField, value) != true)) {
                    this.OrderNoField = value;
                    this.RaisePropertyChanged("OrderNo");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="SRMARecord", Namespace="http://schemas.datacontract.org/2004/07/AmbifluxWcfService")]
    [System.SerializableAttribute()]
    public partial class SRMARecord : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ModeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ResourceIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TaskField;
        
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
        public int Mode {
            get {
                return this.ModeField;
            }
            set {
                if ((this.ModeField.Equals(value) != true)) {
                    this.ModeField = value;
                    this.RaisePropertyChanged("Mode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ResourceId {
            get {
                return this.ResourceIdField;
            }
            set {
                if ((this.ResourceIdField.Equals(value) != true)) {
                    this.ResourceIdField = value;
                    this.RaisePropertyChanged("ResourceId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int State {
            get {
                return this.StateField;
            }
            set {
                if ((this.StateField.Equals(value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Task {
            get {
                return this.TaskField;
            }
            set {
                if ((this.TaskField.Equals(value) != true)) {
                    this.TaskField = value;
                    this.RaisePropertyChanged("Task");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IAmbiflux")]
    public interface IAmbiflux {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmbiflux/GetAllEmployeesMethod", ReplyAction="http://tempuri.org/IAmbiflux/GetAllEmployeesMethodResponse")]
        testWCFAmbiflux.ServiceReference1.Employee[] GetAllEmployeesMethod();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmbiflux/GetEmployeeById", ReplyAction="http://tempuri.org/IAmbiflux/GetEmployeeByIdResponse")]
        testWCFAmbiflux.ServiceReference1.Employee GetEmployeeById(string resourceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmbiflux/GetResourceById", ReplyAction="http://tempuri.org/IAmbiflux/GetResourceByIdResponse")]
        testWCFAmbiflux.ServiceReference1.ResourceRecord GetResourceById(string resourceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmbiflux/GetOrderHeaderById", ReplyAction="http://tempuri.org/IAmbiflux/GetOrderHeaderByIdResponse")]
        testWCFAmbiflux.ServiceReference1.OrderHeaderRecord GetOrderHeaderById(string orderHeaderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmbiflux/GetSRMA", ReplyAction="http://tempuri.org/IAmbiflux/GetSRMAResponse")]
        testWCFAmbiflux.ServiceReference1.SRMARecord GetSRMA();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAmbiflux/NewSRMARequest", ReplyAction="http://tempuri.org/IAmbiflux/NewSRMARequestResponse")]
        string NewSRMARequest(string phoneNumber, string locationId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAmbifluxChannel : testWCFAmbiflux.ServiceReference1.IAmbiflux, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AmbifluxClient : System.ServiceModel.ClientBase<testWCFAmbiflux.ServiceReference1.IAmbiflux>, testWCFAmbiflux.ServiceReference1.IAmbiflux {
        
        public AmbifluxClient() {
        }
        
        public AmbifluxClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AmbifluxClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AmbifluxClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AmbifluxClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public testWCFAmbiflux.ServiceReference1.Employee[] GetAllEmployeesMethod() {
            return base.Channel.GetAllEmployeesMethod();
        }
        
        public testWCFAmbiflux.ServiceReference1.Employee GetEmployeeById(string resourceId) {
            return base.Channel.GetEmployeeById(resourceId);
        }
        
        public testWCFAmbiflux.ServiceReference1.ResourceRecord GetResourceById(string resourceId) {
            return base.Channel.GetResourceById(resourceId);
        }
        
        public testWCFAmbiflux.ServiceReference1.OrderHeaderRecord GetOrderHeaderById(string orderHeaderId) {
            return base.Channel.GetOrderHeaderById(orderHeaderId);
        }
        
        public testWCFAmbiflux.ServiceReference1.SRMARecord GetSRMA() {
            return base.Channel.GetSRMA();
        }
        
        public string NewSRMARequest(string phoneNumber, string locationId) {
            return base.Channel.NewSRMARequest(phoneNumber, locationId);
        }
    }
}

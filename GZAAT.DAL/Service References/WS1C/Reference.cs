﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GZAAT.DAL.WS1C {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ContragentsTable", Namespace="http://www.sample-package.org", ItemName="Contragents")]
    [System.SerializableAttribute()]
    public class ContragentsTable : System.Collections.Generic.List<GZAAT.DAL.WS1C.Contragents> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Contragents", Namespace="http://www.sample-package.org")]
    [System.SerializableAttribute()]
    public partial class Contragents : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string CodeField;
        
        private string NameField;
        
        private string TINField;
        
        private string StudentMobilePhoneField;
        
        private string MotherMobilePhoneField;
        
        private string FatherMobilePhoneField;
        
        private string MotherFirstAndLastNameField;
        
        private string FatherFirstAndLastNameField;
        
        private string CurrenciesCodField;
        
        private double DebtField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string TIN {
            get {
                return this.TINField;
            }
            set {
                if ((object.ReferenceEquals(this.TINField, value) != true)) {
                    this.TINField = value;
                    this.RaisePropertyChanged("TIN");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=3)]
        public string StudentMobilePhone {
            get {
                return this.StudentMobilePhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.StudentMobilePhoneField, value) != true)) {
                    this.StudentMobilePhoneField = value;
                    this.RaisePropertyChanged("StudentMobilePhone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=4)]
        public string MotherMobilePhone {
            get {
                return this.MotherMobilePhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.MotherMobilePhoneField, value) != true)) {
                    this.MotherMobilePhoneField = value;
                    this.RaisePropertyChanged("MotherMobilePhone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=5)]
        public string FatherMobilePhone {
            get {
                return this.FatherMobilePhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.FatherMobilePhoneField, value) != true)) {
                    this.FatherMobilePhoneField = value;
                    this.RaisePropertyChanged("FatherMobilePhone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=6)]
        public string MotherFirstAndLastName {
            get {
                return this.MotherFirstAndLastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MotherFirstAndLastNameField, value) != true)) {
                    this.MotherFirstAndLastNameField = value;
                    this.RaisePropertyChanged("MotherFirstAndLastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=7)]
        public string FatherFirstAndLastName {
            get {
                return this.FatherFirstAndLastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FatherFirstAndLastNameField, value) != true)) {
                    this.FatherFirstAndLastNameField = value;
                    this.RaisePropertyChanged("FatherFirstAndLastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=8)]
        public string CurrenciesCod {
            get {
                return this.CurrenciesCodField;
            }
            set {
                if ((object.ReferenceEquals(this.CurrenciesCodField, value) != true)) {
                    this.CurrenciesCodField = value;
                    this.RaisePropertyChanged("CurrenciesCod");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=9)]
        public double Debt {
            get {
                return this.DebtField;
            }
            set {
                if ((this.DebtField.Equals(value) != true)) {
                    this.DebtField = value;
                    this.RaisePropertyChanged("Debt");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.sample-package.org", ConfigurationName="WS1C.Service1cPortType")]
    public interface Service1cPortType {
        
        // CODEGEN: Generating message contract since element name return from namespace http://www.sample-package.org is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sample-package.org#Service1c:CreateContragents", ReplyAction="*")]
        GZAAT.DAL.WS1C.CreateContragentsResponse CreateContragents(GZAAT.DAL.WS1C.CreateContragentsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.sample-package.org#Service1c:CreateContragents", ReplyAction="*")]
        System.Threading.Tasks.Task<GZAAT.DAL.WS1C.CreateContragentsResponse> CreateContragentsAsync(GZAAT.DAL.WS1C.CreateContragentsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateContragentsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CreateContragents", Namespace="http://www.sample-package.org", Order=0)]
        public GZAAT.DAL.WS1C.CreateContragentsRequestBody Body;
        
        public CreateContragentsRequest() {
        }
        
        public CreateContragentsRequest(GZAAT.DAL.WS1C.CreateContragentsRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class CreateContragentsRequestBody {
        
        public CreateContragentsRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateContragentsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CreateContragentsResponse", Namespace="http://www.sample-package.org", Order=0)]
        public GZAAT.DAL.WS1C.CreateContragentsResponseBody Body;
        
        public CreateContragentsResponse() {
        }
        
        public CreateContragentsResponse(GZAAT.DAL.WS1C.CreateContragentsResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.sample-package.org")]
    public partial class CreateContragentsResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public GZAAT.DAL.WS1C.ContragentsTable @return;
        
        public CreateContragentsResponseBody() {
        }
        
        public CreateContragentsResponseBody(GZAAT.DAL.WS1C.ContragentsTable @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Service1cPortTypeChannel : GZAAT.DAL.WS1C.Service1cPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1cPortTypeClient : System.ServiceModel.ClientBase<GZAAT.DAL.WS1C.Service1cPortType>, GZAAT.DAL.WS1C.Service1cPortType {
        
        public Service1cPortTypeClient() {
        }
        
        public Service1cPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1cPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1cPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1cPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GZAAT.DAL.WS1C.CreateContragentsResponse GZAAT.DAL.WS1C.Service1cPortType.CreateContragents(GZAAT.DAL.WS1C.CreateContragentsRequest request) {
            return base.Channel.CreateContragents(request);
        }
        
        public GZAAT.DAL.WS1C.ContragentsTable CreateContragents() {
            GZAAT.DAL.WS1C.CreateContragentsRequest inValue = new GZAAT.DAL.WS1C.CreateContragentsRequest();
            inValue.Body = new GZAAT.DAL.WS1C.CreateContragentsRequestBody();
            GZAAT.DAL.WS1C.CreateContragentsResponse retVal = ((GZAAT.DAL.WS1C.Service1cPortType)(this)).CreateContragents(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GZAAT.DAL.WS1C.CreateContragentsResponse> GZAAT.DAL.WS1C.Service1cPortType.CreateContragentsAsync(GZAAT.DAL.WS1C.CreateContragentsRequest request) {
            return base.Channel.CreateContragentsAsync(request);
        }
        
        public System.Threading.Tasks.Task<GZAAT.DAL.WS1C.CreateContragentsResponse> CreateContragentsAsync() {
            GZAAT.DAL.WS1C.CreateContragentsRequest inValue = new GZAAT.DAL.WS1C.CreateContragentsRequest();
            inValue.Body = new GZAAT.DAL.WS1C.CreateContragentsRequestBody();
            return ((GZAAT.DAL.WS1C.Service1cPortType)(this)).CreateContragentsAsync(inValue);
        }
    }
}

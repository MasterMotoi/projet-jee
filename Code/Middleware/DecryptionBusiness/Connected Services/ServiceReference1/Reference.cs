﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DecryptionBusiness.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://wsJax.payara.fish/", ConfigurationName="ServiceReference1.WsJax")]
    public interface WsJax {
        
        // CODEGEN : Le paramètre 'arg0' nécessite des informations de schéma supplémentaires qui ne peuvent pas être capturées en utilisant le mode du paramètre. L'attribut spécifique est 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://wsJax.payara.fish/WsJax/sendJMSMessageRequest", ReplyAction="http://wsJax.payara.fish/WsJax/sendJMSMessageResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        DecryptionBusiness.ServiceReference1.sendJMSMessageResponse sendJMSMessage(DecryptionBusiness.ServiceReference1.sendJMSMessageRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wsJax.payara.fish/WsJax/sendJMSMessageRequest", ReplyAction="http://wsJax.payara.fish/WsJax/sendJMSMessageResponse")]
        System.Threading.Tasks.Task<DecryptionBusiness.ServiceReference1.sendJMSMessageResponse> sendJMSMessageAsync(DecryptionBusiness.ServiceReference1.sendJMSMessageRequest request);
        
        // CODEGEN : Le paramètre 'return' nécessite des informations de schéma supplémentaires qui ne peuvent pas être capturées en utilisant le mode du paramètre. L'attribut spécifique est 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://wsJax.payara.fish/WsJax/sendCurrentFileRequest", ReplyAction="http://wsJax.payara.fish/WsJax/sendCurrentFileResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        DecryptionBusiness.ServiceReference1.sendCurrentFileResponse sendCurrentFile(DecryptionBusiness.ServiceReference1.sendCurrentFileRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wsJax.payara.fish/WsJax/sendCurrentFileRequest", ReplyAction="http://wsJax.payara.fish/WsJax/sendCurrentFileResponse")]
        System.Threading.Tasks.Task<DecryptionBusiness.ServiceReference1.sendCurrentFileResponse> sendCurrentFileAsync(DecryptionBusiness.ServiceReference1.sendCurrentFileRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://wsJax.payara.fish/")]
    public partial class recept : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string currentKeyField;
        
        private string fileContentField;
        
        private string fileNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string currentKey {
            get {
                return this.currentKeyField;
            }
            set {
                this.currentKeyField = value;
                this.RaisePropertyChanged("currentKey");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string fileContent {
            get {
                return this.fileContentField;
            }
            set {
                this.fileContentField = value;
                this.RaisePropertyChanged("fileContent");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string fileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
                this.RaisePropertyChanged("fileName");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendJMSMessage", WrapperNamespace="http://wsJax.payara.fish/", IsWrapped=true)]
    public partial class sendJMSMessageRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wsJax.payara.fish/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DecryptionBusiness.ServiceReference1.recept arg0;
        
        public sendJMSMessageRequest() {
        }
        
        public sendJMSMessageRequest(DecryptionBusiness.ServiceReference1.recept arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendJMSMessageResponse", WrapperNamespace="http://wsJax.payara.fish/", IsWrapped=true)]
    public partial class sendJMSMessageResponse {
        
        public sendJMSMessageResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendCurrentFile", WrapperNamespace="http://wsJax.payara.fish/", IsWrapped=true)]
    public partial class sendCurrentFileRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wsJax.payara.fish/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string fileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wsJax.payara.fish/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string fileContent;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wsJax.payara.fish/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string currentKey;
        
        public sendCurrentFileRequest() {
        }
        
        public sendCurrentFileRequest(string fileName, string fileContent, string currentKey) {
            this.fileName = fileName;
            this.fileContent = fileContent;
            this.currentKey = currentKey;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendCurrentFileResponse", WrapperNamespace="http://wsJax.payara.fish/", IsWrapped=true)]
    public partial class sendCurrentFileResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wsJax.payara.fish/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string @return;
        
        public sendCurrentFileResponse() {
        }
        
        public sendCurrentFileResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WsJaxChannel : DecryptionBusiness.ServiceReference1.WsJax, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WsJaxClient : System.ServiceModel.ClientBase<DecryptionBusiness.ServiceReference1.WsJax>, DecryptionBusiness.ServiceReference1.WsJax {
        
        public WsJaxClient() {
        }
        
        public WsJaxClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WsJaxClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WsJaxClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WsJaxClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DecryptionBusiness.ServiceReference1.sendJMSMessageResponse DecryptionBusiness.ServiceReference1.WsJax.sendJMSMessage(DecryptionBusiness.ServiceReference1.sendJMSMessageRequest request) {
            return base.Channel.sendJMSMessage(request);
        }
        
        public void sendJMSMessage(DecryptionBusiness.ServiceReference1.recept arg0) {
            DecryptionBusiness.ServiceReference1.sendJMSMessageRequest inValue = new DecryptionBusiness.ServiceReference1.sendJMSMessageRequest();
            inValue.arg0 = arg0;
            DecryptionBusiness.ServiceReference1.sendJMSMessageResponse retVal = ((DecryptionBusiness.ServiceReference1.WsJax)(this)).sendJMSMessage(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<DecryptionBusiness.ServiceReference1.sendJMSMessageResponse> DecryptionBusiness.ServiceReference1.WsJax.sendJMSMessageAsync(DecryptionBusiness.ServiceReference1.sendJMSMessageRequest request) {
            return base.Channel.sendJMSMessageAsync(request);
        }
        
        public System.Threading.Tasks.Task<DecryptionBusiness.ServiceReference1.sendJMSMessageResponse> sendJMSMessageAsync(DecryptionBusiness.ServiceReference1.recept arg0) {
            DecryptionBusiness.ServiceReference1.sendJMSMessageRequest inValue = new DecryptionBusiness.ServiceReference1.sendJMSMessageRequest();
            inValue.arg0 = arg0;
            return ((DecryptionBusiness.ServiceReference1.WsJax)(this)).sendJMSMessageAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DecryptionBusiness.ServiceReference1.sendCurrentFileResponse DecryptionBusiness.ServiceReference1.WsJax.sendCurrentFile(DecryptionBusiness.ServiceReference1.sendCurrentFileRequest request) {
            return base.Channel.sendCurrentFile(request);
        }
        
        public string sendCurrentFile(string fileName, string fileContent, string currentKey) {
            DecryptionBusiness.ServiceReference1.sendCurrentFileRequest inValue = new DecryptionBusiness.ServiceReference1.sendCurrentFileRequest();
            inValue.fileName = fileName;
            inValue.fileContent = fileContent;
            inValue.currentKey = currentKey;
            DecryptionBusiness.ServiceReference1.sendCurrentFileResponse retVal = ((DecryptionBusiness.ServiceReference1.WsJax)(this)).sendCurrentFile(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<DecryptionBusiness.ServiceReference1.sendCurrentFileResponse> DecryptionBusiness.ServiceReference1.WsJax.sendCurrentFileAsync(DecryptionBusiness.ServiceReference1.sendCurrentFileRequest request) {
            return base.Channel.sendCurrentFileAsync(request);
        }
        
        public System.Threading.Tasks.Task<DecryptionBusiness.ServiceReference1.sendCurrentFileResponse> sendCurrentFileAsync(string fileName, string fileContent, string currentKey) {
            DecryptionBusiness.ServiceReference1.sendCurrentFileRequest inValue = new DecryptionBusiness.ServiceReference1.sendCurrentFileRequest();
            inValue.fileName = fileName;
            inValue.fileContent = fileContent;
            inValue.currentKey = currentKey;
            return ((DecryptionBusiness.ServiceReference1.WsJax)(this)).sendCurrentFileAsync(inValue);
        }
    }
}

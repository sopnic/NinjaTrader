﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.269.
// 
#pragma warning disable 1591

namespace AlsiTrade_Backend.AlsiWebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AlsiNotifyServiceSoap", Namespace="http://tempuri.org/")]
    public partial class AlsiNotifyService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback InsertNewOrderOperationCompleted;
        
        private System.Threading.SendOrPostCallback InsertMessageOperationCompleted;
        
        private System.Threading.SendOrPostCallback getLastMessageOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllMessagesOperationCompleted;
        
        private System.Threading.SendOrPostCallback getLastOrderOperationCompleted;
        
        private System.Threading.SendOrPostCallback getAllOrdersOperationCompleted;
        
        private System.Threading.SendOrPostCallback clearListsOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendCommandOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCommandOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AlsiNotifyService() {
            this.Url = global::AlsiTrade_Backend.Properties.Settings.Default.AlsiTrade_Backend_AlsiWebService_AlsiNotifyService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event InsertNewOrderCompletedEventHandler InsertNewOrderCompleted;
        
        /// <remarks/>
        public event InsertMessageCompletedEventHandler InsertMessageCompleted;
        
        /// <remarks/>
        public event getLastMessageCompletedEventHandler getLastMessageCompleted;
        
        /// <remarks/>
        public event GetAllMessagesCompletedEventHandler GetAllMessagesCompleted;
        
        /// <remarks/>
        public event getLastOrderCompletedEventHandler getLastOrderCompleted;
        
        /// <remarks/>
        public event getAllOrdersCompletedEventHandler getAllOrdersCompleted;
        
        /// <remarks/>
        public event clearListsCompletedEventHandler clearListsCompleted;
        
        /// <remarks/>
        public event SendCommandCompletedEventHandler SendCommandCompleted;
        
        /// <remarks/>
        public event GetCommandCompletedEventHandler GetCommandCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/InsertNewOrder", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void InsertNewOrder(xlTradeOrder Order) {
            this.Invoke("InsertNewOrder", new object[] {
                        Order});
        }
        
        /// <remarks/>
        public void InsertNewOrderAsync(xlTradeOrder Order) {
            this.InsertNewOrderAsync(Order, null);
        }
        
        /// <remarks/>
        public void InsertNewOrderAsync(xlTradeOrder Order, object userState) {
            if ((this.InsertNewOrderOperationCompleted == null)) {
                this.InsertNewOrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertNewOrderOperationCompleted);
            }
            this.InvokeAsync("InsertNewOrder", new object[] {
                        Order}, this.InsertNewOrderOperationCompleted, userState);
        }
        
        private void OnInsertNewOrderOperationCompleted(object arg) {
            if ((this.InsertNewOrderCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertNewOrderCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/InsertMessage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void InsertMessage(Boodskap message) {
            this.Invoke("InsertMessage", new object[] {
                        message});
        }
        
        /// <remarks/>
        public void InsertMessageAsync(Boodskap message) {
            this.InsertMessageAsync(message, null);
        }
        
        /// <remarks/>
        public void InsertMessageAsync(Boodskap message, object userState) {
            if ((this.InsertMessageOperationCompleted == null)) {
                this.InsertMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertMessageOperationCompleted);
            }
            this.InvokeAsync("InsertMessage", new object[] {
                        message}, this.InsertMessageOperationCompleted, userState);
        }
        
        private void OnInsertMessageOperationCompleted(object arg) {
            if ((this.InsertMessageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertMessageCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getLastMessage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Boodskap getLastMessage() {
            object[] results = this.Invoke("getLastMessage", new object[0]);
            return ((Boodskap)(results[0]));
        }
        
        /// <remarks/>
        public void getLastMessageAsync() {
            this.getLastMessageAsync(null);
        }
        
        /// <remarks/>
        public void getLastMessageAsync(object userState) {
            if ((this.getLastMessageOperationCompleted == null)) {
                this.getLastMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetLastMessageOperationCompleted);
            }
            this.InvokeAsync("getLastMessage", new object[0], this.getLastMessageOperationCompleted, userState);
        }
        
        private void OngetLastMessageOperationCompleted(object arg) {
            if ((this.getLastMessageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getLastMessageCompleted(this, new getLastMessageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllMessages", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Boodskap[] GetAllMessages() {
            object[] results = this.Invoke("GetAllMessages", new object[0]);
            return ((Boodskap[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllMessagesAsync() {
            this.GetAllMessagesAsync(null);
        }
        
        /// <remarks/>
        public void GetAllMessagesAsync(object userState) {
            if ((this.GetAllMessagesOperationCompleted == null)) {
                this.GetAllMessagesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllMessagesOperationCompleted);
            }
            this.InvokeAsync("GetAllMessages", new object[0], this.GetAllMessagesOperationCompleted, userState);
        }
        
        private void OnGetAllMessagesOperationCompleted(object arg) {
            if ((this.GetAllMessagesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllMessagesCompleted(this, new GetAllMessagesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getLastOrder", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public xlTradeOrder getLastOrder() {
            object[] results = this.Invoke("getLastOrder", new object[0]);
            return ((xlTradeOrder)(results[0]));
        }
        
        /// <remarks/>
        public void getLastOrderAsync() {
            this.getLastOrderAsync(null);
        }
        
        /// <remarks/>
        public void getLastOrderAsync(object userState) {
            if ((this.getLastOrderOperationCompleted == null)) {
                this.getLastOrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetLastOrderOperationCompleted);
            }
            this.InvokeAsync("getLastOrder", new object[0], this.getLastOrderOperationCompleted, userState);
        }
        
        private void OngetLastOrderOperationCompleted(object arg) {
            if ((this.getLastOrderCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getLastOrderCompleted(this, new getLastOrderCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getAllOrders", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public xlTradeOrder[] getAllOrders() {
            object[] results = this.Invoke("getAllOrders", new object[0]);
            return ((xlTradeOrder[])(results[0]));
        }
        
        /// <remarks/>
        public void getAllOrdersAsync() {
            this.getAllOrdersAsync(null);
        }
        
        /// <remarks/>
        public void getAllOrdersAsync(object userState) {
            if ((this.getAllOrdersOperationCompleted == null)) {
                this.getAllOrdersOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetAllOrdersOperationCompleted);
            }
            this.InvokeAsync("getAllOrders", new object[0], this.getAllOrdersOperationCompleted, userState);
        }
        
        private void OngetAllOrdersOperationCompleted(object arg) {
            if ((this.getAllOrdersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getAllOrdersCompleted(this, new getAllOrdersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/clearLists", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void clearLists() {
            this.Invoke("clearLists", new object[0]);
        }
        
        /// <remarks/>
        public void clearListsAsync() {
            this.clearListsAsync(null);
        }
        
        /// <remarks/>
        public void clearListsAsync(object userState) {
            if ((this.clearListsOperationCompleted == null)) {
                this.clearListsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnclearListsOperationCompleted);
            }
            this.InvokeAsync("clearLists", new object[0], this.clearListsOperationCompleted, userState);
        }
        
        private void OnclearListsOperationCompleted(object arg) {
            if ((this.clearListsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.clearListsCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendCommand", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SendCommand(Command Command) {
            this.Invoke("SendCommand", new object[] {
                        Command});
        }
        
        /// <remarks/>
        public void SendCommandAsync(Command Command) {
            this.SendCommandAsync(Command, null);
        }
        
        /// <remarks/>
        public void SendCommandAsync(Command Command, object userState) {
            if ((this.SendCommandOperationCompleted == null)) {
                this.SendCommandOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendCommandOperationCompleted);
            }
            this.InvokeAsync("SendCommand", new object[] {
                        Command}, this.SendCommandOperationCompleted, userState);
        }
        
        private void OnSendCommandOperationCompleted(object arg) {
            if ((this.SendCommandCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendCommandCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetCommand", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Command GetCommand() {
            object[] results = this.Invoke("GetCommand", new object[0]);
            return ((Command)(results[0]));
        }
        
        /// <remarks/>
        public void GetCommandAsync() {
            this.GetCommandAsync(null);
        }
        
        /// <remarks/>
        public void GetCommandAsync(object userState) {
            if ((this.GetCommandOperationCompleted == null)) {
                this.GetCommandOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCommandOperationCompleted);
            }
            this.InvokeAsync("GetCommand", new object[0], this.GetCommandOperationCompleted, userState);
        }
        
        private void OnGetCommandOperationCompleted(object arg) {
            if ((this.GetCommandCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCommandCompleted(this, new GetCommandCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class xlTradeOrder {
        
        private string contractField;
        
        private BuySell bsField;
        
        private double priceField;
        
        private int volumeField;
        
        private orderStatus statusField;
        
        private string principleField;
        
        private string memberField;
        
        private string typeField;
        
        private string exchangeField;
        
        private string dealerField;
        
        private System.DateTime timestampField;
        
        /// <remarks/>
        public string Contract {
            get {
                return this.contractField;
            }
            set {
                this.contractField = value;
            }
        }
        
        /// <remarks/>
        public BuySell BS {
            get {
                return this.bsField;
            }
            set {
                this.bsField = value;
            }
        }
        
        /// <remarks/>
        public double Price {
            get {
                return this.priceField;
            }
            set {
                this.priceField = value;
            }
        }
        
        /// <remarks/>
        public int Volume {
            get {
                return this.volumeField;
            }
            set {
                this.volumeField = value;
            }
        }
        
        /// <remarks/>
        public orderStatus Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public string Principle {
            get {
                return this.principleField;
            }
            set {
                this.principleField = value;
            }
        }
        
        /// <remarks/>
        public string Member {
            get {
                return this.memberField;
            }
            set {
                this.memberField = value;
            }
        }
        
        /// <remarks/>
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        public string Exchange {
            get {
                return this.exchangeField;
            }
            set {
                this.exchangeField = value;
            }
        }
        
        /// <remarks/>
        public string Dealer {
            get {
                return this.dealerField;
            }
            set {
                this.dealerField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime Timestamp {
            get {
                return this.timestampField;
            }
            set {
                this.timestampField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum BuySell {
        
        /// <remarks/>
        Buy,
        
        /// <remarks/>
        Sell,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum orderStatus {
        
        /// <remarks/>
        Ready,
        
        /// <remarks/>
        Completed,
        
        /// <remarks/>
        Cancelled,
        
        /// <remarks/>
        Active,
        
        /// <remarks/>
        None,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Boodskap {
        
        private System.DateTime timeStampField;
        
        private Messages messageField;
        
        private string message_CustomField;
        
        /// <remarks/>
        public System.DateTime TimeStamp {
            get {
                return this.timeStampField;
            }
            set {
                this.timeStampField = value;
            }
        }
        
        /// <remarks/>
        public Messages Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        public string Message_Custom {
            get {
                return this.message_CustomField;
            }
            set {
                this.message_CustomField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum Messages {
        
        /// <remarks/>
        isAlive,
        
        /// <remarks/>
        isDead,
        
        /// <remarks/>
        Startup,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum Command {
        
        /// <remarks/>
        RestartPC,
        
        /// <remarks/>
        Idle,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void InsertNewOrderCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void InsertMessageCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getLastMessageCompletedEventHandler(object sender, getLastMessageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getLastMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getLastMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Boodskap Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Boodskap)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetAllMessagesCompletedEventHandler(object sender, GetAllMessagesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllMessagesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllMessagesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Boodskap[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Boodskap[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getLastOrderCompletedEventHandler(object sender, getLastOrderCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getLastOrderCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getLastOrderCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public xlTradeOrder Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((xlTradeOrder)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getAllOrdersCompletedEventHandler(object sender, getAllOrdersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getAllOrdersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getAllOrdersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public xlTradeOrder[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((xlTradeOrder[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void clearListsCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SendCommandCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetCommandCompletedEventHandler(object sender, GetCommandCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCommandCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCommandCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Command Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Command)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
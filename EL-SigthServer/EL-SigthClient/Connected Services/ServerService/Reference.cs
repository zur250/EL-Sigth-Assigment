﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EL_SigthClient.ServerService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServerService.IServer", CallbackContract=typeof(EL_SigthClient.ServerService.IServerCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/Login", ReplyAction="http://tempuri.org/IServer/LoginResponse")]
        bool Login(string i_UserName, string i_password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/Login", ReplyAction="http://tempuri.org/IServer/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(string i_UserName, string i_password);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/StartStream")]
        void StartStream();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/StartStream")]
        System.Threading.Tasks.Task StartStreamAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/StopStream")]
        void StopStream();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/StopStream")]
        System.Threading.Tasks.Task StopStreamAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/GetRandomNumber")]
        void GetRandomNumber(int i_Number);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/GetRandomStream")]
        void GetRandomStream(byte[] i_RandomData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerChannel : EL_SigthClient.ServerService.IServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServerClient : System.ServiceModel.DuplexClientBase<EL_SigthClient.ServerService.IServer>, EL_SigthClient.ServerService.IServer {
        
        public ServerClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServerClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool Login(string i_UserName, string i_password) {
            return base.Channel.Login(i_UserName, i_password);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(string i_UserName, string i_password) {
            return base.Channel.LoginAsync(i_UserName, i_password);
        }
        
        public void StartStream() {
            base.Channel.StartStream();
        }
        
        public System.Threading.Tasks.Task StartStreamAsync() {
            return base.Channel.StartStreamAsync();
        }
        
        public void StopStream() {
            base.Channel.StopStream();
        }
        
        public System.Threading.Tasks.Task StopStreamAsync() {
            return base.Channel.StopStreamAsync();
        }
    }
}

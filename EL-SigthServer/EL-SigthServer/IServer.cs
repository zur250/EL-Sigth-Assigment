using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace EL_SigthServer
{
    
    [ServiceContract(SessionMode = SessionMode.Required,CallbackContract = typeof(IPubSubContract))]
    //[ServiceContract]
    public interface IServer
    {
        [OperationContract(IsOneWay = false)]
        //[WebInvoke(Method ="GET",ResponseFormat =WebMessageFormat.Json,UriTemplate ="login/{id}/{password}")]
        bool Login(string i_UserName, string i_password);
        [OperationContract(IsOneWay = true)]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "start")]
        void StartStream();
        [OperationContract(IsOneWay = true)]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "stop")]
        void StopStream();
    }
}

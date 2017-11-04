using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EL_SigthServer
{
    public interface IPubSubContract
    {
        [OperationContract(IsOneWay = true)]
        void GetRandomNumber(int i_Number);
        [OperationContract(IsOneWay = true)]
        void GetRandomStream(byte[] i_RandomData);
    }
}

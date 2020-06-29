using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using model;

namespace servC
{
    [ServiceContract(Namespace = "http:middleware")]
    public interface I_Server
    {
        [OperationContract]
        model.MsgStruct server(model.MsgStruct message);
    }
    
}

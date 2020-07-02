using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using System.ServiceModel;

namespace authentificationWorkflow
{
    //[ServiceContract(Namespace = "http:middleware")]

    public interface I_Authentification
    {
        //[OperationContract]
        model.MsgStruct validateAuthentification(model.MsgStruct message);
    }
}

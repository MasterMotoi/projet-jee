using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace workflowController
{
    [ServiceContract(Namespace = "http:middleware")]

    public interface I_WorkflowController
    {
        [OperationContract]
        model.MsgStruct workflowControl(model.MsgStruct message);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace decryptionWorkflow
{
    [ServiceContract(Namespace = "http:middleware")]
    public interface IDecryption
    {
        [OperationContract]
        model.MsgStruct decrypt(model.MsgStruct message);
    }
}

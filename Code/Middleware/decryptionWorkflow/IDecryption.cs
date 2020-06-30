using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using model;

namespace decryptionWorkflow
{
    [ServiceContract(Namespace = "http:middleware")]
    public interface IDecryption
    {
        [OperationContract]
        model.MsgStruct decrypt(model.MsgStruct message);

        
        [OperationContract]
        void callDecryptFile(model.File file, decryptionBusiness.DecryptFile decryptBizz);
    }
}

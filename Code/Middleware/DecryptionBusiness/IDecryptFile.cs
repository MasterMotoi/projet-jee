using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using System.ServiceModel;


namespace decryptionBusiness
{
    [ServiceContract(Namespace = "http:middleware")]
    public interface IDecryptFile
    {
        [OperationContract]
        //SampleFile ()
        model.File decryptFile(model.File file, string key);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using System.ServiceModel;


namespace decryptionBusiness
{
    //[ServiceContract(Namespace = "http:middleware")]
    public interface IDecryptFile
    {
        void SetFileAndKey(model.File file);

        void decryptFilewithKey(model.File file, string key);

        //[OperationContract]
        void decryptFile(model.File file);

    }
}

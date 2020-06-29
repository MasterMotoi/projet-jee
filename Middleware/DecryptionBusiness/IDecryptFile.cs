using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace decryptionBusiness
{
    public interface IDecryptFile
    {
        //SampleFile ()
        model.File decryptFile(model.File file, string key);

    }
}

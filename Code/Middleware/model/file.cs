using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace model
{
    [DataContract]
    public class File
    {
        [DataMember]
        public string name;
        
        [DataMember]
        public string data;

        [DataMember]
        public string fileType;
    }
}

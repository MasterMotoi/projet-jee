using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using dataPersistence;

namespace sqlAccess
{
    //[ServiceContract(Namespace = "http:middleware")]
    public interface ISqlAccess
    {
        //[OperationContract]
        void sqlConnect();

        //[OperationContract]
        User[] getAllUser();

        //[OperationContract]
        User[] getUserByParameterValue(string parameter, string value);

        //[OperationContract]
        User[] getUserBy2ParametersValue(string parameter, string value, string parameter2, string value2);
    }
}

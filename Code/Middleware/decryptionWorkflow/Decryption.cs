using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decryptionWorkflow
{
    public class Decryption
    {
        model.MsgStruct decrypt(model.MsgStruct message)
        {
            model.MsgStruct returnMsg = new model.MsgStruct();
            //EndpointAddress epSql = new EndpointAddress("http://localhost:8010/Server/services/sql_access");

            //verif tokens

            returnMsg.statutOp = false;
            returnMsg.info = "successful decryption";
            //msg.tokenUser = tokenUser;
            returnMsg.operationName = "decrypt_return";
            returnMsg.tokenApp = "MiddlewareToken";
            returnMsg.tokenUser = "'Z|1li:GZ3VW<^3";
            returnMsg.appVersion = "1.0";
            returnMsg.operationVersion = "1.0";
            returnMsg.data = new object[] { (object)true, (object)"",(object)"",(object)"" };

            return returnMsg;
        }
    }
}

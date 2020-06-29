using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using authentificationWorkflow;
using model;
using System.ServiceModel;

namespace workflowController
{
    public class WorkflowController : I_WorkflowController
    {

        public model.MsgStruct workflowControl (model.MsgStruct message)
        {
            EndpointAddress epAuth = new EndpointAddress("http://localhost:8010/Server/services/auth");
            model.MsgStruct returnMsg = new model.MsgStruct();

            //Analyse la version de l'app et appelle le controlleur de workflow adéquate en fontion de l'opération

            string operationName = message.operationName;
            string appVersion = message.appVersion;

            //analyse opp_name
            switch (operationName)
            {
                case "auth":
                    //analyse app_version
                    switch (appVersion)
                    {
                        case "1.0": //Appelle du controlleur de workflow d'authentification
                            //*** RAJOUTER TRY CATCH***
                            authentificationWorkflow.I_Authentification authentificationWorkflow = ChannelFactory<authentificationWorkflow.I_Authentification>.CreateChannel(new BasicHttpBinding(), epAuth);
                            Console.WriteLine("calling Auth CW");
                            returnMsg = authentificationWorkflow.validateAuthentification(message);
                            Console.WriteLine("Auth CW call finished");                            
                            break;
                        default: //retourne message indiquant que le type d'appversion est inconnu
                            returnMsg.statutOp = false;
                            returnMsg.info = "unsuccessful authentification - unknow appVersion";
                            //msg.tokenUser = tokenUser;
                            returnMsg.operationName = "auth_return";
                            returnMsg.tokenApp = "MiddlewareToken";
                            //returnMsg.tokenUser = "";
                            returnMsg.appVersion = "1.0";
                            returnMsg.operationVersion = "1.0";
                            returnMsg.data = new object[2] { (object)false, (object)"unknow appVersion" };                             
                            break;
                    }             
                    break;

                default:
                    //retourne mesage comme quoi le type d'operation est inconnu
                    returnMsg.statutOp = false;
                    returnMsg.info = "unsuccessful authentification - unknow operationName";
                    //msg.tokenUser = tokenUser;
                    returnMsg.operationName = "unknown_return";
                    returnMsg.tokenApp = "MiddlewareToken";
                    //returnMsg.tokenUser = "";
                    returnMsg.appVersion = "1.0";
                    returnMsg.operationVersion = "1.0";
                    returnMsg.data = new object[2] { (object)false, (object)"unknow operationName" };
                    break;
            }

            return returnMsg;

        }


    }
}

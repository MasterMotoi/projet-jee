using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using model;
using workflowController;

namespace servC
{
    class Server : I_Server
    {

        public model.MsgStruct server (model.MsgStruct message)
        {
            EndpointAddress epCAM = new EndpointAddress("http://localhost:8010/Server/services/workflow_controller");
            model.MsgStruct returnMsg = new model.MsgStruct();

            string operationName = message.operationName;
            string tokenApp = message.tokenApp;

            //verif tokenApp            
            if (tokenApp == "?h:XPjO9b)z3Ox7")
            {                
                try
                {
                    workflowController.I_WorkflowController proxyWorkflowController = ChannelFactory<workflowController.I_WorkflowController>.CreateChannel(new BasicHttpBinding(), epCAM);
                    Console.WriteLine("calling CAM");
                    returnMsg = proxyWorkflowController.workflowControl(message);
                    Console.WriteLine("CAM call finished");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //return message error CAM
                    returnMsg.statutOp = false;
                    returnMsg.info = "unsuccessful authentification - CAM access error";
                    //msg.tokenUser = tokenUser;
                    returnMsg.operationName = "return";
                    returnMsg.tokenApp = "MiddlewareToken";
                    //returnMsg.tokenUser = "";
                    returnMsg.appVersion = "1.0";
                    returnMsg.operationVersion = "1.0";
                    returnMsg.data = new object[2] { (object)false, (object)"CAM access error" };
                }
            }
            else
            {
                //on renvoit un message informant le client que son token app n'est ps valide

                returnMsg.statutOp = false;
                returnMsg.info = "unsuccessful authentification - unknow tokenApp";
                //msg.tokenUser = tokenUser;
                returnMsg.operationName = "return";
                returnMsg.tokenApp = "MiddlewareToken";
                //returnMsg.tokenUser = "";
                returnMsg.appVersion = "1.0";
                returnMsg.operationVersion = "1.0";
                returnMsg.data = new object[2] { (object)false, (object)"unknow appVersion" };
            }

            return returnMsg;

        }
    }
}

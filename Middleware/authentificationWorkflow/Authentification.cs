using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using model;
using System.Threading.Tasks;

namespace authentificationWorkflow
{

    public class Authentification : I_Authentification
    {
        /*
        private string login;
        private string password;*/

        /*
        public Authentification()
        {
            this.login = login;
            this.password = password;
        }*/

        public model.MsgStruct validateAuthentification(model.MsgStruct message)
        {
            model.MsgStruct returnMsg = new model.MsgStruct();
            string tokenUser="";
           
            //check password & login en BDD

            //recuperer tokenUser

            tokenUser = "blabla";



            returnMsg.statutOp = true;
            returnMsg.info = "successful authentification";
            //msg.tokenUser = tokenUser;
            returnMsg.operationName = "auth_return";
            returnMsg.tokenApp = "MiddlewareToken";
            returnMsg.tokenUser = tokenUser;
            returnMsg.appVersion = "1.0";
            returnMsg.operationVersion = "1.0";
            returnMsg.data = new object[2] { (object)true, (object)tokenUser };

            //renvoie au CAM
            return returnMsg;

        }



    }
}

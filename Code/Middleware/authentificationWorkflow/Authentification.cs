using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using model;
using System.Threading.Tasks;
using sqlAccess;
using dataPersistence;
using System.ServiceModel;

namespace authentificationWorkflow
{

    public class Authentification : I_Authentification
    {
        SqlAccess sqlAccess = new SqlAccess();
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
            EndpointAddress epSql = new EndpointAddress("http://localhost:8010/Server/services/sql_access");

            User[] users;
            string tokenUser="";
            string login = message.data[0].ToString();
            string password = message.data[1].ToString();

            //check password & login en BDD
            //sqlAccess.sqlConnect();
            try
            {
                sqlAccess.ISqlAccess proxySql= ChannelFactory<sqlAccess.ISqlAccess>.CreateChannel(new BasicHttpBinding(), epSql);
                Console.WriteLine("calling CAM");
                users = proxySql.getUserBy2ParametersValue("login", login, "password", password);
                Console.WriteLine("CAM call finished");

                if (users.Length > 0)
                {
                    Console.WriteLine("authentification cool");
                    //generation tokenUser
                    tokenUser = "'Z|1li:GZ3VW<^3";

                    returnMsg.statutOp = false;
                    returnMsg.info = "successful authentification";
                    //msg.tokenUser = tokenUser;
                    returnMsg.operationName = "auth_return";
                    returnMsg.tokenApp = "MiddlewareToken";
                    returnMsg.tokenUser = tokenUser;
                    returnMsg.appVersion = "1.0";
                    returnMsg.operationVersion = "1.0";
                    returnMsg.data = new object[2] { (object)true, (object)tokenUser };
                }
                else // wrong login / password
                {
                    Console.WriteLine("login ou mdp non trouvze");
                    returnMsg.statutOp = false;
                    returnMsg.info = "unsuccessful authentification - wrong login and or problem";
                    //msg.tokenUser = tokenUser;
                    returnMsg.operationName = "auth_return";
                    returnMsg.tokenApp = "MiddlewareToken";
                    //returnMsg.tokenUser = "";
                    returnMsg.appVersion = "1.0";
                    returnMsg.operationVersion = "1.0";
                    returnMsg.data = new object[2] { (object)false, (object)"" };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return message SQM ACASSE
                returnMsg.statutOp = false;
                returnMsg.info = "unsuccessful authentification - Database service access error";
                //msg.tokenUser = tokenUser;
                returnMsg.operationName = "return";
                returnMsg.tokenApp = "MiddlewareToken";
                //returnMsg.tokenUser = "";
                returnMsg.appVersion = "1.0";
                returnMsg.operationVersion = "1.0";
                returnMsg.data = new object[2] { (object)false, (object)"Database access error" };
            }




            //renvoie au CAM
            return returnMsg;

        }



    }
}

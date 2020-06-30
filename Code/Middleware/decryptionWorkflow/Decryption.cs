using decryptionBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace decryptionWorkflow
{
    public class Decryption : IDecryption
    {
        public model.MsgStruct decrypt(model.MsgStruct message)
        {
            model.MsgStruct returnMsg = new model.MsgStruct();
            EndpointAddress epDecrypt = new EndpointAddress("http://localhost:8010/Server/services/decrypt_file");
            List<model.File> files = new List<model.File>();

            //verif tokens
            string tokenApp = message.tokenApp;
            string tokenUser = message.tokenUser;
            int fileNumber = message.data.Length - 2;
            

            for(int i =2;i< message.data.Length;i++)
            {
                model.File tempFile = new model.File();

                string[] splitedFile = ((string)message.data[i]).Split(new char[] { '|' }, 2);

                tempFile.name = splitedFile[0];
                tempFile.data = splitedFile[1];
                files.Add(tempFile);
            }

            //thread
            decryptionBusiness.IDecryptFile decryptionBusiness= ChannelFactory<decryptionBusiness.IDecryptFile>.CreateChannel(new BasicHttpBinding(), epDecrypt);

            foreach(model.File file in files.ToArray() )
            {
                //decryptionWorkflow.
                //DecryptFile decrypt = new DecryptFile();
                //decrypt.SetFileAndKey(file, "cesi");
                //decrypt.decryptFile();

                //decryptionBusiness.SetFileAndKey(file, "cesi");
                decryptionBusiness.decryptFile(file, "CESI");
                //Thread InstanceCaller = new Thread(new ThreadStart(decryptionBusiness.decryptFile));
            }



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

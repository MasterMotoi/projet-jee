using decryptionBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using model;
using System.ServiceModel;

namespace decryptionWorkflow
{
    public class Decryption : IDecryption
    {
        public model.MsgStruct decrypt(model.MsgStruct message)
        {
            model.MsgStruct returnMsg = new model.MsgStruct();
            //EndpointAddress epDecrypt = new EndpointAddress("http://localhost:8010/Server/services/decrypt_file");
            List<model.File> files = new List<model.File>();

            decryptionBusiness.DecryptFile decryptbizz = new decryptionBusiness.DecryptFile();

            
            string tokenApp = message.tokenApp;
            string tokenUser = message.tokenUser;
            int fileNumber = message.data.Length - 2;
            
            if (tokenUser != "'Z|1li:GZ3VW<^3")
            {
                returnMsg.statutOp = false;
                returnMsg.info = "invalid tokenUser";
                returnMsg.operationName = "decrypt_return";
                returnMsg.tokenApp = "?h:XPjO9b)z3Ox7";
                returnMsg.tokenUser = "'Z|1li:GZ3VW<^3";
                returnMsg.appVersion = "1.0";
                returnMsg.operationVersion = "1.0";
                return returnMsg;
            }

            for(int i =2;i< message.data.Length;i++)
            {
                model.File tempFile = new model.File();

                string[] splitedFile = ((string)message.data[i]).Split(new char[] { '|' }, 2);

                tempFile.name = splitedFile[0];
                tempFile.data = splitedFile[1];
                files.Add(tempFile);
            }

            //thread
            //decryptionBusiness.IDecryptFile decryptionBusiness= ChannelFactory<decryptionBusiness.IDecryptFile>.CreateChannel(new BasicHttpBinding(), epDecrypt);
            //decryptionBusiness.DecryptFile decryptionBusiness = new DecryptFile();

            foreach (model.File file in files.ToArray() )
            {
                //decryptionWorkflow.
                //DecryptFile decrypt = new DecryptFile();
                //decrypt.SetFileAndKey(file, "cesi");
                //decrypt.decryptFile(file);
                DecryptFile businessDecrypter = new DecryptFile();
                businessDecrypter.SetFileAndKey(file);
                Thread InstanceCaller = new Thread(new ThreadStart(businessDecrypter.decryptThread));
                InstanceCaller.Start();

                //Task.Run(() => callDecryptFile(file, decryptbizz));

                //decryptionBusiness.SetFileAndKey(file, "cesi");
                //decryptionBusiness.decryptFile(file, "CESI");
                //Thread InstanceCaller = new Thread(new ThreadStart(decryptionBusiness.decryptFile));
            }


            
            returnMsg.statutOp = false;
            returnMsg.info = "successful decryption";
            returnMsg.operationName = "decrypt_return";
            returnMsg.tokenApp = "MiddlewareToken";
            returnMsg.tokenUser = "'Z|1li:GZ3VW<^3";
            returnMsg.appVersion = "1.0";
            returnMsg.operationVersion = "1.0";
            returnMsg.data = new object[] { (object)true, (object)"",(object)"",(object)"" };

            return returnMsg;
            //return null;
        }

        public async void callDecryptFile(model.File file, decryptionBusiness.DecryptFile decryptBizz)
        {
            decryptBizz.decryptFile(file);
        }
    }
}

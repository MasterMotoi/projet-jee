using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using model;

namespace decryptionBusiness
{
    public class DecryptFile : IDecryptFile
    {
        private model.File file;
        string key;
        
        public void SetFileAndKey(model.File file, string key)
        {
            this.file = file;
            this.key = key;
        }

        public void decryptThread()
        {
            Console.WriteLine("On entre un thread");
            Console.WriteLine(file.data);
            //Thread.Sleep(5000);
            Console.WriteLine(key);
            model.File decryptedFile = new model.File();
            int i = 0;
            int fileSize = file.data.Length;
            string scaledKey = "";
            int modulo = 0;
            int tempChar = 0;

            //On adapte la clé

            modulo = file.data.Length % key.Length;
            for (i = 0; i < file.data.Length / key.Length; i++)
            {
                scaledKey += key;
            }
            for (i = 0; i < file.data.Length % key.Length; i++)
            {
                scaledKey += key[i];
            }

            //on parcours char par char le fichier et on applique la clé xor

            for (i = 0; i < fileSize; i++)
            {
                tempChar = Convert.ToInt32(file.data[i]) ^ Convert.ToInt32(scaledKey[i]);
                decryptedFile.data += (char)tempChar;
            }
            Console.WriteLine(decryptedFile.data);

            //envoie fichier au JMS
            //return decryptedFile;
        }

        public void decryptFile(model.File file, string key)
        {
            DecryptFile businessDecrypter = new DecryptFile();
            businessDecrypter.SetFileAndKey(file, key);
            Thread InstanceCaller = new Thread(new ThreadStart(businessDecrypter.decryptThread));
            InstanceCaller.Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DecryptionBusiness;
using model;

namespace decryptionBusiness
{
    public class DecryptFile : IDecryptFile
    {
        private model.File file;

        public void SetFileAndKey(model.File file)
        {
            this.file = file;
        }

        public void decryptThread()
        {
            Console.WriteLine("Thread Decrypt");
            string key = "";

            int char1 = 65;
            int char2 = 65;
            int char3 = 65;
            int char4 = 65;

            while (char1 <= 90)
            {
                key = $"{Convert.ToChar(char1)}{Convert.ToChar(char2)}{Convert.ToChar(char3)}{Convert.ToChar(char4)}";
                decryptFilewithKey(file, key);
                char4++;
                if (char4 > 90)
                {
                    char4 = 65;
                    char3++;
                }
                if (char3 > 90)
                {
                    char3 = 65;
                    char2++;
                }
                if (char2 > 90)
                {
                    char2 = 65;
                    char1++;
                }
            }

        }

        public void decryptFilewithKey (model.File file, string key)
        {

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
            Console.WriteLine("Fichier :");
            Console.WriteLine(file.name);
            Console.WriteLine("Cle :");
            Console.WriteLine(key);
            Console.WriteLine("Decryption :");
            Trace.WriteLine(decryptedFile.data);
            Trace.WriteLine("Fichier :");
            Trace.WriteLine(file.name);
            Trace.WriteLine("Cle :");
            Trace.WriteLine(key);
            Trace.WriteLine("Decryption :");
            Trace.WriteLine(decryptedFile.data);
            Trace.WriteLine(""); 
            Trace.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Trace.WriteLine("");

            clientSoap.CallWebService(key, file.name, decryptedFile.data);
            
        }

        public void decryptFile(model.File file)
        {
            DecryptFile businessDecrypter = new DecryptFile();
            businessDecrypter.SetFileAndKey(file);
            Thread InstanceCaller = new Thread(new ThreadStart(businessDecrypter.decryptThread));
            InstanceCaller.Start();
        }
    }
}

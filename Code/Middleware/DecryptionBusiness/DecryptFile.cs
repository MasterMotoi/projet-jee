using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace decryptionBusiness
{
    public class DecryptFile : IDecryptFile
    {
        public model.File decryptFile(model.File file, string key)
        {
            model.File decryptedFile = new model.File();
            int i = 0;
            int fileSize = file.data.Length;
            string scaledKey="";
            int modulo=0;
            byte tempChar = 0;

            //On adapte la clé
            modulo = file.data.Length % key.Length;
            for(i=0;i< file.data.Length / key.Length;i++)
            {
                scaledKey += key;
            }
            for(i=0;i< file.data.Length % key.Length;i++)
            {
                scaledKey += key[i];
            }

            //on parcours char par char le fichier et on applique la clé xor

            for (i=0;i<fileSize;i++)
            {
                //tempChar = Convert.ToByte(file.data[i]) ^ Convert.ToByte(file.data[i]);
                //decryptedFile.data +=
            }

            
            return decryptedFile;
        }
    }
}

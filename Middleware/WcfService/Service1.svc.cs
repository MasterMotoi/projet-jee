using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using model;

namespace WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public void Server (model.MsgStruct message)
        {
            string operationName = message.operationName;
            string tokeApp = message.tokenApp;
            //check si token_app valide (retour message sinon)

            //on envoie au groupe de service adequate
            switch(operationName)
            {
                case "authentification":

                    break;
                default:
                    break;
            }



        }

        public string CheckLogin(string login, string pwd)
        {

            System.Threading.Thread.Sleep(10000);
            switch(login)
            {
                case "fplastina":
                    {
                        return $"Bienvenue Fabien, votre password est : {pwd}";
                    }

                case "tbrunetti":
                    {
                        return $"Bienvenue Tom, votre password est : {pwd}";
                    }

                case "agremillet":
                    {
                        return $"Bienvenue Antoine, votre password est : {pwd}";
                    }

                default:
                    {
                        return $"Login inconnu, peut être vous êtes vous trompé ? Votre password est : {pwd}";
                    }
            }

            
        }

        public string GetData(int value)
        {
            return $"login envoyé : {value}";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {

        public string CheckLogin(string login)
        {
            switch(login)
            {
                case "fplastina":
                    {
                        return "Bienvenue Fabien";
                    }

                case "tbrunetti":
                    {
                        return "Bienvenue Tom";
                    }

                case "agremillet":
                    {
                        return "Bienvenue Antoine";
                    }

                default:
                    {
                        return "Login inconnu, peut être vous êtes vous trompé ?";
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

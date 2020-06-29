using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using model;

namespace servC
{
    class Program
    {
        public model.MsgStruct msg = new model.MsgStruct();

        static void Main(string[] args)
        {
            //ServiceHost authentificationServiceHost = new ServiceHost(typeof(authentifcationService.authentifcationService));
            ServiceHost authentificationWorkflowHost = new ServiceHost(typeof(authentificationWorkflow.Authentification));
            ServiceHost workflowControllerHost = new ServiceHost(typeof(workflowController.WorkflowController));
            ServiceHost sqlAccessHost = new ServiceHost(typeof(sqlAccess.SqlAccess));
            ServiceHost decryptionWorkflowHost = new ServiceHost(typeof(decryptionWorkflow.Decryption));
            ServiceHost serverHost = new ServiceHost(typeof(servC.Server));
            

            try
            {
                authentificationWorkflowHost.Open();
                workflowControllerHost.Open();
                sqlAccessHost.Open();
                decryptionWorkflowHost.Open();
                serverHost.Open();
                Console.WriteLine("The service is ready.");

                // Close the ServiceHost to stop the service.
                //Console.WriteLine("Press <Enter> to terminate the service.");
                //Console.WriteLine();
                //Console.ReadLine();
                //authentificationWorkflowHost.Close();
                //workflowControllerHost.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //rajouter les close dans un "finally"

            Console.Read();

        }
    }
}

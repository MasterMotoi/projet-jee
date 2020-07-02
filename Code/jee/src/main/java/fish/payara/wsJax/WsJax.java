/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package fish.payara.wsJax;

import fish.payara.jee.Recept;
import java.io.Serializable;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.ejb.Stateless;

import javax.jms.Connection;
import javax.jms.ConnectionFactory;
import javax.jms.Destination;
import javax.jms.JMSException;
import javax.jms.MessageProducer;
import javax.jms.ObjectMessage;
import javax.jms.Session;
import javax.jms.TextMessage;
import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;

/**
 *
 * @author tombr
 */
@WebService(serviceName = "WsJax")
@Stateless()
public class WsJax {

    /**
     * This is a sample web service operation
     * @param fileName
     * @param fileContent
     * @param currentKey
     */
    @WebMethod(operationName = "sendCurrentFile")
    public String sendCurrentFile(
            @WebParam(name = "fileName") String fileName,
            @WebParam(name = "fileContent") String fileContent,
            @WebParam(name = "currentKey") String currentKey
    ) {
        
        System.out.println("message reçu");
        System.out.println(fileName);
        System.out.println(fileContent);
        System.out.println(currentKey);
        Recept recept = new Recept(fileName, fileContent, currentKey);
        System.out.println("message reçu");
        sendJMSMessage (recept);
        return "message recu";
        //
        }
        
                // function sendToJMS (implémenter dans le producer du message jms
    
    
    public void sendJMSMessage (Recept file)
    {
        Context context = null;
        System.out.println();
        ConnectionFactory factory = null;
        Connection connection = null;
        Destination destination = null;
        Session session = null;
        MessageProducer sender = null;
        try
        {
            context = new InitialContext();
            factory = (ConnectionFactory) context.lookup("jms/message");
            destination = (Destination) context.lookup("jms/messageDest");
            connection = factory.createConnection();
            session = connection.createSession(false, Session.AUTO_ACKNOWLEDGE);
            sender = session.createProducer(destination);
            ObjectMessage objectMessage = session.createObjectMessage();
            objectMessage.setObject(file);
            connection.start();
            //final TextMessage msg = session.createTextMessage();           
            //msg.setText(message);
            //sender.send(msg);
            sender.send(objectMessage);
            System.out.println("Envoie JMS : fichier= " + file.getFileName()+" Clef = "+file.getCurrentKey());       
                    
        }
        catch(JMSException | NamingException e)
        {
            System.out.println(e);
        }
       
    }
    
}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package fish.payara.jms;

import fish.payara.jee.Recept;
import fish.payara.jee.receptValidator;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.ActivationConfigProperty;
import javax.ejb.MessageDriven;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.MessageListener;
import javax.jms.ObjectMessage;
import javax.jms.TextMessage;

/**
 *
 * @author antoi
 */
@MessageDriven(activationConfig = {
    @ActivationConfigProperty(propertyName = "destinationLookup", propertyValue = "jms/messageDest")
    ,
        @ActivationConfigProperty(propertyName = "destinationType", propertyValue = "javax.jms.Topic")
})

public class listener implements MessageListener {
    
    public listener() {
    }
    
    @Override
    public void onMessage(Message message) {
        Recept receivedFile = null;
        //yo
        try{
            System.out.println("Bonjour ici OnMessage");
            if(message instanceof Recept){
                ObjectMessage  myMessage = (ObjectMessage ) message;
                 System.err.println("Object Message Cast working");
                 receivedFile = (Recept) myMessage.getObject();
                 System.err.println("Recept cast working");
                 System.err.println("Envoie JMS : fichier= " + receivedFile.getFileName()+" Clef = "+receivedFile.getCurrentKey());     
                 receptValidator receptValidate = new receptValidator();
                 receptValidate.validator(receivedFile);
            }

            /*
            TextMessage msg = (TextMessage)message;
            String messaage = msg.getText();
            System.out.println("Bonjour ici OnMessage");
            System.out.println(msg.getText());*/
        }
        catch(JMSException ex){
            Logger.getLogger(listener.class.getName()).log(Level.SEVERE, null, ex);
            
        }
        
    }
    
    /*
    public void receiveObjectMessage() {
        Properties initialProperties = new Properties();
        initialProperties.put(InitialContext.INITIAL_CONTEXT_FACTORY,"org.exolab.jms.jndi.InitialContextFactory");
        initialProperties.put(InitialContext.PROVIDER_URL,"tcp://localhost:3035");
        try {
            context = new InitialContext(initialProperties);
            factory = (QueueConnectionFactory) context.lookup("ConnectionFactory");
            destination = (Queue) context.lookup("queue1");
            connection = factory.createConnection();
            session = connection.createSession(false, Session.AUTO_ACKNOWLEDGE);
            consumer = session.createConsumer(destination);
            connection.start();
            Message message = consumer.receive();
            if (message instanceof ObjectMessage) {
                Object object = ((ObjectMessage) message).getObject();
                System.out.println(this.getClass().getName()
                + "has received a message : " + (EventMessage) object);
            }
        }
        catch (NamingException e) {
                e.printStackTrace();
        }
        catch (JMSException e) {
                e.printStackTrace();
        }
        if (context != null) {
            try {
                context.close();
            }
            catch (NamingException ex) {
                ex.printStackTrace();
            }
        }

        if (connection != null) {
            try {
            connection.close();
            } 
            catch (JMSException ex) {
            ex.printStackTrace();
        }
    }

}*/
    
    
}
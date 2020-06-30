/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package fish.payara.wsJax;

import fish.payara.jee.Recept;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.ejb.Stateless;

/**
 *
 * @author tombr
 */
@WebService(serviceName = "WsJax")
@Stateless()
public class WsJax {

    /**
     * This is a sample web service operation
     */
    @WebMethod(operationName = "sendCurrentFile")
    public void sendCurrentFile(
            @WebParam(name = "fileName") String fileName,
            @WebParam(name = "fileContent") String fileContent,
            @WebParam(name = "currentKey") String currentKey
    ) {
        Recept recept = new Recept(fileName, fileContent, currentKey);
                // function sendToJMS (implémenter dans le producer du message jms
    }
}

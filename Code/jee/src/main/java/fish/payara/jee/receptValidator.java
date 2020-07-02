/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package fish.payara.jee;

import java.util.List;
import javax.inject.Inject;

/**
 *
 * @author tombr
 */
public class receptValidator {
    
    @Inject
    private Mot dao;
    public void validator(Recept recept) {
        System.out.println("prêt à décrypter");
        String[] split = recept.getFileContent().split(" ");
        int motsFrancais = 0;
        for (int i = 0; i < split.length; i++)
        {
            List<Mot> result = dao.findMot(split[i]);
            if (!result.isEmpty())
            {
                motsFrancais ++;
            }
        }
        
        float division = (float)motsFrancais/split.length;
        float tauxConfiance = division * 100;
        System.out.println("Fichier vérifié avec "+ tauxConfiance + "% de taux de confiance, et la clé :" + recept.getCurrentKey() + " dans le fichier : " + recept.getFileName());
        if (tauxConfiance <= 80)
        {
            System.out.println("le message secret est" + recept.getFileContent());
        }
        
    }
}

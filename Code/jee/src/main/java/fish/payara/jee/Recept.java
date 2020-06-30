/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package fish.payara.jee;

/**
 *
 * @author tombr
 */
public class Recept {
    
    private String fileName;
    private String fileContent;
    private String currentKey;

    public Recept(String fileName, String fileContent, String currentKey) {
        this.fileName = fileName;
        this.fileContent = fileContent;
        this.currentKey = currentKey;
    }

    public String getFileName() {
        return fileName;
    }

    public void setFileName(String fileName) {
        this.fileName = fileName;
    }

    public String getFileContent() {
        return fileContent;
    }

    public void setFileContent(String fileContent) {
        this.fileContent = fileContent;
    }

    public String getCurrentKey() {
        return currentKey;
    }

    public void setCurrentKey(String currentKey) {
        this.currentKey = currentKey;
    }
    
    
}

package src.main.java.com.example.factory;

import src.main.java.com.example.components.processor.*;
import src.main.java.com.example.components.gpu.*;
import src.main.java.com.example.components.ram.*;
import src.main.java.com.example.components.storage.*;

public class GamingSetupFactory extends ComponentFactory {
    @Override
    public Processor createProcessor() {
        System.out.println("Creating Gaming Processor...");
        return new GamingProcessor();
    }
    
    @Override
    public GPU createGPU() {
        System.out.println("Creating Gaming GPU...");
        return new GamingGPU();
    }
    
    @Override
    public RAM createRAM() {
        System.out.println("Creating Gaming RAM...");
        return new GamingRAM();
    }
    
    @Override
    public Storage createStorage() {
        System.out.println("Creating Gaming Storage...");
        return new GamingStorage();
    }
}
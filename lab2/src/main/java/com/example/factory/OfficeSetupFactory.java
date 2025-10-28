package src.main.java.com.example.factory;

import src.main.java.com.example.components.processor.*;
import src.main.java.com.example.components.gpu.*;
import src.main.java.com.example.components.ram.*;
import src.main.java.com.example.components.storage.*;

public class OfficeSetupFactory extends ComponentFactory {
    @Override
    public Processor createProcessor() {
        System.out.println("Creating Office Processor...");
        return new OfficeProcessor();
    }
    
    @Override
    public GPU createGPU() {
        System.out.println("Creating Office GPU...");
        return new OfficeGPU();
    }
    
    @Override
    public RAM createRAM() {
        System.out.println("Creating Office RAM...");
        return new OfficeRAM();
    }
    
    @Override
    public Storage createStorage() {
        System.out.println("Creating Office Storage...");
        return new OfficeStorage();
    }
}

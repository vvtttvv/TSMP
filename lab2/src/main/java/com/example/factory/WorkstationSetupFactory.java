package src.main.java.com.example.factory;

import src.main.java.com.example.components.processor.*;
import src.main.java.com.example.components.gpu.*;
import src.main.java.com.example.components.ram.*;
import src.main.java.com.example.components.storage.*;

public class WorkstationSetupFactory extends ComponentFactory {
    @Override
    public Processor createProcessor() {
        System.out.println("Creating Workstation Processor...");
        return new WorkstationProcessor();
    }
    
    @Override
    public GPU createGPU() {
        System.out.println("Creating Workstation GPU...");
        return new WorkstationGPU();
    }
    
    @Override
    public RAM createRAM() {
        System.out.println("Creating Workstation RAM...");
        return new WorkstationRAM();
    }
    
    @Override
    public Storage createStorage() {
        System.out.println("Creating Workstation Storage...");
        return new WorkstationStorage();
    }
}
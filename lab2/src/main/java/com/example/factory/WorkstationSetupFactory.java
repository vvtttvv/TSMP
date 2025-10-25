package com.example.factory;

import com.example.components.processor.*;
import com.example.components.gpu.*;
import com.example.components.ram.*;
import com.example.components.storage.*;

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
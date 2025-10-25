package com.example.factory;

import com.example.components.processor.*;
import com.example.components.gpu.*;
import com.example.components.ram.*;
import com.example.components.storage.*;

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

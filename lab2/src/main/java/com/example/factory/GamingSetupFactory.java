package com.example.factory;

import com.example.components.processor.*;
import com.example.components.gpu.*;
import com.example.components.ram.*;
import com.example.components.storage.*;

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
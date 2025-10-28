package com.example;

import src.main.java.com.example.domain.Computer;
import src.main.java.com.example.factory.*;
import src.main.java.com.example.builder.*;
import src.main.java.com.example.components.processor.GamingProcessor;
import src.main.java.com.example.components.gpu.WorkstationGPU;
import src.main.java.com.example.components.ram.GamingRAM;
import src.main.java.com.example.components.storage.WorkstationStorage;

public class Main {
    public static void main(String[] args) {
        System.out.println("==============================================");
        System.out.println("COMPUTER SETUP CONFIGURATION SYSTEM");
        System.out.println("==============================================");
        
        // Practically here can be getting info about bought PC and based on it creacting a factory, but I'm too lasy to implement it ^^
        ComponentFactory gamingFactory = new GamingSetupFactory();
        ComponentFactory officeFactory = new OfficeSetupFactory();
        ComponentFactory workstationFactory = new WorkstationSetupFactory();
        
        // Build computers using Director + Builder pattern
        ComputerBuilder builder = new ConcreteComputerBuilder();
        ComputerDirector director = new ComputerDirector(builder);
        
        Computer gamingPC = director.constructGamingPC(gamingFactory);
        System.out.println(gamingPC);
        
        Computer officePC = director.constructOfficePC(officeFactory);
        System.out.println(officePC);
        
        Computer workstation = director.constructWorkstation(workstationFactory);
        System.out.println(workstation);
        
        System.out.println("\n=== Custom Build Example ===");
        Computer customPC = builder
            .reset()
            .setName("Custom Mixed Build")
            .setProcessor(new GamingProcessor())
            .setGPU(new WorkstationGPU())
            .setRAM(new GamingRAM())
            .setStorage(new WorkstationStorage())
            .setCoolingSystem("Custom Water Cooling")
            .setCaseType("Custom Mod Case")
            .enableRGBLighting()
            .build();
        
        System.out.println(customPC);

        System.out.println("\n=== Prototype Pattern Demo ===");

        Computer clonedPC = customPC.clone();

        clonedPC.setName("Cloned Custom Build");
        clonedPC.setCoolingSystem("Air Cooling");
        clonedPC.setRGBLighting(false);

        System.out.println("\nOriginal Custom PC:");
        System.out.println(customPC);

        System.out.println("\nCloned PC (Modified Prototype):");
        System.out.println(clonedPC);
    }
}
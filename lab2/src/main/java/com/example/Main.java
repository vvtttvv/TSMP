package com.example;

import com.example.domain.Computer;
import com.example.factory.*;
import com.example.builder.*;
import com.example.components.processor.GamingProcessor;
import com.example.components.gpu.WorkstationGPU;
import com.example.components.ram.GamingRAM;
import com.example.components.storage.WorkstationStorage;

public class Main {
    public static void main(String[] args) {
        System.out.println("==============================================");
        System.out.println("COMPUTER SETUP CONFIGURATION SYSTEM");
        System.out.println("Demonstrating Creational Design Patterns");
        System.out.println("==============================================");
        
        // Create factories (Abstract Factory pattern)
        ComponentFactory gamingFactory = new GamingSetupFactory();
        ComponentFactory officeFactory = new OfficeSetupFactory();
        ComponentFactory workstationFactory = new WorkstationSetupFactory();
        
        // Build computers using Director + Builder pattern
        ComputerDirector director = new ComputerDirector(new ComputerBuilder());
        
        Computer gamingPC = director.constructGamingPC(gamingFactory);
        System.out.println(gamingPC);
        
        director = new ComputerDirector(new ComputerBuilder());
        Computer officePC = director.constructOfficePC(officeFactory);
        System.out.println(officePC);
        
        director = new ComputerDirector(new ComputerBuilder());
        Computer workstation = director.constructWorkstation(workstationFactory);
        System.out.println(workstation);
        
        // Custom build example (manual Builder usage)
        System.out.println("\n=== Custom Build Example ===");
        Computer customPC = new ComputerBuilder()
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
        
        System.out.println("\n==============================================");
        System.out.println("DESIGN PATTERNS DEMONSTRATED:");
        System.out.println("1. Factory Method - Component creation methods");
        System.out.println("2. Abstract Factory - Setup family factories");
        System.out.println("3. Builder - Computer assembly with fluent API");
        System.out.println("==============================================");
    }
}
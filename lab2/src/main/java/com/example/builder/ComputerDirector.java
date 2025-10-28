package src.main.java.com.example.builder;

import src.main.java.com.example.domain.Computer;
import src.main.java.com.example.factory.ComponentFactory;

public class ComputerDirector {
    private ComputerBuilder builder;
    
    public ComputerDirector(ComputerBuilder builder) {
        this.builder = builder;
    }
    
    public Computer constructGamingPC(ComponentFactory factory) {
        System.out.println("\n=== Building Gaming PC ===");
        return builder
            .reset()
            .setName("Ultimate Gaming Rig")
            .setProcessor(factory.createProcessor())
            .setGPU(factory.createGPU())
            .setRAM(factory.createRAM())
            .setStorage(factory.createStorage())
            .setCoolingSystem("Liquid Cooling 360mm")
            .setCaseType("RGB Tempered Glass ATX")
            .enableRGBLighting()
            .build();
    }
    
    public Computer constructOfficePC(ComponentFactory factory) {
        System.out.println("\n=== Building Office PC ===");
        return builder
            .reset()
            .setName("Office Productivity System")
            .setProcessor(factory.createProcessor())
            .setGPU(factory.createGPU())
            .setRAM(factory.createRAM())
            .setStorage(factory.createStorage())
            .setCoolingSystem("Stock Air Cooler")
            .setCaseType("Standard Black Case")
            .build();
    }
    
    public Computer constructWorkstation(ComponentFactory factory) {
        System.out.println("\n=== Building Professional Workstation ===");
        return builder
            .reset()
            .setName("Professional Workstation")
            .setProcessor(factory.createProcessor())
            .setGPU(factory.createGPU())
            .setRAM(factory.createRAM())
            .setStorage(factory.createStorage())
            .setCoolingSystem("High-Performance Liquid Cooling")
            .setCaseType("Professional Tower Case")
            .build();
    }
}

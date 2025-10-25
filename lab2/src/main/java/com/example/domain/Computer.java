package com.example.domain;

import com.example.components.processor.Processor;
import com.example.components.gpu.GPU;
import com.example.components.ram.RAM;
import com.example.components.storage.Storage;

public class Computer {
    private String name;
    private Processor processor;
    private GPU gpu;
    private RAM ram;
    private Storage storage;
    private String coolingSystem;
    private String caseType;
    private boolean hasRGBLighting;
    
    public void setName(String name) { 
        this.name = name; 
    }
    
    public void setProcessor(Processor processor) { 
        this.processor = processor; 
    }
    
    public void setGPU(GPU gpu) { 
        this.gpu = gpu; 
    }
    
    public void setRAM(RAM ram) { 
        this.ram = ram; 
    }
    
    public void setStorage(Storage storage) { 
        this.storage = storage; 
    }
    
    public void setCoolingSystem(String coolingSystem) { 
        this.coolingSystem = coolingSystem; 
    }
    
    public void setCaseType(String caseType) { 
        this.caseType = caseType; 
    }
    
    public void setRGBLighting(boolean hasRGBLighting) { 
        this.hasRGBLighting = hasRGBLighting; 
    }
    
    public double getTotalPrice() {
        return processor.getPrice() + gpu.getPrice() + ram.getPrice() + storage.getPrice();
    }
    
    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("\n========================================\n");
        sb.append("COMPUTER CONFIGURATION: ").append(name).append("\n");
        sb.append("========================================\n");
        sb.append("Processor: ").append(processor.getSpecifications()).append(" - $").append(processor.getPrice()).append("\n");
        sb.append("GPU: ").append(gpu.getSpecifications()).append(" - $").append(gpu.getPrice()).append("\n");
        sb.append("RAM: ").append(ram.getSpecifications()).append(" - $").append(ram.getPrice()).append("\n");
        sb.append("Storage: ").append(storage.getSpecifications()).append(" - $").append(storage.getPrice()).append("\n");
        if (coolingSystem != null) {
            sb.append("Cooling: ").append(coolingSystem).append("\n");
        }
        if (caseType != null) {
            sb.append("Case: ").append(caseType).append("\n");
        }
        if (hasRGBLighting) {
            sb.append("RGB Lighting: Enabled\n");
        }
        sb.append("----------------------------------------\n");
        sb.append("TOTAL PRICE: $").append(String.format("%.2f", getTotalPrice())).append("\n");
        sb.append("========================================\n");
        return sb.toString();
    }
}
package com.example.builder;

import com.example.domain.Computer;
import com.example.components.processor.Processor;
import com.example.components.gpu.GPU;
import com.example.components.ram.RAM;
import com.example.components.storage.Storage;

public class ComputerBuilder {
    private Computer computer;
    
    public ComputerBuilder() {
        this.computer = new Computer();
    }
    
    public ComputerBuilder setName(String name) {
        computer.setName(name);
        return this;
    }
    
    public ComputerBuilder setProcessor(Processor processor) {
        computer.setProcessor(processor);
        return this;
    }
    
    public ComputerBuilder setGPU(GPU gpu) {
        computer.setGPU(gpu);
        return this;
    }
    
    public ComputerBuilder setRAM(RAM ram) {
        computer.setRAM(ram);
        return this;
    }
    
    public ComputerBuilder setStorage(Storage storage) {
        computer.setStorage(storage);
        return this;
    }
    
    public ComputerBuilder setCoolingSystem(String coolingSystem) {
        computer.setCoolingSystem(coolingSystem);
        return this;
    }
    
    public ComputerBuilder setCaseType(String caseType) {
        computer.setCaseType(caseType);
        return this;
    }
    
    public ComputerBuilder enableRGBLighting() {
        computer.setRGBLighting(true);
        return this;
    }
    
    public Computer build() {
        return computer;
    }
}

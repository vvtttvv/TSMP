package src.main.java.com.example.builder;

import src.main.java.com.example.domain.Computer;
import src.main.java.com.example.components.processor.Processor;
import src.main.java.com.example.components.gpu.GPU;
import src.main.java.com.example.components.ram.RAM;
import src.main.java.com.example.components.storage.Storage;

public class ConcreteComputerBuilder implements ComputerBuilder {
    private Computer computer;
    
    public ConcreteComputerBuilder() {
        this.reset();
    }
    
    @Override
    public ComputerBuilder reset() {
        this.computer = new Computer(); 
        return this;
    }
    
    @Override
    public ComputerBuilder setName(String name) {
        computer.setName(name);
        return this;
    }
    
    @Override
    public ComputerBuilder setProcessor(Processor processor) {
        computer.setProcessor(processor);
        return this;
    }
    
    @Override
    public ComputerBuilder setGPU(GPU gpu) {
        computer.setGPU(gpu);
        return this;
    }
    
    @Override
    public ComputerBuilder setRAM(RAM ram) {
        computer.setRAM(ram);
        return this;
    }
    
    @Override
    public ComputerBuilder setStorage(Storage storage) {
        computer.setStorage(storage);
        return this;
    }
    
    @Override
    public ComputerBuilder setCoolingSystem(String coolingSystem) {
        computer.setCoolingSystem(coolingSystem);
        return this;
    }
    
    @Override
    public ComputerBuilder setCaseType(String caseType) {
        computer.setCaseType(caseType);
        return this;
    }
    
    @Override
    public ComputerBuilder enableRGBLighting() {
        computer.setRGBLighting(true);
        return this;
    }
    
    @Override
    public Computer build() {
        Computer result = this.computer;
        this.reset();
        return result;
    }
}

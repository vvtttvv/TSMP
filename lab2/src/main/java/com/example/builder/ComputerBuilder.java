package src.main.java.com.example.builder;

import src.main.java.com.example.domain.Computer;
import src.main.java.com.example.components.processor.Processor;
import src.main.java.com.example.components.gpu.GPU;
import src.main.java.com.example.components.ram.RAM;
import src.main.java.com.example.components.storage.Storage;

public interface ComputerBuilder {
    ComputerBuilder reset();
    ComputerBuilder setName(String name);
    ComputerBuilder setProcessor(Processor processor);
    ComputerBuilder setGPU(GPU gpu);
    ComputerBuilder setRAM(RAM ram);
    ComputerBuilder setStorage(Storage storage);
    ComputerBuilder setCoolingSystem(String coolingSystem);
    ComputerBuilder setCaseType(String caseType);
    ComputerBuilder enableRGBLighting();
    Computer build();
}
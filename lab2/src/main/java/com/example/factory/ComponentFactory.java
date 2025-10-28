package src.main.java.com.example.factory;

import src.main.java.com.example.components.processor.Processor;
import src.main.java.com.example.components.gpu.GPU;
import src.main.java.com.example.components.ram.RAM;
import src.main.java.com.example.components.storage.Storage;

public abstract class ComponentFactory {
    public abstract Processor createProcessor();
    public abstract GPU createGPU();
    public abstract RAM createRAM();
    public abstract Storage createStorage();
}
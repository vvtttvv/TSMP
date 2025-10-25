package com.example.factory;

import com.example.components.processor.Processor;
import com.example.components.gpu.GPU;
import com.example.components.ram.RAM;
import com.example.components.storage.Storage;

public abstract class ComponentFactory {
    public abstract Processor createProcessor();
    public abstract GPU createGPU();
    public abstract RAM createRAM();
    public abstract Storage createStorage();
}
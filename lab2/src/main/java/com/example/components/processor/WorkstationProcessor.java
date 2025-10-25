package com.example.components.processor;

public class WorkstationProcessor implements Processor {
    @Override
    public String getSpecifications() {
        return "AMD Ryzen Threadripper 3970X, 32 cores, 4.5GHz";
    }
    
    @Override
    public double getPrice() {
        return 1899.99;
    }
}
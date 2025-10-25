package com.example.components.gpu;

public class WorkstationGPU implements GPU {
    @Override
    public String getSpecifications() {
        return "NVIDIA RTX A6000, 48GB GDDR6";
    }
    
    @Override
    public double getPrice() {
        return 4500.99;
    }
}
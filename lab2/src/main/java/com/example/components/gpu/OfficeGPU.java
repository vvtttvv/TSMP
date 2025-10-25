package com.example.components.gpu;

public class OfficeGPU implements GPU {
    @Override
    public String getSpecifications() {
        return "Intel UHD Graphics 730 (Integrated)";
    }
    
    @Override
    public double getPrice() {
        return 0.0;
    }
}
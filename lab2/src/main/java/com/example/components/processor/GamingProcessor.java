package com.example.components.processor;

public class GamingProcessor implements Processor {
    @Override
    public String getSpecifications() {
        return "Intel Core i9-13900K, 24 cores, 5.8GHz";
    }
    
    @Override
    public double getPrice() {
        return 589.99;
    }
}
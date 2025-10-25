package com.example.components.ram;

public class GamingRAM implements RAM {
    @Override
    public String getSpecifications() {
        return "32GB DDR5 6000MHz RGB";
    }
    
    @Override
    public double getPrice() {
        return 159.99;
    }
}
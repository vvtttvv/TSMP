package com.example.components.ram;

public class WorkstationRAM implements RAM {
    @Override
    public String getSpecifications() {
        return "128GB DDR5 5200MHz ECC";
    }
    
    @Override
    public double getPrice() {
        return 899.99;
    }
}

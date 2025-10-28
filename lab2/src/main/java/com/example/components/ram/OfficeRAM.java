package src.main.java.com.example.components.ram;

public class OfficeRAM implements RAM {
    @Override
    public String getSpecifications() {
        return "16GB DDR4 3200MHz";
    }
    
    @Override
    public double getPrice() {
        return 49.99;
    }
}
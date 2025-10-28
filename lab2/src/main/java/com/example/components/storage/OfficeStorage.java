package src.main.java.com.example.components.storage;

public class OfficeStorage implements Storage {
    @Override
    public String getSpecifications() {
        return "512GB SATA SSD";
    }
    
    @Override
    public double getPrice() {
        return 49.99;
    }
}
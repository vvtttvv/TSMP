package src.main.java.com.example.components.storage;

public class GamingStorage implements Storage {
    @Override
    public String getSpecifications() {
        return "2TB NVMe Gen4 SSD";
    }
    
    @Override
    public double getPrice() {
        return 199.99;
    }
}
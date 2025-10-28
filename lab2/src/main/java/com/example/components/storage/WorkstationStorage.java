package src.main.java.com.example.components.storage;

public class WorkstationStorage implements Storage {
    @Override
    public String getSpecifications() {
        return "4TB NVMe Gen4 SSD + 8TB HDD";
    }
    
    @Override
    public double getPrice() {
        return 699.99;
    }
}
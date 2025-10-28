package src.main.java.com.example.components.gpu;

public class GamingGPU implements GPU {
    @Override
    public String getSpecifications() {
        return "NVIDIA RTX 4090, 24GB GDDR6X";
    }
    
    @Override
    public double getPrice() {
        return 1599.99;
    }
}
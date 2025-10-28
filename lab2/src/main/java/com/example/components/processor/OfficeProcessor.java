package src.main.java.com.example.components.processor;

public class OfficeProcessor implements Processor {
    @Override
    public String getSpecifications() {
        return "Intel Core i5-12400, 6 cores, 4.4GHz";
    }
    
    @Override
    public double getPrice() {
        return 189.99;
    }
}
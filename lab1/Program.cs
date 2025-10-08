using Microsoft.Extensions.DependencyInjection;

namespace SolidAnimals
{
    // S: Single Responsibility
    public abstract class Animal
    {
        public string Name { get; }

        protected Animal(string name)
        {
            Name = name;
        }

        public abstract void MakeSound();
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Woof!");
        }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Meow!");
        }
    }

    public class Cow : Animal
    {
        public Cow(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Moo!");
        }
    }

    // O: Open/Closed Principle

    // D: Dependency Inversion Principle
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string name);
    }

    public class DogFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string name) => new Dog(name);
    }

    public class CatFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string name) => new Cat(name);
    }

    public class CowFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string name) => new Cow(name);
    }

    public class AnimalCreator
    {
        private readonly IAnimalFactory _factory;

        public AnimalCreator(IAnimalFactory factory)
        {
            _factory = factory;
        }

        public void CreateAndMakeSound(string name)
        {
            Animal animal = _factory.CreateAnimal(name);
            animal.MakeSound();
        }
    }

    class Program
    {
        static void Main()
        {

            var animals = new List<AnimalCreator>
            {
                new AnimalCreator(new DogFactory()),
                new AnimalCreator(new CatFactory()),
                new AnimalCreator(new CowFactory())
            };

            string[] names = { "Rex", "Mittens", "Bessie" };

            for (int i = 0; i < animals.Count; i++)
            {
                animals[i].CreateAndMakeSound(names[i]);
            }
        }
    }
}

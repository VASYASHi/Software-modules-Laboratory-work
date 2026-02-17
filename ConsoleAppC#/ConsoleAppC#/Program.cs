using System;

namespace AnimalApp
{
    // Базовый класс Animal
    public class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        public virtual void Speak()
        {
            Console.WriteLine($"{Name} издает звук.");
        }
    }

    // Производный класс Dog
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override void Speak()
        {
            Console.WriteLine($"{Name} говорит: Гав!");
        }
    }

    // Производный класс Cat
    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override void Speak()
        {
            Console.WriteLine($"{Name} говорит: Мяу!");
        }
    }

    // Обобщенный класс для обработки животных
    public class AnimalProcessor
    {
        // Обобщенный метод для обработки животных
        public void ProcessAnimal<T>(T animal) where T : Animal
        {
            animal.Speak(); // Вызываем метод Speak() для животного
            Console.WriteLine($"Животное: {animal.Name}.");
        }

        // Перегрузка метода для обработки массива животных
        public void ProcessAnimal(Animal[] animals)
        {
            foreach (var animal in animals)
            {
                animal.Speak(); // Вызываем метод Speak() для каждого животного
                Console.WriteLine($"Животное: {animal.Name}.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объекты животных
            Dog myDog = new Dog("Шарик");
            Cat myCat = new Cat("Мурка");

            // Создаем экземпляр AnimalProcessor
            AnimalProcessor processor = new AnimalProcessor();

            // Обрабатываем отдельное животное
            processor.ProcessAnimal(myDog); // Передаем объект Dog
            processor.ProcessAnimal(myCat); // Передаем объект Cat

            // Создаем массив животных
            Animal[] animals = { myDog, myCat };

            // Обрабатываем массив животных
            processor.ProcessAnimal(animals); // Передаем массив Animal

            Console.WriteLine("Обработка завершена. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}



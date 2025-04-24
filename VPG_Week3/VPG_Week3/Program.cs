using VPG_Week3;

//Animal animal = new Animal("Animal");
Cat cat = new Cat("Cat");
Dog dog = new Dog("Dog");

//Console.WriteLine(animal.MakeNoise());
Console.WriteLine(cat.MakeNoise());
Console.WriteLine(dog.MakeNoise());

Character character = new Character("Character1", "Cry", 20);
Character warrior = new Warrior("Warrior1", "YAAAR", 30, 50);
Character mage = new Mage("Mage1", "Avada Kadavra", 100);

character.Cry();
warrior.Cry();
mage.Cry();

Shark shark = new Shark("Shark");
Salmon salmon = new Salmon("Salmon");

shark.Swim();
shark.Eat();
shark.Reproduce();
shark.Die();

salmon.Swim();
salmon.Eat();
salmon.Reproduce();
salmon.Die();

Console.WriteLine(shark.MakeNoise());
Console.WriteLine(salmon.MakeNoise());

List<Shape> shapes = new List<Shape>();
Rectangle rect = new Rectangle(3, 4);
Circle circle = new Circle(3);

shapes.Add(rect);
shapes.Add(circle);

foreach (Shape shape in shapes)
{
    shape.CalculateArea();
}

Vehicle car1 = new Car("car1");
Vehicle car2 = new Car("car2");
Vehicle truck1 = new Truck("truck1");
Vehicle truck2 = new Truck("truck2");

car1.Drive();
truck1.Drive();

Car c = (Car)car1;
Truck t = truck2 as Truck;

c.CarHonk();
t.TruckHonk();

List<IBird> birds = new List<IBird>();
Goose goose = new Goose();
Seagull seagull = new Seagull();
Crow crow = new Crow();

birds.Add(goose);
birds.Add(seagull);
birds.Add(crow);

foreach (IBird bird in birds)
{
    bird.MakeSound();
    bird.Threaten();
}

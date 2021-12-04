var animal = Animal.Cat | Animal.Elephant;

Console.WriteLine(animal);

Console.WriteLine(animal.HasFlag(Animal.Cat));
Console.WriteLine(animal.HasFlag(Animal.Dog));
Console.WriteLine(animal.HasFlag(Animal.Elephant));
Console.WriteLine(animal.HasFlag(Animal.Bee));

enum Animal
{
    None = 0,
    Cat = 1,
    Dog = 2,
    Elephant = 4,
    Bee = 8,
}
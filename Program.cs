using System;
using System.Linq;

namespace OnSafari
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to the Safari!");
      var input = "";
      var db = new SafariContext();
      //   while (input != "quit")

      Console.WriteLine("Add an animal to your Safari");
      input = Console.ReadLine();
      if (input != "quit")
      {
        // input expected is animal species, count, location
        var data = input.Split(',');
        var newAnimal = new SeenAnimals
        {
          Species = data[0],
          CountOfTimesSeen = int.Parse(data[1]),
          LocationOfLastSeen = data[2]
        };
        db.Animals.Add(newAnimal);
        db.SaveChanges();
        Console.WriteLine($"Saved {newAnimal.Species} to Safari Journal");
      }
      Console.WriteLine("Do you want to see (all) your animals?");
      input = Console.ReadLine();
      if (input == "all")
      {
        var allAnimals = db.Animals.OrderBy(o => o.Species);
        foreach (var animal in allAnimals)
        {
          Console.WriteLine($"{animal.Species}");
        }
      }

    }
  }
}

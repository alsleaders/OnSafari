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
      while (input.ToLower() != "quit")
      {
        Console.WriteLine("Add an animal to your Safari");
        input = Console.ReadLine();
        if (input.ToLower() != "quit")
        {
          // input expected is animal species, count, location
          var data = input.Split(", ");
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
      }

      Console.WriteLine("Do you want to see all the animals in the (jungle) or the (forest)?");
      // display all animals in "jungle"
      input = Console.ReadLine();

      var allAnimals = db.Animals.Where(o => o.LocationOfLastSeen == input);
      foreach (var animal in allAnimals)
      {
        Console.WriteLine($"{animal.Species} was seen in {animal.LocationOfLastSeen}");
      }


      // Update Count and Last Seen
      Console.WriteLine("Do you want to update the (count) or (location) of animals on your log");
      input = Console.ReadLine();
      if (input.ToLower() == "count")
      {
        // expected input is species, count
        Console.WriteLine("Which species do you want to update, and by how much");
        input = Console.ReadLine();
        // split the input
        var info = input.Split(", ");
        //assign input[0] to name
        //assign input[1] to count
        var changedCount = db.Animals.FirstOrDefault(f => f.Species == info[0]);
        changedCount.CountOfTimesSeen = changedCount.CountOfTimesSeen += int.Parse(info[1]);
        db.SaveChanges();
        Console.WriteLine($"You updated {info[0]} to {changedCount.CountOfTimesSeen} times");

      }
      if (input.ToLower() == "location")
      {
        // expected input is species, location
        Console.WriteLine("Which species do you want to update, and where");
        input = Console.ReadLine();
        var info = input.Split(", ");
        var changedLocation = db.Animals.FirstOrDefault(f => f.Species == info[0]);
        changedLocation.LocationOfLastSeen = info[1];
        db.SaveChanges();
        Console.WriteLine($"You updated {info[0]} to seen in the {changedLocation.LocationOfLastSeen}");
      }




      // remove all animals from "desert"
      Console.WriteLine("Do you want to remove animals from your log");
      input = Console.ReadLine();
      if (input.ToLower() == "yes")
      {
        Console.WriteLine("Do you want to remove animals from the (jungle), the (desert), the (river), the (forest), the (moor) or the (frozen tundra)");
        var removePlace = Console.ReadLine();
        var removeALL = db.Animals.Where(w => w.LocationOfLastSeen == removePlace);
        db.Animals.RemoveRange(removeALL);
        db.SaveChanges();
        Console.WriteLine($"Removed {removePlace} from Journal");
      }


      // add all Count to get total animals seen

      // get count of "lions", "tigers", and "bears"
      // Console.WriteLine("Would you like a (count) of all the lions, tigers, and bears?");
      // input = Console.ReadLine();
      // var ohMy = db.Animals.Select(s => s.Species = "lion");





    }
  }
}

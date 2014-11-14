using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class AnimalsClass
    {
        static void Main()
        {
            var animals = new Animal[]
            {
                new Dog("dog", 23, Gender.Female),
                new Kitten("Kate", 2),
                new Frog("jabalka", 1, Gender.Female),
                new Frog("kekerica", 3, Gender.Female),
                new Dog("sharo", 3, Gender.Male),
                new Dog("sara", 2, Gender.Female),
                new Dog("lukky", 12, Gender.Male),
                new Kitten("maya", 2), 
                new Tomcat("tommy", 4),
                new Cat("djery", 5, Gender.Male)
            };
            var averageAgeOfKindOfAnimal =
                from animal in animals
                group animal by animal.GetKindAnimal() into g
                select new { GroupName = g.Key, averageAge = g.Average(an => an.Age) };
            foreach (var animalGroup in averageAgeOfKindOfAnimal)
            {
                Console.WriteLine("The average age of {0}s is {1:f2}.", animalGroup.GroupName, animalGroup.averageAge);
            }
            
        }
    }
}

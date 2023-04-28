using System.Runtime.CompilerServices;

namespace CoffeeMinimalAPI
{
    public record Coffee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class CoffeeDB
    {
        private static List<Coffee> _coffee = new List<Coffee>()
        {
            new Coffee { Id = 1, Name = "Americano" },
            new Coffee { Id = 2, Name = "Capuchino" },
            new Coffee { Id = 3, Name = "Espresso" },
            new Coffee { Id = 4, Name = "Latte" },
            new Coffee { Id = 5, Name = "Té Matcha" },
            new Coffee { Id = 2, Name = "Tisana" }
        };

        public static List<Coffee> GetCoffee()
            => _coffee;

        public static Coffee? GetCoffee(int id)
        {
            return _coffee.SingleOrDefault(coffee =>coffee.Id == id);
        }

        public static Coffee CreateCoffeeOrder(Coffee coffee)
        {
            _coffee.Add(coffee);
            return coffee;
        }

        public static Coffee UpdateCoffeeOrder(Coffee update)
        {
            _coffee = _coffee.Select(coffee =>
            {
                if (coffee.Id == update.Id)
                {
                    coffee.Name = update.Name;
                }
                return coffee;
            }).ToList();
            return update;
        }
    }
}

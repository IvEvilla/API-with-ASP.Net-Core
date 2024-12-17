
using API_ASP.Net_Proyect.Models;

namespace API_ASP.Net_Proyect.Services
{
    public class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;
        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Pizza Italiana", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Pizza con Queso", IsGlutenFree = true }
            };
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        //Add
        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }
        
        //Delete
        public static void Delete(int id)
        {
            var pizza = Get(id);
            if(pizza == null)
            {
                return;
            }
            else
            {
                Pizzas.Remove(pizza);
            }
        }

        //Update

        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if(index == -1)
            {
                return;
            }
            else
            {
                Pizzas[index] = pizza;
            }
        }
        



    }
}

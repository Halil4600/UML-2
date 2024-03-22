using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML2;

namespace UML_2
{
    public class MenuCatalog
    {
        List<Pizza> _pizzas;

        public MenuCatalog()
        {
            _pizzas = new List<Pizza>();
        }

        public void Create(Pizza p)
        {
            _pizzas.Add(p);
        }

        public void DeletePizza(int PizzaId)
        {
            _pizzas.RemoveAll(Pizza => Pizza.PizzaId == PizzaId);
        }

        public bool UpdatePizza(int PizzaId, string Name, double Price)
        {
            var pizza = _pizzas.FirstOrDefault(p => p.PizzaId == PizzaId);
            if (pizza != null)
            {
                pizza.PizzaId = PizzaId;
                pizza.Name = Name;
                pizza.Price = Price;
                return true; 
            }
            return false; 
        }

        public void SearchPizza()
        { 
            
        }
       
        public void PrintMenu()
        {
            foreach (Pizza p in _pizzas)
            { 
                Console.WriteLine(p);
            }
        }



    }
}

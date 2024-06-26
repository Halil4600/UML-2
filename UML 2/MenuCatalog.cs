﻿using System;
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
            
            foreach (Pizza pizza in _pizzas)
            {
                if (pizza.PizzaId == p.PizzaId)
                { throw new FormatException("Pizza with this id exists. No pizza was created"); }
            }
            _pizzas.Add(p);
        }

        public void DeletePizza(Pizza pizza)
        {
            if (pizza.PizzaId <= 0)
            {
                throw new FormatException("No number");
            }
            foreach (var i in _pizzas)
            {
                if (i.PizzaId == pizza.PizzaId)
                {
                    pizza = i;
                }
            }
            if ((pizza.Name == null) || (pizza.Name.Trim().Length <= 0)) { throw new FormatException("Pizza doesnt exist"); }

            _pizzas.Remove(pizza);
        }

        public void UpdatePizza(Pizza pizza)
        {
            bool PizzaFound = false;
            foreach (Pizza i in _pizzas)
            {
                if (i.PizzaId == pizza.PizzaId)
                {
                    i.Name = pizza.Name;
                    i.Price = pizza.Price;
                    PizzaFound = true;
                }
            }
            if (PizzaFound == false) { throw new FormatException("Pizza doesnt exist"); }

        }

        public Pizza SearchPizza(int PizzaId)
        {
            bool foundpizza = false;
            foreach (Pizza pizza in _pizzas)
            {
                if (pizza.PizzaId == PizzaId)
                {
                    return pizza;
                    foundpizza= true;
                }
            }
            if (foundpizza == false) { throw new FormatException("Pizza doesnt exist"); }
            return null;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML2
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Number: {PizzaId}, Name: {Name}, Price: {Price}";
        }
    }
}
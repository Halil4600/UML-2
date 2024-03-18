using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_2
{
    public class MenuCatalog
    {
        private List<Pizza> _Pizzas = new List<Pizza>();

        public void Add(Pizza pizza)
        {
            _Pizzas.Add(pizza);
        }
    }
}

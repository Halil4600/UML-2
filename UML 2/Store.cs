using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML2;

namespace UML_2
{
    public class Store
    {
        MenuCatalog menuCatalog;

        public Store()
        {
            menuCatalog = new MenuCatalog();
        }

        public void Test()
        {
            Pizza p = new Pizza() { PizzaId = 1, Name = "Margherita", Price = 69 };
            menuCatalog.Create(p);

            p = new Pizza() { PizzaId = 2, Name = "Italiana", Price = 75 };
            menuCatalog.Create(p);

            p = new Pizza() { PizzaId = 3, Name = "Big Mamma", Price = 90 };
            menuCatalog.Create(p);

            menuCatalog.PrintMenu();
        }

        public void Run()
        {
            new UserDialog(menuCatalog).Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UML2;

namespace UML_2
{
    public class UserDialog
    {
        MenuCatalog _menuCatalog;
        private int pizzaId;

        public UserDialog(MenuCatalog menuCatalog) 
        {
            _menuCatalog = menuCatalog;
        }

        Pizza CreateNewPizza()
        {
            Pizza pizza = new Pizza();
            Console.Clear();
            Console.WriteLine("Creating a new pizza");
            Console.Write("Enter name of the pizza ");
            pizza.Name = Console.ReadLine();

            string input = "";
            Console.Write("Enter price of the pizza ");
            try
            {
                input = Console.ReadLine();
                pizza.Price = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to parse {input} - Message: {e.Message}");
                throw;
            }

            input = "";
            Console.Write("Enter the pizza id ");
            try
            {
                input = Console.ReadLine();
                pizza.PizzaId = Int32.Parse(input);
            }
            catch (FormatException e) 
            { 
                Console.WriteLine($"Unable to parse {input} - Message: {e.Message}");
                throw;
            }
            return pizza;
        }
        Pizza DeletePizza()
        {
            Pizza pizza = new Pizza();
            Console.Clear();
            Console.WriteLine("Enter the id of the pizza you want to delete");
            string input = "";

            try
            {
                input = Console.ReadLine();
                pizza.PizzaId = Int32.Parse(input);
            }
            catch (FormatException e) 
            {
                Console.WriteLine("Pizza doesnt exist");
            }
            return pizza;
        }

        Pizza UpdatePizza()
        {
            Pizza pizza = new Pizza();
            Console.Clear();
            _menuCatalog.PrintMenu();
            Console.WriteLine();
            Console.WriteLine("Enter the Id of the pizza you want to update");
            pizza.PizzaId = Int32.Parse(Console.ReadLine());
            Pizza p = _menuCatalog.SearchPizza(pizza.PizzaId);

            if (p != null)
            {
                string input = "";
                Console.Write("Enter new name for the pizza: ");
                try
                {
                    input = Console.ReadLine();
                    pizza.Name = input;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid name:");
                }

                input = "";
                Console.Write("Enter new price for the pizza: ");
                try
                {
                    input = Console.ReadLine();
                    pizza.Price = Int32.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid price");
                }
            }
            return pizza;

        }

        Pizza SearchPizza()
        {
            Pizza pizza = new Pizza();
            Console.Clear();
            Console.WriteLine("Enter the ID of the pizza you want to search for:");

            string input = "";
            try
            {
                input = Console.ReadLine();
                pizza.PizzaId = Int32.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Pizza doesnt exist");
            }
            return pizza;
        }

        int MainMenuChoice(List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine("Options:");
            foreach (string choice in menuItems)
            {
                Console.WriteLine(choice);
            }
            Console.Write("Enter option:");
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = Int32.Parse(input);
                return result;
            }
            catch (FormatException) 
            {
                Console.WriteLine($"Unable to parse {input}");
            }
            return -1;
        }
        public void Run()
        {
            bool proceed = true;
            List<string> mainMenu = new List<string>()
            {
                "1. Create a new pizza",
                "2. Delete a pizza",
                "3. Update a pizza",
                "4. Search for a pizza",
                "5. See the pizza menu",
                "6. Quit"
            };

            while (proceed)
            {
                int MenuChoice = MainMenuChoice(mainMenu);
                Console.WriteLine();
                switch (MenuChoice)
                {
                    case 1:
                        try
                        {
                            Pizza pizza = CreateNewPizza();
                            _menuCatalog.Create(pizza);
                            Console.WriteLine($"You have created: {pizza}");
                        }
                        catch (Exception) 
                        {
                            Console.WriteLine($"Pizza with this id exists. No pizza was created");
                        }
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;

                    case 2:
                        try
                        {
                            Pizza pizza = DeletePizza();
                            _menuCatalog.DeletePizza(pizza);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Pizza doesnt exist");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 3:
                        try
                        {
                            Pizza pizza = UpdatePizza();
                            _menuCatalog.UpdatePizza(pizza);
                            Console.WriteLine($"The pizza has been updated: {pizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No pizza was updated");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case 4:
                        try
                        {
                            Pizza pizza = SearchPizza();
                            pizza = _menuCatalog.SearchPizza(pizza.PizzaId);
                            Console.WriteLine($"The following pizza is found: {pizza}");
                        }
                        catch (Exception)
                        { 
                            Console.WriteLine("Pizza doesnt exist");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 5:
                            _menuCatalog.PrintMenu();
                            Console.Write("Hit any key to continue");
                            Console.ReadKey();
                            break;

                    case 6:
                        proceed = false;
                        Console.WriteLine("Quitting");
                        break;
                        
                }
            }
        }


    }
}

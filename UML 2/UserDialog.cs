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

        public void DeletePizza(int id)
        {
            Console.WriteLine("Enter the ID of the pizza you want to delete:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int pizzaId))
            {
                DeletePizza(pizzaId);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid pizza ID.");
            }
        }

        public void UpdatePizza()
        {
            Console.WriteLine("Enter the Id of the pizza you want to update:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int pizzaId))
            {
                Console.WriteLine("Enter the new name for the chosen pizza:");
                string Name = Console.ReadLine();

                Console.WriteLine("Enter the new price for the chosen pizza:");
                if (double.TryParse(Console.ReadLine(), out double Price))
                {
                    _menuCatalog.UpdatePizza(pizzaId, Name, Price);
                    Console.WriteLine("Pizza updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid input for price. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for ID. Please enter a valid number.");
            }
        }

        public void SearchPizza()
        {
            Console.WriteLine("Enter the ID of the pizza you want to search for:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int PizzaId))
            {
                Pizza pizza = _menuCatalog.SearchPizza(PizzaId);
                if (pizza != null)
                {
                    Console.WriteLine($"Pizza Found: ID = {pizza.PizzaId}, Name = {pizza.Name}, Price = {pizza.Price}");
                }
                else
                {
                    Console.WriteLine("Pizza not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid pizza ID.");
            }
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
                            Console.WriteLine($"No pizza was created");
                        }
                        Console.Write("Hit any key to continue");
                        Console.ReadKey();
                        break;

                    case 2:

                        Console.Write("Type the ID of the pizza you want to delete: ");
                        string input = Console.ReadLine();

                        
                        if (int.TryParse(input, out int pizzaId))
                        {
                            
                            _menuCatalog.DeletePizza(pizzaId);
                            Console.WriteLine("Pizza deleted successfully.");
                        }
                        else
                        {
                            
                            Console.WriteLine("Invalid input. Please enter a valid pizza ID.");
                        }
                        break;

                    case 3:
                        UpdatePizza();
                        break;

                    case 4:
                        SearchPizza();
                        int choice = int.Parse(Console.ReadLine());
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

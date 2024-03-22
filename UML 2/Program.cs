namespace UML_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.Test();
            Console.Write("Hit any key to continue with the user dialog");
            Console.ReadKey();
            store.Run();
        }
    }

}

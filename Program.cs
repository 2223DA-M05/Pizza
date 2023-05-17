public static class Program
{
    public static void Main()
    {
        while (true)
        {
            string line;

            decimal amount;
            do
            {
                Console.WriteLine("Enter amount:");
                line = Console.ReadLine();
            } while (!decimal.TryParse(line, out amount));

            int type;
            do
            {
                Console.WriteLine("Enter type:");
                line = Console.ReadLine();
            } while (!int.TryParse(line, out type));

            int years;
            do
            {
                Console.WriteLine("Enter years:");
                line = Console.ReadLine();
            } while (!int.TryParse(line, out years));

            var calculator = new Class1();
            var result = calculator.Calculate(amount, type, years);

            Console.WriteLine("Result: " + result);
        }

    }
}
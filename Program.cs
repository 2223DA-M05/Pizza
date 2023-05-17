public static class Program
{
    public static void Main()
    {
        while (true)
        {
            string line;

            decimal price;
            do
            {
                Console.WriteLine("Enter price:");
                line = Console.ReadLine();
            } while (!decimal.TryParse(line, out price));

            int accountStatus;
            do
            {
                Console.WriteLine("Enter account status:");
                line = Console.ReadLine();
            } while (!int.TryParse(line, out accountStatus));

            int timeOfHavingAccountInYears;
            do
            {
                Console.WriteLine("Enter time of having account in years:");
                line = Console.ReadLine();
            } while (!int.TryParse(line, out timeOfHavingAccountInYears));

            var discountManager = new DiscountManager();
            var priceAfterDiscount = discountManager.ApplyDiscount(price, accountStatus, timeOfHavingAccountInYears);

            Console.WriteLine("Price after discount: " + priceAfterDiscount);
        }

    }
}
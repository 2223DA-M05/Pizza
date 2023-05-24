using MicroResolver;
using Microsoft.Extensions.Configuration;

public static class Program
{
    public async static Task Main(string[] args)
    {
        var resolver = ObjectResolver.Create();
        resolver.Register<IAccountDiscountCalculatorFactory, DefaultAccountDiscountCalculatorFactory>(Lifestyle.Singleton);
        resolver.Register<ILoyaltyDiscountCalculator, DefaultLoyaltyDiscountCalculator>(Lifestyle.Singleton);
        resolver.Register<IDiscountManager, DiscountManager>(Lifestyle.Singleton);
        resolver.Register<IConfiguration, TestConfiguration>();

        resolver.Compile();
        var discountManager = resolver.Resolve<IDiscountManager>();

        while (true)
        {
            string line;

            decimal price;
            do
            {
                Console.WriteLine("Enter price:");
                line = Console.ReadLine();
            } while (!decimal.TryParse(line, out price));

            AccountStatus accountStatus;
            do
            {
                Console.WriteLine("Enter account status:");
                line = Console.ReadLine();
            } while (!Enum.TryParse<AccountStatus>(line, out accountStatus));

            int timeOfHavingAccountInYears;
            do
            {
                Console.WriteLine("Enter time of having account in years:");
                line = Console.ReadLine();
            } while (!int.TryParse(line, out timeOfHavingAccountInYears));

            
            var priceAfterDiscount = discountManager.ApplyDiscount(price, accountStatus, timeOfHavingAccountInYears);

            Console.WriteLine("Price after discount: " + priceAfterDiscount);
        }
    }
}
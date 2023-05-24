using Microsoft.Extensions.Configuration;
using SimpleInjector;

public static class Program
{
    public async static Task Main(string[] args)
    {
        var container = new Container();
        container.Register<IAccountDiscountCalculatorFactory, ConfigurableAccountDiscountCalculatorFactory>(Lifestyle.Singleton);
        container.Register<ILoyaltyDiscountCalculator, DefaultLoyaltyDiscountCalculator>(Lifestyle.Singleton);
        container.Register<IDiscountManager, DiscountManager>(Lifestyle.Singleton);
        container.RegisterInstance<IConfiguration>(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());

        container.Verify();
        var discountManager = container.GetInstance<IDiscountManager>();

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
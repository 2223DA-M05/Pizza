using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class Program
{
    public async static Task Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args).Build();
        var discountManager = new DiscountManager(new ConfigurableAccountDiscountCalculatorFactory(host.Services.GetService<IConfiguration>()), new DefaultLoyaltyDiscountCalculator());

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
        await host.RunAsync();
    }
}
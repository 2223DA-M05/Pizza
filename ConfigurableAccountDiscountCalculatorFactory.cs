using Microsoft.Extensions.Configuration;

public class ConfigurableAccountDiscountCalculatorFactory : IAccountDiscountCalculatorFactory
{
    private readonly Dictionary<AccountStatus, IAccountDiscountCalculator> _discountsDictionary;

    public ConfigurableAccountDiscountCalculatorFactory(IConfiguration configuration)
    {
        var section = configuration.GetSection("DiscountCalculators");
        var discountsDictionary = new Dictionary<AccountStatus, IAccountDiscountCalculator>();
        foreach (var item in section.GetChildren())
        {
            AccountStatus accountStatus = Enum.Parse<AccountStatus>(item.GetValue<string>("key"));
            Type accountDiscountCalculatorType = Type.GetType(item.GetValue<string>("value"));
            IAccountDiscountCalculator accountDiscountCalculator = (IAccountDiscountCalculator)Activator.CreateInstance(accountDiscountCalculatorType);
            discountsDictionary.Add(accountStatus, accountDiscountCalculator);
        }
        _discountsDictionary = discountsDictionary;
    }

    public IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus)
    {
        IAccountDiscountCalculator calculator;
        if(!_discountsDictionary.TryGetValue(accountStatus, out calculator))
        {
            throw new NotImplementedException("There is no implementation of IAccountDiscountCalculator interface for given Account Status");
        }
        return calculator;
    }
}
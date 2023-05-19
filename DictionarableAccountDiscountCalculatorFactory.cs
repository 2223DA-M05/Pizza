public class DictionarableAccountDiscountCalculatorFactory : IAccountDiscountCalculatorFactory
{
    private readonly Dictionary<AccountStatus, IAccountDiscountCalculator> _discountsDictionary;

    public DictionarableAccountDiscountCalculatorFactory(Dictionary<AccountStatus, IAccountDiscountCalculator> discountsDictionary)
    {
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
public class DiscountManager : IDiscountManager
{
    private readonly IAccountDiscountCalculatorFactory _factory;
    private readonly ILoyaltyDiscountCalculator _loyaltyDiscountCalculator;

    public DiscountManager(IAccountDiscountCalculatorFactory factory, ILoyaltyDiscountCalculator loyaltyDiscountCalculator)
    {
        _factory = factory;
        _loyaltyDiscountCalculator = loyaltyDiscountCalculator;
    }

    public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
    {
        decimal priceAfterDiscount = 0;
        priceAfterDiscount = _factory.GetAccountDiscountCalculator(accountStatus).ApplyDiscount(price);
        priceAfterDiscount = _loyaltyDiscountCalculator.ApplyDiscount(priceAfterDiscount, timeOfHavingAccountInYears);
        return priceAfterDiscount;
    }
}
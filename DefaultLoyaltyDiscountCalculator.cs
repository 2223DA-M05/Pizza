public class DefaultLoyaltyDiscountCalculator : ILoyaltyDiscountCalculator
{
  public decimal ApplyDiscount(decimal price, int timeOfHavingAccountInYears)
  {
    return price.ApplyDiscountForTimeOfHavingAccount(timeOfHavingAccountInYears);
  }
}
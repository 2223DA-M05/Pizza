public class DiscountManager
{
    public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
    {
        decimal priceAfterDiscount = 0;
        switch (accountStatus)
        {
            case AccountStatus.NotRegistered:
                priceAfterDiscount = price;
                break;
            case AccountStatus.SimpleCustomer:
                priceAfterDiscount = price
                                        .ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS);
                break;
            case AccountStatus.ValuableCustomer:
                priceAfterDiscount = price
                                        .ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS);
                break;
            case AccountStatus.MostValuableCustomer:
                priceAfterDiscount = price
                                        .ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS);
                break;
            default:
                throw new NotImplementedException();
        }
        priceAfterDiscount = priceAfterDiscount.ApplyDiscountForTimeOfHavingAccount(timeOfHavingAccountInYears);

        return priceAfterDiscount;
    }
}
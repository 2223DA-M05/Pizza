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
                                        .ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS)
                                        .ApplyDiscountForTimeOfHavingAccount(timeOfHavingAccountInYears);
                break;
            case AccountStatus.ValuableCustomer:
                priceAfterDiscount = price
                                        .ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS)
                                        .ApplyDiscountForTimeOfHavingAccount(timeOfHavingAccountInYears);
                break;
            case AccountStatus.MostValuableCustomer:
                priceAfterDiscount = price
                                        .ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS)
                                        .ApplyDiscountForTimeOfHavingAccount(timeOfHavingAccountInYears);
                break;
            default:
                throw new NotImplementedException();
        }

        return priceAfterDiscount;
    }
}
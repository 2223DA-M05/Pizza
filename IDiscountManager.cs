public interface IDiscountManager
{
    decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears);
}
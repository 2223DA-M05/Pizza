public interface IAccountDiscountCalculatorFactory
{
    IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus);
}
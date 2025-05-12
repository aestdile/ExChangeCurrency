using CurrencyCource.Models;

namespace CurrencyCource.Services.IServices
{
    public interface ICustomerService
    {
        public string Registration(Customer customer);
        public string Login();
        public string UpdateProfile(Customer customer);
        public void GetBalance();
        public void Deposit();
        public void Withdraw();
        public Task<string> ExchangeCurrency();
        public Task<string> EnterSystem();
    }
}
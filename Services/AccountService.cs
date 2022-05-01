using DigitalPhotoPrinting.Models;

namespace DigitalPhotoPrinting.Services
{
    public interface AccountService
    {
        public dynamic? Login(string username, string password);

        public dynamic FindAll();

        public Account Create(Account account);

        public dynamic Find(string username);

    }
}

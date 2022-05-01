using DigitalPhotoPrinting.Models;
using System.Diagnostics;

namespace DigitalPhotoPrinting.Services
{
    public class AccountServiceImpl : AccountService
    {
        DatabaseContext db;

        public AccountServiceImpl(DatabaseContext _db) { 
            db = _db;
        }

        public Account Create(Account account)
        {
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            Debug.WriteLine(account.Password.Length);
            db.Add(account);
            db.SaveChanges();
            return account;
        }

        public dynamic Find(string username)
        {
            return db.Accounts.Where(a => a.UserName == username).Select(a => new
            {
                username = a.UserName,
                role = a.Role.Name
            });
        }

        public dynamic FindAll()
        {
            return db.Accounts.Select(a => new
            {
                id = a.Id,
                username = a.UserName,
                password = a.Password,
                firstname = a.FirstName,
                lastname = a.LastName,
                phone = a.Phone,
                address = a.Address,
                email = a.Email,
                birthday = a.Birthday,
                gender = a.Gender,
                role =  a.Role.Name,
            }).ToList();
        }

        public dynamic Login(string username, string password)
        {
            var account = db.Accounts.FirstOrDefault(a => a.UserName == username);
            if (account != null && BCrypt.Net.BCrypt.Verify(password, account.Password)) 
            {

                return new
                {
                    id = account.Id,
                    username = account.UserName,
                    password = account.Password,
                    firstname = account.FirstName,
                    lastname = account.LastName,
                    phone = account.Phone,
                    address = account.Address,
                    email = account.Email,
                    birthday = account.Birthday,
                    gender = account.Gender,
                    role = account.Role.Name,
                };
                //return account;
            }
            else
            {
                return new
                {
                    id = "",
                    username ="",
                    password = "",
                    firstname = "",
                    lastname = "",
                    phone = "",
                    address = "",
                    email = "",
                    birthday = "",
                    gender = "",
                    role = "",
                };
            }

        }
    }
}

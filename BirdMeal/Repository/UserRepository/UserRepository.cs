using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsersList()
        {
            return UserDAO.Instance.GetUsersList();
        }

        public User Login(string email, string password)
        {
            return UserDAO.Instance.Login(email, password);
        }
    }
}

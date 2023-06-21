using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsersList();
        public User Login(string email, string password);
        public User GetUserById(int userId);
        public User GetUserByEmail(string email);
        public void AddUser(User c);
        public bool UpdateUser(User user);


	}
}

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
        public void AddUser(User c)
        {
            UserDAO.Instance.AddUser(c);    
        }

        public User GetUserByEmail(string email)
        {
            return UserDAO.Instance.GetUserByEmail(email);  
        }

        public User GetUserById(int userId)
        {
           return UserDAO.Instance.GetUserById(userId);
        }

        public IEnumerable<User> GetUsersList()
        {
            return UserDAO.Instance.GetUsersList();
        }

        public User Login(string email, string password)
        {
            return UserDAO.Instance.Login(email, password);
        }
		public bool UpdateUser(User user)
        {
            return UserDAO.Instance.UpdateUser(user);
        }

	}
}

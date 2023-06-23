using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccess
{
    public class UserDAO
    {
        // Using Singleton Pattern
        private static UserDAO instance = null;
        private static object instanceLook = new object();

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<User> GetUsersList()
        {
            IEnumerable<User> users = null;

            try
            {
                var context = new BirdMealContext();
                // Get From Database
                users = context.Users;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return users;
        }

        public User Login(string email, string password)
        {
            IEnumerable<User> users = GetUsersList();
            User user = users.SingleOrDefault(mb => mb.Email.Equals(email) && mb.Password.Equals(password));
            return user;
        }

        public User GetUserById(int userId)
        {
            User cus = null;

            try
            {

                var context = new BirdMealContext();
                cus = context.Users.Include(c => c.Wallet)
                    .SingleOrDefault(f => f.UserId == userId);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cus;
        }

        public User GetUserByEmail(string email)
        {
            User cus = null;

            try
            {

                var context = new BirdMealContext();
                cus = context.Users
                    .Include(w => w.Wallet)
                    .SingleOrDefault(f => f.Email.Equals(email.Trim()));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cus;
        }

        public void AddUser(User c)
        {

            try
            {
                var context = new BirdMealContext();
                context.Users.Add(c);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


		public bool UpdateUser(User user)
		{
			try
			{
				using (var context = new BirdMealContext())
				{
					context.Users.Update(user);
					context.SaveChanges();
				}
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred while update the user: {ex.Message}");
				return false;
			}
		}

	}

}

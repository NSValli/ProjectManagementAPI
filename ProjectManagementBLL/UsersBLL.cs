using ProjectManagementDAL;
using ProjectManagementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBLL
{
    public class UsersBLL
    {
        public List<User> GetAll()
        {
            UserDAL userDAL = new UserDAL();
            return (userDAL.GetAllUser());
        }

        public User Get(int userId)
        {
            UserDAL userDAL = new UserDAL();
            return (userDAL.GetUser(userId));
        }

        public void CreateUser(User user)
        {
            UserDAL userDAL = new UserDAL();
            userDAL.CreateUser(user);
        }

        public void UpdateUser(User user)
        {
            UserDAL userDAL = new UserDAL();
            userDAL.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            UserDAL userDAL = new UserDAL();
            userDAL.DeleteUser(userId);           
        }
    }
}

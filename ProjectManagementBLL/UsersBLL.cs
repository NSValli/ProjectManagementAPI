using ProjectManagementDAL;
using ProjectManagementDAL.Models;
using System.Collections.Generic;

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

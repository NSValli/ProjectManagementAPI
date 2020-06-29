using AutoMapper;
using ProjectManagementDAL.Entities;
using ProjectManagementDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = ProjectManagementDAL.Models.User;
using UserEntity = ProjectManagementDAL.Entities.User;

namespace ProjectManagementDAL
{
    public class UserDAL
    {
        MapperConfiguration mapperConfig;
        public UserDAL()
        {
            //Initialize the mapper
            mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserEntity>();
                cfg.CreateMap<UserEntity, User>();
            });
        }
        public List<User> GetAllUser()
        {
            ProjectManagementContext userContext = new ProjectManagementContext();
            var users = (from s in userContext.Users
                         orderby s.FirstName
                         select s);
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<List<User>>(users);
        }

        public User GetUser(int userId)
        {
            ProjectManagementContext userContext = new ProjectManagementContext();
            var user = userContext.Users
             .SingleOrDefault(up => up.UserID == userId);
            var mapper = new Mapper(mapperConfig);
            return (mapper.Map<User>(user));
        }

        public void CreateUser(User user)
        {
            ProjectManagementContext userContext = new ProjectManagementContext();
            var mapper = mapperConfig.CreateMapper();           
            var userEntity = mapper.Map<UserEntity>(user);         
            userContext.Users.Add(userEntity);
            userContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            ProjectManagementContext userContext = new ProjectManagementContext();
            var userData = userContext.Users.Find(user.UserID);
            if (userData != null)
            {
                userData.FirstName = user.FirstName;
                userData.LastName = user.LastName;
                userData.EmployeeID = user.EmployeeID;               
                userContext.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            ProjectManagementContext userContext = new ProjectManagementContext();
            var user = userContext.Users
             .SingleOrDefault(up => up.UserID == userId);
            userContext.Users.Remove(user);
            userContext.SaveChanges();
        }

    }
}

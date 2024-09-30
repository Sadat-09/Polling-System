using AutoMapper;
using BLL.DTOs;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });
            return new Mapper(config);
        }

        public static bool Register(UserDTO obj)
        {
            var data = GetMapper().Map<User>(obj);
            return DataAccess.UserData().Create(data);
        }

        public static UserDTO Login(string UserName, string password)
        {
            var user = DataAccess.UserRepoData().GetByUsernameAndPassword(UserName, password);
            if (user != null)
            {
                return GetMapper().Map<UserDTO>(user); 
            }
            return null;
        }


    }
}

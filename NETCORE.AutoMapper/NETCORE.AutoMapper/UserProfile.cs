using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<UserInfo, UserInfoModel>();
            CreateMap<UserInfoModel, UserInfo>();
        }
    }

    internal class UserInfo
    {
    }

    internal class UserInfoModel
    {
    }
}

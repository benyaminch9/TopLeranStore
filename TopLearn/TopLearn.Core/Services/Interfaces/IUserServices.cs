using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Web.Models.User;

namespace TopLearn.Core.Services.Interfaces
{
    internal interface IUserServices 
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        int AddUser(User user);
    }
}

using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.Web.Models.User;

namespace TopLearn.Core.Services
{
    public class UserServices : IUserServices
    {
        private TopLearnContext _context;
        public UserServices(TopLearnContext context)
        {
            _context= context;
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public int AddUser(User user)
        {
            throw new NotImplementedException();
        }


    }
}

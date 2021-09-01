using Data.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDataAccess
    {
        public User Authentication(StringValues values, User user)
        {
            var authHeader = AuthenticationHeaderValue.Parse(values.First());
            var tokenBytes = Convert.FromBase64String(authHeader.Parameter);
            var tokenSplit = Encoding.UTF8.GetString(tokenBytes).Split(new[] { ':' }, 2);
            var username = tokenSplit[0];
            var password = tokenSplit[1];

            using (UnitOfWork.UnitOfWork _userService = new UnitOfWork.UnitOfWork())
            {
                var user1 = _userService.GetRepository<User>().GetAll().ToList();
                user = user1.SingleOrDefault(x => x.UserName == username && x.Password == password);
                return user;
            }
        }
    }
}

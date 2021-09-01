using Data.Models;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Business;

namespace NtierWithEntityFrameWork.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserBus userBus = new();
        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = null;
                using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                 users =  unitOfWork.GetRepository<User>().GetAll().ToList();
                
            }
            return Ok(users);
        }
        [HttpGet("GetByUser")]
        public IActionResult GetById()
        {
            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                StringValues values;
                Request.Headers.TryGetValue("Authorization", out values);

                return Ok(userBus.Authentication(values));

            }
        }
    }
}

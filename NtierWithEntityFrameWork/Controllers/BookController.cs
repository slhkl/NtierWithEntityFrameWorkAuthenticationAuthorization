using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace NtierWithEntityFrameWork.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookBus bookBus = new BookBus();
        [HttpGet("Get")]
        public IActionResult GetAll()
        {
           return Ok(bookBus.GetAll());
        }
        [HttpGet("GetWith")]
        public IActionResult GetAllWithCondiction(string name)
        {
            return Ok(bookBus.GetAllWithCondiction(name));
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(bookBus.Get(id));
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add(Book book)
        {
            return Ok(bookBus.Add(book));
        }
        [HttpPut]
        public IActionResult Update(Book book)
        {
            return Ok(bookBus.Update(book));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(bookBus.Delete(id));
        }

    }
}

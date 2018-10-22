﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsCrete.Data;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using CarsCrete.Data.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarsCrete.Controllers
{
    
    [Route("[controller]")]
    public class CarsController : Controller
    {
        #region Private Fields
        private CarsDbContext DbContext;
        #endregion
        #region Constructor
        public CarsController(CarsDbContext context)
        {
            // Instantiate the ApplicationDbContext through DI
            DbContext = context;
        }
        #endregion Constructor
        // GET: /<controller>/
        public class UserEntrance
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        [HttpGet("get-user")]
        public IActionResult GetUser(UserEntrance user1)
        {
            
            var user = DbContext.Users.Where(x => x.Email == user1.Email).Include(x => x.Reports).Include(x => x.Books).FirstOrDefault();
            if (user == null)
            {
                return new StatusCodeResult(500);
            }
            if(user.Password != user1.Password)
            {
                return new StatusCodeResult(501);
            }
            return new JsonResult(
                user.Adapt<UserDTO>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
        public class UserReg
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPut("add-user")]
        public IActionResult AddUser([FromBody]UserReg model)
        {
            if (DbContext.Users.Where(x => x.Email == model.Email).ToArray().Length > 0)
            {
                return new StatusCodeResult(500);
            }
            var user = new User()
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            DbContext.Users.Add(user);
            user.Books = new List<Book>();
            user.Reports = new List<FeedBack>();
            DbContext.SaveChanges();

            return new JsonResult(
                user.Adapt<UserDTO>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
        
        public class UserPassword
        {
            public long Id { get; set; }
            public string Password { get; set; }
        }
        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody]UserPassword model)
        {

            var user = DbContext.Users.Where(x => x.Id == model.Id).FirstOrDefault();
            user.Password = model.Password;
            user.ModifiedDate = DateTime.Now;
            DbContext.SaveChanges();

            return new JsonResult(
                user.Adapt<UserDTO>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }

        [HttpPut("add-booking")]
        public IActionResult AddBooking([FromBody]BookDTO model)
        {

            var book = model.Adapt<Book>();
            DbContext.Books.Add(book);
            DbContext.SaveChanges();

            return new JsonResult(
                book.Adapt<BookDTO>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
        [HttpGet("get-book/{id}")]
        public IActionResult GetBook(long Id)
        {

            var book = DbContext.Books.Where(x => x.Id == Id).FirstOrDefault();

            return new JsonResult(
                book.Adapt<BookDTO>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
        [HttpGet("get-car/{id}")]
        public IActionResult GetCar(long Id)
        {

            var car = DbContext.Cars.Where(x => x.Id == Id).FirstOrDefault();

            return new JsonResult(
                car.Adapt<CarDTO>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
        [HttpPut("add-car")]
        public IActionResult AddCar()
        {

            var car = new Car()
            {
                Model = "WV Golf",
                Photo = "../../assets/images/VW_golf_7.jpg",
                Passengers = 5,
                Doors=5,
                Transmission="Механика",
                Fuel="Бензин",
                Consumption="8 литров на 100км",
                Description= "Автомобиль с АКПП, 1,2 литра, 80 лошадиных сил. Кондционер, радио-CD, расход топлива 7 литров/100 км. В машину свободно входят четыре взрослых пассажира, 2 большие дорожные сумки.",
                Price=35

            };
            DbContext.Cars.Add(car);
            
            
            DbContext.SaveChanges();

            return new JsonResult(
                car.Adapt<CarDTO>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }

        [HttpGet("get-cars")]
        public IActionResult GetCars()
        {

            var car = DbContext.Cars.Include(x => x.Reports).ToArray();

            return new JsonResult(
                car.Adapt<CarDTO[]>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }

        [HttpGet("get-reports")]
        public IActionResult GetReports()
        {

            var reports = DbContext.Reports.ToArray();

            return new JsonResult(
                reports.Adapt<FeedBackDTO[]>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
        [HttpPut("add-report")]
        public IActionResult AddReport([FromBody]FeedBackDTO model)
        {

            var report = model.Adapt<FeedBack>();
            DbContext.Reports.Add(report);
            DbContext.SaveChanges();

            return new JsonResult(
                report.Adapt<FeedBackDTO>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
    }
}

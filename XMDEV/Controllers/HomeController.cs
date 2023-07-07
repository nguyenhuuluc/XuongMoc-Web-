using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using XMDEV.Entities;
using XMDEV.Models;

namespace XMDEV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;
        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
        public IActionResult GetList()
        {
            var data = _dbContext.ProductEntities.
                Where(x => x.IsDeleted == false).ToList();
            return Ok(data);
        }
        public IActionResult GetUser()
        {
            var dataUser = _dbContext.UserEntities.ToList();
            return Ok(dataUser);
        }
        
        [HttpPost]
        public IActionResult AddUser([FromBody] User model)
        {
            var addU = new UserEntity()
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Pass = model.Pass
            };
            _dbContext.UserEntities.Add(addU);
            var status = _dbContext.SaveChanges();
            return Ok(status);
        }

        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            var data = _dbContext.ProductEntities
                .Where(x => x.Id == id).ToList();
            return Ok(data);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
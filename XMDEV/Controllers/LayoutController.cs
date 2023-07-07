using Microsoft.AspNetCore.Mvc;
using XMDEV.Entities;

namespace XMDEV.Controllers
{
    public class LayoutController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;

        public LayoutController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public IActionResult GetList()
        {
            var data = _dbContext.ProductEntities.
                Where(x => x.IsDeleted == false).ToList();
            return Ok(data);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GioiThieu()
        {
            return View();
        }
        public IActionResult SanPham()
        {
            return View();
        }
        public IActionResult DoiTac()
        {
            return View();
        }
        public IActionResult TinTuc()
        {
            return View();
        }
        public IActionResult LienHe()
        {
            return View();
        }
        public IActionResult ChiTietSP()
        {
            return View();
        }
        public IActionResult GtTest()
        {
            return View();
        }
    }
}

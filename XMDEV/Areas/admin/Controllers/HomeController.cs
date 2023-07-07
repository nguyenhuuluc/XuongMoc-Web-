using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XMDEV.Entities;
using XMDEV.Models;

namespace XMDEV.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext _dbContext;
        public HomeController(IWebHostEnvironment environment, AppDbContext dbContext)
        {
            _environment = environment;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPrd()
        {
            return View();
        }
        public IActionResult EditPrd()
        {
            return View();
        }
        public IActionResult GetList()
        {
            var data = _dbContext.ProductEntities.
                Where(x => x.IsDeleted == false).ToList();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product model)
        {
            if (model.Id > 0)
            {
                var entity = _dbContext.ProductEntities.Find(model.Id);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Price = model.Price;
                    entity.Description = model.Description;
                    entity.Image = model.Image;
                    entity.ChatLieu = model.ChatLieu;
                    entity.KichThuoc = model.KichThuoc;
                    entity.MauSacBan = model.MauSacBan;
                    entity.BaoHanh = model.BaoHanh;
                    entity.UpdatedDate = DateTime.Now;
                    _dbContext.ProductEntities.Update(entity);
                }
            }
            else
            {
                var entity = new ProductEntity()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    Image = model.Image,
                    ChatLieu = model.ChatLieu,
                    KichThuoc = model.KichThuoc,
                    MauSacBan = model.MauSacBan,
                    BaoHanh = model.BaoHanh,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsActive = true
                };
                _dbContext.ProductEntities.Add(entity);
            }

            var status = _dbContext.SaveChanges();
            return Ok(status);
        }

        [HttpDelete]
        public IActionResult Delete(Product model)
        {
            var entity = _dbContext.ProductEntities.Find(model.Id);
            if (entity != null)
            {
                _dbContext.ProductEntities.Remove(entity);
            }
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
    }
}

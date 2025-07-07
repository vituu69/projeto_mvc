using Microsoft.AspNetCore.Mvc;
using WebProjct.Data;
using WebProjct.Models;
using WebProjct.Service;

namespace WebProjct.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }


        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _sellerService.FindAllDepartments();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // previne ataques xsrf/csrf
        public IActionResult Create(Seller seller)
        {
            _sellerService.Inserts(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ApagarConfirmacao(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = _sellerService.FindById(id.Value);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller); // envia o seller como modelo
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ApagarConfirmacao(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
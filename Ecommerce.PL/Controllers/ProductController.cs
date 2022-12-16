using AutoMapper;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Models;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGenericRepository<Product> genericRepository;
        private readonly IGenericRepository<OrderProduct> orderProduct;
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductController(IGenericRepository<Product> genericRepository , IGenericRepository<OrderProduct> orderProduct , IProductRepository repository , IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.orderProduct = orderProduct;
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var Data = await genericRepository.GetAll();
            return View(mapper.Map<IEnumerable<ProductViewModel>>(Data));
        }
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
                return NotFound();
            var Data = await genericRepository.GetById(Id);
            if (Data == null)
                return NotFound();
            return View(mapper.Map<ProductViewModel>(Data));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await genericRepository.Update(mapper.Map<Product>(model));
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
                return NotFound();
            var Data = await genericRepository.GetById(Id);
            if (Data == null)
                return NotFound();

            await genericRepository.Delete(Data);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
                return NotFound();
            var Data = await genericRepository.GetById(Id);
            return View(mapper.Map<ProductViewModel>(Data));
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await genericRepository.Update(mapper.Map<Product>(product));
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        public async Task<IActionResult> InStock()
        {
            var data = await genericRepository.GetAll();
            return View();
        }
        [HttpPost]
        public JsonResult Instock(int? Id)
        {
            var data = repository.ProductsInStock(Id);
            return Json(data);
        }
    }
}

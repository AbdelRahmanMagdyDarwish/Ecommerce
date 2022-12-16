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
    public class OrderController : Controller
    {
        private readonly IGenericRepository<Order> genericRepository;
        private readonly IGenericRepository<OrderProduct> generic;
        private readonly IOrderProduct orderProduct;
        private readonly IMapper mapper;

        public OrderController(IGenericRepository<Order> genericRepository,IGenericRepository<OrderProduct> generic,IOrderProduct orderProduct , IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.generic = generic;
            this.orderProduct = orderProduct;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index() 
        {
            var Data = await genericRepository.GetAll();
            return  View(mapper.Map<IEnumerable<OrderViewModel>>(Data));
        }
        public async Task<IActionResult> Details(int ? Id)
        {
            if(Id== null)
                return NotFound();
            var Data = await genericRepository.GetById(Id);
            if(Data == null)
                return NotFound();
            return View(mapper.Map<OrderViewModel>(Data));
        }
        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                var Data = await genericRepository.Create(mapper.Map<Order>(order));
                foreach (var item in order.ProductId)
                {
                    orderProduct.Create(Data, item);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int ? Id)
        {
            if (Id== null)
                return NotFound();
            var Data = await genericRepository.GetById(Id);
            if(Data == null)
                return NotFound();

            await genericRepository.Delete(Data);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
                return NotFound();
            var Data = await genericRepository.GetById(Id);
            return View(mapper.Map<OrderViewModel>(Data));
        }
        [HttpPost]
        public async Task<IActionResult> Update(OrderViewModel order)
        {
            if(ModelState.IsValid)
            {
               await genericRepository.Update(mapper.Map<Order>(order));
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }
    }
}

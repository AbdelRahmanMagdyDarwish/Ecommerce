using AutoMapper;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Models;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PL.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IGenericRepository<Customer> genericRepository;
        private readonly IMapper mapper;

        public CustomerController(IGenericRepository<Customer> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var Data = await genericRepository.GetAll();
            return View(mapper.Map<IEnumerable<CustomerViewModel>>(Data));
        }
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
                return NotFound();
            var Data = await genericRepository.GetById(Id);
            if (Data == null)
                return NotFound();
            return View(mapper.Map<CustomerViewModel>(Data));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var Data = await genericRepository.Create(mapper.Map<Customer>(customer));
                
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        [HttpPost]
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
            return View(mapper.Map<CustomerViewModel>(Data));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                await genericRepository.Update(mapper.Map<Customer>(customer));
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagementSystem.Models;
using CustomerManagementSystem.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IHostingEnvironment _environment;

        public HomeController(ICustomerRepository customerRepository, IHostingEnvironment environment)
        {
            _customerRepository = customerRepository;
            this._environment = environment;
        }

        public ViewResult WebUI()
        {
            var listOfCustomers = _customerRepository.GetListOfCustomers();
            return View(listOfCustomers);
        }

        public ViewResult PrintDetails(int? id)
        {
            Customer customer = _customerRepository.GetCustomer(id.Value);
            if (customer == null)
            {
                Response.StatusCode = 404;
                return View("../ErrorHandler/CustomerNotFound", id.Value);
            }
            PrintDetailsViewModel model = new PrintDetailsViewModel()
            {
                Customer = customer,
                PageTitle = "Customer Details"
            };

            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerEditViewModel model)
        {
            string uniqueFile = null;
            if (ModelState.IsValid)
            {
                if (model.Photo != null)
                {
                    string folderPath = Path.Combine(_environment.WebRootPath, "images");
                    uniqueFile = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(folderPath, uniqueFile);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Customer newCustomer = new Customer()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Gender = model.Gender,
                    PhotoPath = uniqueFile
                };
                _customerRepository.AddNewCustomer(newCustomer);
                return RedirectToAction("PrintDetails", new { id = newCustomer.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Edit(Customer customer)
        {
            return View();
        }
        //[HttpPost]
        //public ViewResult Edit(Customer model)
        //{
        //    return View();
        //}
    }
}

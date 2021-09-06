using Microsoft.AspNetCore.Mvc;
using PasteryShop.Data;
using PasteryShop.Data.Entities;
using PasteryShop.Services;
using PasteryShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasteryShop.Controllers
{
    public class AppController : Controller
    {

        private readonly IMailService _mailService;
        private readonly IPasteryShopRepository _repo;
        //private readonly PasteryShopContext _ctx;



        public AppController(IMailService mailService,IPasteryShopRepository repo)
        {
            _mailService = mailService;
            _repo = repo;
            //_ctx = ctx;

        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the Email
                _mailService.SendMessage("r@google.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent...";
                ModelState.Clear();
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Shop()
        {
            //var results = from p in _ctx.Products
            //              orderby p.ArtistBirthDate
            //              select p;

            var results=_repo.GetAllProduct();

            return View(results);
        }

    
    }
}


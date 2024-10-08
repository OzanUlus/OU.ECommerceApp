﻿using ECommerce.WebUı.Services.CatalogServices.ContactServices;
using EECommerceApp.DtoLayer.CatologDtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUı.Controllers
{
    public class ContactController : Controller
    {
       private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index() 
        {
         return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {

            createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Now;
            await _contactService.CreateContactAsync(createContactDto);

            return RedirectToAction("Index", "Default");

            
        }
    }
}

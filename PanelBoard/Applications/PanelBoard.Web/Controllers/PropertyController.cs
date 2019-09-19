using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PanelBoard.Web.Controllers
{
    using Data.Entities;
    using Data.Services;
    public class PropertyController : Controller
    {
        private readonly PropertyService _propertyService;
        public PropertyController(PropertyService property)
        {
            _propertyService = property;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Property model)
        {
            _propertyService.AddCustom(model);


            _propertyService.Save();

            return View();
        }
    }
}
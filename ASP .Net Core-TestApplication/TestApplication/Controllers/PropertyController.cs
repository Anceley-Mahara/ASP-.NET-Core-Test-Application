using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Models;
using TestApplication.Services;
using Microsoft.Extensions.Logging;

namespace TestApplication.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertiesApiService _propertiesApiService;

        public PropertyController(IPropertiesApiService propertiesApiService)
        {
            _propertiesApiService = propertiesApiService;
        }

        public async Task<IActionResult> Index(string searchQuery)
        {
            List<PropertyModel> searchResponse;
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchResponse = await _propertiesApiService.searchProperties(searchQuery);
            }
            return View(searchResponse);
        }
    }
}
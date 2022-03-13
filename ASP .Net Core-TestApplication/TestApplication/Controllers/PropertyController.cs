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
        private readonly ILogger<PropertyController> _logger;

        public PropertyController(IPropertiesApiService propertiesApiService, ILogger<PropertyController> logger)
        {
            _propertiesApiService = propertiesApiService;
            _logger = logger;
        }
        [System.Web.Mvc.ValidateInput(true)]
        public async Task<IActionResult> Index(string searchQuery)
        {
            List<PropertyModel> searchResponse = new List<PropertyModel>();
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchResponse = await _propertiesApiService.searchProperties(searchQuery);
            }
          
            return View(searchResponse);
        }
    }
}
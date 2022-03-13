using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Models;
using TestApplication.Services;

namespace TestApplication.Controllers
{
    public class ManagementController : Controller
    {
        private readonly IManagementApiService _managementApiService;

        public ManagementController(IManagementApiService managementApiService)
        {
            _managementApiService = managementApiService;
        }

        [System.Web.Mvc.ValidateInput(true)]
        public async Task<IActionResult> Index(string searchString)
        {
            List<ManagementModel> searchResponse = new List<ManagementModel>();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchResponse = await _managementApiService.searchManagement(searchString);
            }
            return View(searchResponse);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication.Services
{
    public interface IManagementApiService
    {
        Task<List<ManagementModel>> searchManagement(string searchString);
    }
}

using EmployeeManagement.Models;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IOptions<AppConfig> _config;
        private readonly IWebHostEnvironment _hostEnvironment;
        private string _baseUrl;
        private Response _response;

        public DepartmentController(ILogger<EmployeeController> logger, IOptions<AppConfig> config, IWebHostEnvironment hostEnvironment)
        {
            this._logger = logger;
            this._config = config;
            this._baseUrl = _config.Value.ApiUrl;
            this._hostEnvironment = hostEnvironment;
            _response = new Response();
        }

        public async Task<IActionResult> Index()
        {
            _response = await HTTPClientWrapper<Response>.Get($"{_baseUrl}{APIUrls.GetDepartments}");
            var departments = JsonConvert.DeserializeObject<List<EmployeeService.Models.Department>>(_response.Data.ToString());
            return View(departments);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartment(int id)
        {
            _response = await HTTPClientWrapper<Response>.Get($"{_baseUrl}{APIUrls.GetDepartment}{id}");
            var department = JsonConvert.DeserializeObject<EmployeeService.Models.Department>(_response.Data.ToString());
            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            _response = await HTTPClientWrapper<Response>.Get($"{_baseUrl}{APIUrls.GetDepartments}");
            var departments = JsonConvert.DeserializeObject<List<EmployeeService.Models.Department>>(_response.Data.ToString());
            return View(departments);
        }

        [HttpGet]
        public async Task<IActionResult> EditDepartment(int id)
        {
            _response = await HTTPClientWrapper<Response>.Get($"{_baseUrl}{APIUrls.GetDepartment}{id}");
            var department = JsonConvert.DeserializeObject<EmployeeService.Models.Department>(Convert.ToString(_response.Data));

            if (department == null)
                department = new EmployeeService.Models.Department();

            return View("DepartmentAddEdit", department);
        }

        [HttpPost]
        public async Task<IActionResult> EditDepartment(EmployeeService.Models.Department department)
        {
            if (ModelState.IsValid)
            {
                _response = await HTTPClientWrapper<Response>.PostRequest($"{_baseUrl}{APIUrls.AddEditDepartment}", department);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            _response = await HTTPClientWrapper<Response>.DeleteRequest($"{_baseUrl}{APIUrls.DeleteDepartment}{id}");
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

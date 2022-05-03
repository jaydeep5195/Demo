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
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IOptions<AppConfig> _config;
        private readonly IWebHostEnvironment _hostEnvironment;
        private string _baseUrl;
        private Response _response;

        public EmployeeController(ILogger<EmployeeController> logger, IOptions<AppConfig> config, IWebHostEnvironment hostEnvironment)
        {
            this._logger = logger;
            this._config = config;
            this._baseUrl = _config.Value.ApiUrl;
            this._hostEnvironment = hostEnvironment;
            _response = new Response();
        }

        public async Task<IActionResult> Index()
        {
            _response = await HTTPClientWrapper<Response>.Get($"{_baseUrl}{APIUrls.GetEmployees}");
            var employees = JsonConvert.DeserializeObject<List<EmployeeService.Models.Employee>>(_response.Data.ToString());
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee(int id)
        {
            _response = await HTTPClientWrapper<Response>.Get($"{_baseUrl}{APIUrls.GetEmployee}{id}");
            var employee = JsonConvert.DeserializeObject<EmployeeService.Models.Employee>(_response.Data.ToString());
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            _response = await HTTPClientWrapper<Response>.Get($"{_baseUrl}{APIUrls.GetDepartments}");
            var departments = JsonConvert.DeserializeObject<List<EmployeeService.Models.Department>>(_response.Data.ToString());
            return View(departments);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            _response = await HTTPClientWrapper<Response>.Get($"{_baseUrl}{APIUrls.GetEmployee}{id}");
            var employee = JsonConvert.DeserializeObject<EmployeeService.Models.Employee>(Convert.ToString(_response.Data));

            if (employee == null)
                employee = new EmployeeService.Models.Employee();

            _response = new Response();
            _response = await HTTPClientWrapper<Response>.Get($"{_baseUrl}{APIUrls.GetDepartments}");
            var departments = JsonConvert.DeserializeObject<List<EmployeeService.Models.Department>>(_response.Data.ToString());
            SelectList selectList = new SelectList(departments, "DepartmentId", "Name", employee.DepartmentId);
            ViewData["Departments"] = selectList;
            return View("EmployeeAddEdit", employee);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeService.Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < HttpContext.Request.Form.Files.Count; i++)
                {
                    IFormFile file = HttpContext.Request.Form.Files[i];

                    //Save image to wwwroot/image
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    fileName = "/images/" + fileName + DateTime.Now.ToString("yymmssfff") + extension;

                    string path = Path.Combine(wwwRootPath + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    employee.PhotoUrl = fileName;
                }
                _response = await HTTPClientWrapper<Response>.PostRequest($"{_baseUrl}{APIUrls.AddEditEmployees}", employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _response = await HTTPClientWrapper<Response>.DeleteRequest($"{_baseUrl}{APIUrls.DeleteEmployee}{id}");
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

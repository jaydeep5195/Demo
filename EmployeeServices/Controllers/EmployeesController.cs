using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeServices.Common;
using Microsoft.EntityFrameworkCore;
using EmployeeServices.ContextClass;
using Newtonsoft.Json;
using Common;
using AutoMapper;

namespace EmployeeServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {

        private readonly ILogger<EmployeesController> _logger;
        private EmployeeManagementContext _empContext;
        private Response _response;

        public EmployeesController(ILogger<EmployeesController> logger, EmployeeManagementContext context)
        {
            _logger = logger;
            _empContext = context;
            _response = new Response();
        }

        [HttpPost]
        [Route("AddEmployees")]
        public async Task<Response> AddEmployeesAsync([FromBody] EmployeeService.Models.Employee reqData)
        {
            try
            {
                Common.Employee employee = new Employee
                {
                    EmployeeId = reqData.EmployeeId,
                    Firstname = reqData.Firstname,
                    Lastname = reqData.Lastname,
                    Email = reqData.Email,
                    Phone = reqData.Phone,
                    Biodata = reqData.Biodata,
                    PhotoUrl = reqData.PhotoUrl,
                    Salary = reqData.Salary,
                    DepartmentId = reqData.DepartmentId,
                    CreatedOn = DateTime.Now
                };

                this._empContext.Add(employee);
                await this._empContext.SaveChangesAsync();

                _response.Status = true;

            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = ex.InnerException.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetEmployees")]
        public async Task<Response> GetEmployeesAsync()
        {
            try
            {
                var departments = _empContext.Departments.AsEnumerable<Department>();
                var response = _empContext.Employees.AsEnumerable<Employee>();
                var employees = ConvertTo.Convert<List<Common.Employee>, List<EmployeeService.Models.Employee>>(response?.ToList());
                employees.ForEach(x => x.DepartmentName = departments.Where(d => d.DepartmentId == x.DepartmentId).FirstOrDefault().Name);

                _response.Data = employees;
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = ex.InnerException.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<Response> GetEmployeeAsync(int id)
        {
            try
            {
                var res = _empContext.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
                _response.Data = ConvertTo.Convert<Common.Employee, EmployeeService.Models.Employee>(res);
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = ex.InnerException.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public async Task<Response> UpdateEmployeeAsync([FromBody] EmployeeService.Models.Employee reqData)
        {
            try
            {
                Common.Employee employee = new Employee
                {
                    EmployeeId = reqData.EmployeeId,
                    Firstname = reqData.Firstname,
                    Lastname = reqData.Lastname,
                    Email = reqData.Email,
                    Phone = reqData.Phone,
                    Biodata = reqData.Biodata,
                    PhotoUrl = reqData.PhotoUrl,
                    Salary = reqData.Salary,
                    DepartmentId = reqData.DepartmentId,
                    UpdatedOn = DateTime.Now
                };

                this._empContext.Update(employee);
                await this._empContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = ex.InnerException.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<Response> DeleteEmployeeAsync([FromQuery] int id)
        {
            try
            {
                var employee = this._empContext.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
                if (employee != null)
                {
                    this._empContext.Remove(employee);
                    await this._empContext.SaveChangesAsync();
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "No Record(s) found";
                }
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = ex.InnerException.Message;
            }
            return _response;
        }
    }
}

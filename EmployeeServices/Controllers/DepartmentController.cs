using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using EmployeeServices.Common;
using EmployeeServices.ContextClass;
using Common;

namespace Departmentservices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {

        private readonly ILogger<DepartmentsController> _logger;
        private EmployeeManagementContext _empContext;
        private Response _response;

        public DepartmentsController(ILogger<DepartmentsController> logger, EmployeeManagementContext context)
        {
            _logger = logger;
            _empContext = context;
            _response = new Response();
        }

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<Response> AddDepartmentAsync([FromBody] EmployeeService.Models.Department reqData)
        {
            try
            {
                EmployeeServices.Common.Department department = new Department
                {
                    DepartmentId = reqData.DepartmentId,
                    Name = reqData.Name,
                    Description = reqData.Description,
                    CreatedOn = DateTime.Now
                };

                this._empContext.Add(department);
                await this._empContext.SaveChangesAsync();

                _response.Status = true;

            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetDepartments")]
        public async Task<Response> GetDepartmentsAsync()
        {
            try
            {
                var departments = _empContext.Departments.AsEnumerable<Department>()?.ToList();
                _response.Data = ConvertTo.Convert<List<EmployeeServices.Common.Department>, List<EmployeeService.Models.Department>>(departments);
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetDepartment")]
        public async Task<Response> GetDepartmentAsync(int id)
        {
            try
            {
                var department = _empContext.Departments.Where(e => e.DepartmentId == id).FirstOrDefault();
                _response.Data = ConvertTo.Convert<EmployeeServices.Common.Department, EmployeeService.Models.Department>(department);
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("UpdateDepartment")]
        public async Task<Response> UpdateDepartmentAsync([FromBody] EmployeeService.Models.Department reqData)
        {
            try
            {
                EmployeeServices.Common.Department department = new Department
                {
                    DepartmentId = reqData.DepartmentId,
                    Name = reqData.Name,
                    Description = reqData.Description,
                    UpdatedOn = DateTime.Now
                };

                this._empContext.Update(department);
                await this._empContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("DeleteDepartment")]
        public async Task<Response> DeleteDepartmentAsync([FromQuery] int id)
        {
            try
            {
                var department = this._empContext.Departments.Where(d => d.DepartmentId == id).FirstOrDefault();
                if (department != null)
                {
                    this._empContext.Remove(department);
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
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}

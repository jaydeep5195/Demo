using System;
using System.Collections.Generic;

#nullable disable

namespace Common
{
    public class APIUrls
    {
        #region Employee EndPoints
        public static string AddEditEmployees = "/api/Employees/UpdateEmployee";
        public static string GetEmployees = "/api/Employees/GetEmployees";
        public static string GetEmployee = "/api/Employees/GetEmployee?id=";
        public static string DeleteEmployee = "/api/Employees/DeleteEmployee?id=";
        //public static string UpdateEmployee = "/api/Employees/UpdateEmployee";
        #endregion

        #region Department EndPoints
        public static string GetDepartments = "/api/Departments/GetDepartments";
        public static string GetDepartment = "/api/Departments/GetDepartment?id=";
        public static string AddEditDepartment = "/api/Departments/UpdateDepartment";
        public static string DeleteDepartment = "/api/Departments/DeleteDepartment?id=";
        //public static string UpdateDepartment = "/api/Departments/UpdateDepartment";
        #endregion
    }
}

#pragma checksum "C:\Users\MM153\source\repos\EmployeeManagement\Views\Department\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c16cccc1dc07174038dbfbec3eb9501b3972a031"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Department_Index), @"mvc.1.0.view", @"/Views/Department/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\MM153\source\repos\EmployeeManagement\Views\_ViewImports.cshtml"
using EmployeeManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MM153\source\repos\EmployeeManagement\Views\_ViewImports.cshtml"
using EmployeeManagement.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\MM153\source\repos\EmployeeManagement\Views\Department\Index.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c16cccc1dc07174038dbfbec3eb9501b3972a031", @"/Views/Department/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3af35a328bfe0c906f75d04efeba14f80e1f583b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Department_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EmployeeService.Models.Department>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\MM153\source\repos\EmployeeManagement\Views\Department\Index.cshtml"
  
    var employees = Model;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-6 text-left\">\r\n        <h6>Department List</h6>\r\n    </div>\r\n    <div class=\"col-6 text-right text-dark\">\r\n        ");
#nullable restore
#line 11 "C:\Users\MM153\source\repos\EmployeeManagement\Views\Department\Index.cshtml"
   Write(Html.ActionLink("Add New", "EditDepartment", "Department"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
</div>
<div id=""dv-employeeList"">
    <table class=""table table-bordered"">
        <tbody>
            <tr>
                <th class=""d-none"">DepartmentId</th>
                <th>Name</th>
                <th>Description</th>
                <th></th>
            </tr>
        </tbody>
        <tbody>
");
#nullable restore
#line 25 "C:\Users\MM153\source\repos\EmployeeManagement\Views\Department\Index.cshtml"
              
                if (employees != null)
                {
                    foreach (var item in employees)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td class=\"d-none\">");
#nullable restore
#line 31 "C:\Users\MM153\source\repos\EmployeeManagement\Views\Department\Index.cshtml"
                                          Write(item.DepartmentId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 32 "C:\Users\MM153\source\repos\EmployeeManagement\Views\Department\Index.cshtml"
                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 33 "C:\Users\MM153\source\repos\EmployeeManagement\Views\Department\Index.cshtml"
                           Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 35 "C:\Users\MM153\source\repos\EmployeeManagement\Views\Department\Index.cshtml"
                           Write(Html.ActionLink("Edit", "EditDepartment", "Department", new { id = item.DepartmentId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                &nbsp;\r\n                                ");
#nullable restore
#line 37 "C:\Users\MM153\source\repos\EmployeeManagement\Views\Department\Index.cshtml"
                           Write(Html.ActionLink("Delete", "DeleteDepartment", "Department", new { id = item.DepartmentId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 40 "C:\Users\MM153\source\repos\EmployeeManagement\Views\Department\Index.cshtml"
                    }
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EmployeeService.Models.Department>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
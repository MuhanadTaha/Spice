#pragma checksum "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a1f47b5fa0a5d35aa9e6c6e06f72940904029e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\_ViewImports.cshtml"
using Spice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\_ViewImports.cshtml"
using Spice.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\_ViewImports.cshtml"
using Spice.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a1f47b5fa0a5d35aa9e6c6e06f72940904029e1", @"/Areas/Customer/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09654336be93d6276cd7f8fb1d42088785cf89a3", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n\r\n");
#nullable restore
#line 9 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"
 if (Model.Coupons.Count() > 0) 
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"border row\">\r\n        <div class=\"carousel\" data-ride=\"carousel\" data-interval=\"2500\">\r\n\r\n");
#nullable restore
#line 14 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"
             for (int i = 0; i < Model.Coupons.Count(); i++)
            {
                var base64 = Convert.ToBase64String(Model.Coupons.ToList()[i].Picture); //لازم أحول الصورة من بايت لنص
                var imgsrc = string.Format("data:image/jpeg;base64,{0}", base64);

                if (i == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"carousel-item active\"> ");
            WriteLiteral("\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 713, "\"", 726, 1);
#nullable restore
#line 22 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"
WriteAttributeValue("", 719, imgsrc, 719, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"50px\" class=\"d-block w-100\" />\r\n                    </div>\r\n");
#nullable restore
#line 24 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"carousel-item\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 933, "\"", 946, 1);
#nullable restore
#line 28 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"
WriteAttributeValue("", 939, imgsrc, 939, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"50px\" class=\"d-block w-100\" />\r\n                    </div>\r\n");
#nullable restore
#line 30 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 35 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br /><br />\r\n<div class=\"whiteBackground container\">\r\n");
#nullable restore
#line 40 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"
     foreach (var category in Model.Categories)
    {
        var menuItems = Model.MenuItems;//Where(m=>m.Category.Name.Equals(category.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n");
#nullable restore
#line 44 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"
             if(menuItems.Count()>0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-12\">\r\n                    <div class=\"row\">\r\n                        <h3 class=\"text-success\">\r\n                            ");
#nullable restore
#line 49 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"
                       Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h3>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 53 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 56 "C:\Users\user\source\repos\Spice\Spice\Areas\Customer\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

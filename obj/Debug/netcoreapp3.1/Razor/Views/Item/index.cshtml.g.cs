#pragma checksum "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48aebf36777afde3c4f3a5b4ef4b80d87a93095c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Item_index), @"mvc.1.0.view", @"/Views/Item/index.cshtml")]
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
#line 1 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\_ViewImports.cshtml"
using Walmart_search;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\_ViewImports.cshtml"
using Walmart_search.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48aebf36777afde3c4f3a5b4ef4b80d87a93095c", @"/Views/Item/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5820807ab7d8f9479232050bdbda825f75e1d36c", @"/Views/_ViewImports.cshtml")]
    public class Views_Item_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Walmart_search.Models.Item>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 13 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
       Write(Html.DisplayNameFor(model => model._id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 16 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
       Write(Html.DisplayNameFor(model => model.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 19 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
       Write(Html.DisplayNameFor(model => model.brand));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 22 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
       Write(Html.DisplayNameFor(model => model.description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 25 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
       Write(Html.DisplayNameFor(model => model.image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 28 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
       Write(Html.DisplayNameFor(model => model.price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 34 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
     foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
           Write(Html.DisplayFor(modelItem => item._id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
           Write(Html.DisplayFor(modelItem => item.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
           Write(Html.DisplayFor(modelItem => item.brand));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
           Write(Html.DisplayFor(modelItem => item.description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
           Write(Html.DisplayFor(modelItem => item.image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
           Write(Html.DisplayFor(modelItem => item.price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 55 "D:\Documentos\Ramos Universidad\Códigos extra\walmart-search\Walmart-search\Views\Item\index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Walmart_search.Models.Item>> Html { get; private set; }
    }
}
#pragma warning restore 1591

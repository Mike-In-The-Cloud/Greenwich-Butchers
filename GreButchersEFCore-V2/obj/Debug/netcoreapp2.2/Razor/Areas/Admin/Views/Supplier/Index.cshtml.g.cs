#pragma checksum "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0df5af4b3c836d79f87b06c50a841b6f20fc909"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Supplier_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Supplier/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Supplier/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Supplier_Index))]
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
#line 1 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\_ViewImports.cshtml"
using GreButchersEFCore_V2;

#line default
#line hidden
#line 2 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\_ViewImports.cshtml"
using GreButchersEFCore_V2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0df5af4b3c836d79f87b06c50a841b6f20fc909", @"/Areas/Admin/Views/Supplier/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ed08008614e73300fd861a0fa00da08a7016f7f", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Supplier_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GreButchersEFCore_V2.Models.Supplier>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(146, 222, true);
            WriteLiteral("\r\n<br />\r\n<div class=\"border backgroundWhite\">\r\n    <div class=\"row\">\r\n        <div class=\"col-6\">\r\n            <h2 class=\"text-info\">Supplier List</h2>\r\n        </div>\r\n        <div class=\"col-6 text-right\">\r\n            ");
            EndContext();
            BeginContext(368, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f0df5af4b3c836d79f87b06c50a841b6f20fc9095073", async() => {
                BeginContext(412, 47, true);
                WriteLiteral("<i class=\"fas fa-folder-plus\"></i> New Supplier");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(463, 186, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <br />\r\n    <div>\r\n        <table class=\"table table-striped border\">\r\n            <tr class=\"table-info\">\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(650, 43, false);
#line 23 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml"
               Write(Html.DisplayNameFor(s => s.SupplierCompany));

#line default
#line hidden
            EndContext();
            BeginContext(693, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(761, 40, false);
#line 26 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml"
               Write(Html.DisplayNameFor(s => s.SupplierName));

#line default
#line hidden
            EndContext();
            BeginContext(801, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(869, 42, false);
#line 29 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml"
               Write(Html.DisplayNameFor(s => s.SupplierNumber));

#line default
#line hidden
            EndContext();
            BeginContext(911, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(979, 41, false);
#line 32 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml"
               Write(Html.DisplayNameFor(s => s.SupplierEmail));

#line default
#line hidden
            EndContext();
            BeginContext(1020, 100, true);
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n                <th></th>\r\n            </tr>\r\n\r\n");
            EndContext();
#line 38 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1177, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1238, 42, false);
#line 42 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml"
               Write(Html.DisplayFor(m => item.SupplierCompany));

#line default
#line hidden
            EndContext();
            BeginContext(1280, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1348, 39, false);
#line 45 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml"
               Write(Html.DisplayFor(m => item.SupplierName));

#line default
#line hidden
            EndContext();
            BeginContext(1387, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1455, 41, false);
#line 48 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml"
               Write(Html.DisplayFor(m => item.SupplierNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1496, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1564, 40, false);
#line 51 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml"
               Write(Html.DisplayFor(m => item.SupplierEmail));

#line default
#line hidden
            EndContext();
            BeginContext(1604, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1671, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f0df5af4b3c836d79f87b06c50a841b6f20fc90911049", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 54 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.SupplierId;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1734, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 57 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Supplier\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1793, 36, true);
            WriteLiteral("        </table>\r\n    </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GreButchersEFCore_V2.Models.Supplier>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c3e15f67c23f253eca2008466bca64873519740"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Products_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Products/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Products/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Products_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c3e15f67c23f253eca2008466bca64873519740", @"/Areas/Admin/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ed08008614e73300fd861a0fa00da08a7016f7f", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<GreButchersEFCore_V2.Models.Stock>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Products\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(89, 221, true);
            WriteLiteral("\r\n<br />\r\n<div class=\"border backgroundWhite\">\r\n    <div class=\"row\">\r\n        <div class=\"col-6\">\r\n            <h2 class=\"text-info\">Product List</h2>\r\n        </div>\r\n        <div class=\"col-6 text-right\">\r\n            ");
            EndContext();
            BeginContext(310, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c3e15f67c23f253eca2008466bca648735197406197", async() => {
                BeginContext(354, 47, true);
                WriteLiteral("<i class=\"fas fa-folder-plus\"></i> New Product ");
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
            BeginContext(405, 63, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <br />\r\n    <div>\r\n        ");
            EndContext();
            BeginContext(468, 528, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c3e15f67c23f253eca2008466bca648735197407766", async() => {
                BeginContext(532, 457, true);
                WriteLiteral(@"
            <div class=""form-group row"">

                <!-- input field, has the name id which is passed to the parameter-->
                <input type=""text"" name=""id"" placeholder=""Search..."" class=""input-group-text"">
                <!-- button to submit the filter -->
                <button type=""submit"" class=""btn btn-primary"">
                    <i class=""fas fa-search""></i> Go!
                </button>
            </div>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(996, 723, true);
            WriteLiteral(@"<!-- end search form-->
        <table class=""table table-striped border"">
            <tr class=""table-info"">
                <th>
                    Product Name
                </th>
                <th>
                    Price
                </th>
                <th>
                    Description
                </th>
                <th>
                    Weight
                </th>
                <th>
                    Category
                </th>
                <th>
                    Shop Stock
                </th>
                <th>
                    Warehouse Stock
                </th>
                <th></th>
                <th></th>
            </tr>
");
            EndContext();
#line 57 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Products\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1850, 48, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n");
            EndContext();
            BeginContext(1962, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(1987, 48, false);
#line 62 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(m => item.FkProduct.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(2035, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
            BeginContext(2134, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(2159, 51, false);
#line 66 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Products\Index.cshtml"
                   Write(String.Format("{0:c}", item.FkProduct.ProductPrice));

#line default
#line hidden
            EndContext();
            BeginContext(2210, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
            BeginContext(2314, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(2339, 55, false);
#line 70 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(m => item.FkProduct.ProductDescription));

#line default
#line hidden
            EndContext();
            BeginContext(2394, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
            BeginContext(2515, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(2540, 50, false);
#line 74 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(m => item.FkProduct.ProductWeight));

#line default
#line hidden
            EndContext();
            BeginContext(2590, 57, true);
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n");
            EndContext();
            BeginContext(2712, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(2737, 60, false);
#line 79 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(m => item.FkProduct.FkCategory.CategoryName));

#line default
#line hidden
            EndContext();
            BeginContext(2797, 53, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>");
            EndContext();
            BeginContext(2887, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(2914, 36, false);
#line 82 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(m => item.StockShop));

#line default
#line hidden
            EndContext();
            BeginContext(2950, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
            BeginContext(3072, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(3097, 41, false);
#line 86 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Products\Index.cshtml"
                   Write(Html.DisplayFor(m => item.StockWarehouse));

#line default
#line hidden
            EndContext();
            BeginContext(3138, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3217, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3c3e15f67c23f253eca2008466bca6487351974015662", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#line 89 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Products\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.FkProduct.ProductId;

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
            BeginContext(3289, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 92 "F:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\Admin\Views\Products\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(3356, 38, true);
            WriteLiteral("        </table>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<GreButchersEFCore_V2.Models.Stock>> Html { get; private set; }
    }
}
#pragma warning restore 1591

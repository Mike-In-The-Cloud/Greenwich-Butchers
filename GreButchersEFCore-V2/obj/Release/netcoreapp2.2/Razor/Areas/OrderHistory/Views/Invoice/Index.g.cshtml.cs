#pragma checksum "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d4e0f4d9f84f06b6c09409125ef6c1c6ee9f462"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_OrderHistory_Views_Invoice_Index), @"mvc.1.0.view", @"/Areas/OrderHistory/Views/Invoice/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/OrderHistory/Views/Invoice/Index.cshtml", typeof(AspNetCore.Areas_OrderHistory_Views_Invoice_Index))]
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
#line 1 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\_ViewImports.cshtml"
using GreButchersEFCore_V2;

#line default
#line hidden
#line 2 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\_ViewImports.cshtml"
using GreButchersEFCore_V2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d4e0f4d9f84f06b6c09409125ef6c1c6ee9f462", @"/Areas/OrderHistory/Views/Invoice/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ed08008614e73300fd861a0fa00da08a7016f7f", @"/Areas/OrderHistory/Views/_ViewImports.cshtml")]
    public class Areas_OrderHistory_Views_Invoice_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GreButchersEFCore_V2.Models.ViewModels.InvoiceViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/GreButchersLogo.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(152, 93, true);
            WriteLiteral("\r\n<br />\r\n<div class=\"border backgroundWhite\">\r\n    <h2 class=\"text-info\">Invoice For Order: ");
            EndContext();
            BeginContext(246, 27, false);
#line 9 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
                                        Write(Model.BulkOrder.BulkOrderId);

#line default
#line hidden
            EndContext();
            BeginContext(273, 180, true);
            WriteLiteral("</h2>\r\n    <div class=\"p-4 border rounded\">\r\n        <div class=\"row text-right\">\r\n            <div class=\" col-12\">\r\n                <div class=\"float-left\">\r\n                    ");
            EndContext();
            BeginContext(453, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4d4e0f4d9f84f06b6c09409125ef6c1c6ee9f4624919", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(495, 799, true);
            WriteLiteral(@"
                </div>
                <div class=""font-weight-bold text-right"">
                    From
                </div>
                <div class=""font-weight-light text-right"">
                    Greenwich Butchers
                </div>
                <div class=""font-weight-light text-right"">
                    22 Royal Hill
                </div>
                <div class=""font-weight-light text-right"">
                    Greenwich
                </div>
                <div class=""font-weight-light text-right"">
                    London
                </div>
                <div class=""font-weight-light text-right"">
                    Se10 8RT
                </div>
                <div class=""font-weight-light text-right"">
                    ");
            EndContext();
            BeginContext(1295, 39, false);
#line 35 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
               Write(Model.BulkOrder.BulkOrderCompletionDate);

#line default
#line hidden
            EndContext();
            BeginContext(1334, 271, true);
            WriteLiteral(@"
                </div>

            </div>
        </div>

        <div class=""text-left text-uppercase"">
            <div class=""text-muted font-weight-bold "">
                To
            </div>
            <div class=""font-weight-light"">
                ");
            EndContext();
            BeginContext(1606, 34, false);
#line 46 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
           Write(Model.Customer.CustomerCompanyName);

#line default
#line hidden
            EndContext();
            BeginContext(1640, 83, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"font-weight-light\">\r\n                ");
            EndContext();
            BeginContext(1724, 43, false);
#line 49 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
           Write(Model.Customer.ApplicationUser.BuildingName);

#line default
#line hidden
            EndContext();
            BeginContext(1767, 83, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"font-weight-light\">\r\n                ");
            EndContext();
            BeginContext(1851, 45, false);
#line 52 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
           Write(Model.Customer.ApplicationUser.StreetAddress1);

#line default
#line hidden
            EndContext();
            BeginContext(1896, 83, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"font-weight-light\">\r\n                ");
            EndContext();
            BeginContext(1980, 45, false);
#line 55 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
           Write(Model.Customer.ApplicationUser.StreetAddress2);

#line default
#line hidden
            EndContext();
            BeginContext(2025, 83, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"font-weight-light\">\r\n                ");
            EndContext();
            BeginContext(2109, 35, false);
#line 58 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
           Write(Model.Customer.ApplicationUser.City);

#line default
#line hidden
            EndContext();
            BeginContext(2144, 83, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"font-weight-light\">\r\n                ");
            EndContext();
            BeginContext(2228, 39, false);
#line 61 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
           Write(Model.Customer.ApplicationUser.PostCode);

#line default
#line hidden
            EndContext();
            BeginContext(2267, 536, true);
            WriteLiteral(@"
            </div>
        </div>
        <br />

        <table class=""table table-striped my-table table-bordered"">
            <tr class=""table-info"">
                <th>
                    Product Name
                </th>
                <th>
                    Quantity
                </th>
                <th>
                    Category
                </th>
                <th>
                    Weight(kg)
                </th>

                <th>

                </th>
            </tr>
");
            EndContext();
#line 85 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
               decimal TotalWeight = 0;

#line default
#line hidden
            BeginContext(2845, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 86 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
               foreach (var item in Model.BulkOrderItem)
                {

#line default
#line hidden
            BeginContext(2922, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(3007, 48, false);
#line 90 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
                       Write(Html.DisplayFor(c => item.FkProduct.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(3055, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(3147, 48, false);
#line 93 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
                       Write(Html.DisplayFor(c => item.BulkOrderItemQuantity));

#line default
#line hidden
            EndContext();
            BeginContext(3195, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(3287, 60, false);
#line 96 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
                       Write(Html.DisplayFor(c => item.FkProduct.FkCategory.CategoryName));

#line default
#line hidden
            EndContext();
            BeginContext(3347, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(3439, 50, false);
#line 99 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
                       Write(Html.DisplayFor(c => item.FkProduct.ProductWeight));

#line default
#line hidden
            EndContext();
            BeginContext(3489, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 100 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
                              TotalWeight += item.FkProduct.ProductWeight;

#line default
#line hidden
            BeginContext(3568, 93, true);
            WriteLiteral("                        </td>\r\n                        <td></td>\r\n                    </tr>\r\n");
            EndContext();
#line 104 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
                }
            

#line default
#line hidden
            BeginContext(3695, 40, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n");
            EndContext();
            BeginContext(3767, 45, true);
            WriteLiteral("                </td>\r\n                <td>\r\n");
            EndContext();
            BeginContext(3844, 45, true);
            WriteLiteral("                </td>\r\n                <td>\r\n");
            EndContext();
            BeginContext(3921, 320, true);
            WriteLiteral(@"                </td>
                <td class=""font-weight-bold text-right"">
                    Total Weight (Kg)
                </td>

                <td class=""font-weight-bold text-right"">
                    Total Inc VAT
                </td>
            </tr>
            <tr>
                <td>
");
            EndContext();
            BeginContext(4273, 45, true);
            WriteLiteral("                </td>\r\n                <td>\r\n");
            EndContext();
            BeginContext(4350, 45, true);
            WriteLiteral("                </td>\r\n                <td>\r\n");
            EndContext();
            BeginContext(4427, 84, true);
            WriteLiteral("                </td>\r\n                <td class=\"text-right\">\r\n                    ");
            EndContext();
            BeginContext(4512, 11, false);
#line 135 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
               Write(TotalWeight);

#line default
#line hidden
            EndContext();
            BeginContext(4523, 68, true);
            WriteLiteral("\r\n                </td>\r\n\r\n                <td class=\"text-right\">\r\n");
            EndContext();
#line 139 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
                      decimal Total = Convert.ToDecimal(Model.SupplierContacted.SupplierContactedQuote) * Convert.ToDecimal(Model.BulkOrder.BulkOrderMargin);

#line default
#line hidden
            BeginContext(4751, 22, true);
            WriteLiteral("                    £ ");
            EndContext();
            BeginContext(4774, 22, false);
#line 140 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
                 Write(Total.ToString("#.##"));

#line default
#line hidden
            EndContext();
            BeginContext(4796, 96, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n        </table>\r\n        <div class=\"text-right\">\r\n");
            EndContext();
#line 145 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
              DateTime DueDate = Convert.ToDateTime(Model.BulkOrder.BulkOrderCompletionDate);
                

#line default
#line hidden
            BeginContext(5006, 23, true);
            WriteLiteral("            Due Date : ");
            EndContext();
            BeginContext(5030, 41, false);
#line 147 "D:\1Uni Work\Year 2\COMP 1479 - WBL2\Project\GreButchersEFCore-V2\GreButchersEFCore-V2\Areas\OrderHistory\Views\Invoice\Index.cshtml"
                  Write(DueDate.AddDays(5).ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(5071, 90, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"text-right\">\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GreButchersEFCore_V2.Models.ViewModels.InvoiceViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

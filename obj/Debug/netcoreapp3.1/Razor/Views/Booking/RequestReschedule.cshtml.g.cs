#pragma checksum "/media/mygetzu/BENY/MEGA/Project/C#/DOTNET/MVC/HollyProject/Views/Booking/RequestReschedule.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5cf51b85df7d9147f55e9efac4fb8de97e4a3c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Booking_RequestReschedule), @"mvc.1.0.view", @"/Views/Booking/RequestReschedule.cshtml")]
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
#line 1 "/media/mygetzu/BENY/MEGA/Project/C#/DOTNET/MVC/HollyProject/Views/_ViewImports.cshtml"
using HollyProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/media/mygetzu/BENY/MEGA/Project/C#/DOTNET/MVC/HollyProject/Views/_ViewImports.cshtml"
using HollyProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5cf51b85df7d9147f55e9efac4fb8de97e4a3c2", @"/Views/Booking/RequestReschedule.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5bfadaed8fd9f97ae925a379b23aeed43af7d21", @"/Views/_ViewImports.cshtml")]
    public class Views_Booking_RequestReschedule : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/media/mygetzu/BENY/MEGA/Project/C#/DOTNET/MVC/HollyProject/Views/Booking/RequestReschedule.cshtml"
  
    Layout = "_Layout_HomePage";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 5 "/media/mygetzu/BENY/MEGA/Project/C#/DOTNET/MVC/HollyProject/Views/Booking/RequestReschedule.cshtml"
  
    var session = (User) ViewData["session"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Breadcrumb Area Start -->
<div class=""breadcrumb-area bg-img bg-overlay jarallax"" style=""background-image: url(../../img/bg-img/16.jpg);"">
    <div class=""container h-50"">
        <div class=""row h-30 align-items-center"">
            <div class=""col-12"">
                <div class=""breadcrumb-content text-center"" style=""margin-top: 70px"">
                    <h2 class=""page-title"">Reschedule !</h2>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Breadcrumb Area End -->

<div class=""hotel-search-form-area"" style=""margin-top: -100px;"">
    <div class=""container-fluid"">
        <div class=""hotel-search-form"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5cf51b85df7d9147f55e9efac4fb8de97e4a3c24692", async() => {
                WriteLiteral("\n                ");
#nullable restore
#line 27 "/media/mygetzu/BENY/MEGA/Project/C#/DOTNET/MVC/HollyProject/Views/Booking/RequestReschedule.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                <div class=""row justify-content-between align-items-end"">
                    <div class=""col-6 col-md-2 col-lg-4"">
                        <label for=""checkIn"">Check In</label>
                        <input type=""date"" class=""form-control"" id=""date_checkin"" name=""date_checkin"">
                    </div>
                    <div class=""col-6 col-md-2 col-lg-5"">
                        <label for=""checkOut"">Check Out</label>
                        <input type=""date"" class=""form-control"" id=""date_checkout"" name=""date_checkout"">
                    </div>
                    <div class=""col-12 col-md-3"">
                        <button type=""submit"" class=""form-control btn roberto-btn w-100""> Request Reschedule </button>
                    </div>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
#nullable restore
#line 26 "/media/mygetzu/BENY/MEGA/Project/C#/DOTNET/MVC/HollyProject/Views/Booking/RequestReschedule.cshtml"
AddHtmlAttributeValue("", 768, Url.Action("RequestReschedule", "Booking"), 768, 43, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n    </div>\n</div>\n\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\n    <script>\n\n\t</script>\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
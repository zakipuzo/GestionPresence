#pragma checksum "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42026f42ae24ba7118f8caec77357d6f4f2075ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Presences_Pages_Seances), @"mvc.1.0.razor-page", @"/Areas/Presences/Pages/Seances.cshtml")]
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
#line 2 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\_ViewImports.cshtml"
using GestionPresence.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\_ViewImports.cshtml"
using GestionPresence.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42026f42ae24ba7118f8caec77357d6f4f2075ae", @"/Areas/Presences/Pages/Seances.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13476d9596c5b733260a566892a1883c817817d9", @"/Areas/Presences/Pages/_ViewImports.cshtml")]
    public class Areas_Presences_Pages_Seances : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"
  
    ViewData["Title"] = "Seances";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1> Seances</h1>\r\n\r\n");
#nullable restore
#line 16 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"
 if(Model.taux!=-1){


#line default
#line hidden
#nullable disable
            WriteLiteral("<h2 class=\"text-danger\">taux d\'absence<b> ");
#nullable restore
#line 18 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"
                                     Write(Model.taux);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</b></h2>\r\n");
#nullable restore
#line 19 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<hr>\r\n\r\n<div>\r\n");
#nullable restore
#line 23 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"
 if(@Model.seances.Count()==0){

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Aucune Seance</p>\r\n");
#nullable restore
#line 25 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                Date\r\n            </th>\r\n            <th>Salle</th>   \r\n          <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 39 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"
 foreach (var item in Model.seances) {

    
   

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n              \r\n            ");
#nullable restore
#line 46 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"
       Write(item.DateSeance);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </td>\r\n              <td>\r\n               \r\n              ");
#nullable restore
#line 51 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"
         Write(item.Salle.Libelle);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 51 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"
                              Write(item.Salle.EcoleSite.Libelle);

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n            </td>\r\n            <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42026f42ae24ba7118f8caec77357d6f4f2075ae6415", async() => {
                WriteLiteral("Présences");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"
                                          WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n\r\n          \r\n        </tr>\r\n");
#nullable restore
#line 57 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Seances.cshtml"

     
       
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public GestionPresence.Data.ApplicationDbContext _db { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestionPresence.Areas.Presences.Pages.SeancesModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GestionPresence.Areas.Presences.Pages.SeancesModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GestionPresence.Areas.Presences.Pages.SeancesModel>)PageContext?.ViewData;
        public GestionPresence.Areas.Presences.Pages.SeancesModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

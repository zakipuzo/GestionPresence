#pragma checksum "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "adb973f8b6ff393945a86a3c23fc25611ab88f8f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Presences_Pages_Details), @"mvc.1.0.razor-page", @"/Areas/Presences/Pages/Details.cshtml")]
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
#line 4 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Details.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adb973f8b6ff393945a86a3c23fc25611ab88f8f", @"/Areas/Presences/Pages/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13476d9596c5b733260a566892a1883c817817d9", @"/Areas/Presences/Pages/_ViewImports.cshtml")]
    public class Areas_Presences_Pages_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<h1>Présences et Absences</h1>
<hr>


<div class=""row"">
<div class=""col-md-6"">
<h3>Les présences</h3>

<table class=""table"">
    <thead>
        <tr>
            <th>
                Etudiant
            </th>
          
        </tr>
    </thead>
    <tbody style=""background-color:green;color:white"">
");
#nullable restore
#line 32 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Details.cshtml"
 foreach (var item in Model.Presences){

    

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n              \r\n            ");
#nullable restore
#line 38 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Details.cshtml"
       Write(item.Inscription.Etudiant.Nom);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 38 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Details.cshtml"
                                       Write(item.Inscription.Etudiant.Prenom);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n\r\n                \r\n            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 44 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Details.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>
       


</div>



<div class=""col-md-6"">
<h3>Les Absences</h3>

<table class=""table"">
    <thead>
        <tr>
            <th>
                Etudiant
            </th>
          
        </tr>
    </thead>
    <tbody style=""background-color:red;color:white"">
");
#nullable restore
#line 68 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Details.cshtml"
 foreach (var item in Model.Absences) {

    

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n              \r\n            ");
#nullable restore
#line 74 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Details.cshtml"
       Write(item.Etudiant.Nom);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 74 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Details.cshtml"
                           Write(item.Etudiant.Prenom);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n\r\n                \r\n            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 80 "C:\aspcorezack\GestionPresence\Areas\Presences\Pages\Details.cshtml"

        
       
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody></table>\r\n\r\n</div>\r\n\r\n</div>\r\n\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestionPresence.Areas.Presences.Pages.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GestionPresence.Areas.Presences.Pages.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GestionPresence.Areas.Presences.Pages.DetailsModel>)PageContext?.ViewData;
        public GestionPresence.Areas.Presences.Pages.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

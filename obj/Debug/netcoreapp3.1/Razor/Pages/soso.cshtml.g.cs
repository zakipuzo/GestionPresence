#pragma checksum "C:\aspcorezack\GestionPresence\Pages\soso.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13ec6a8dd3214afb814c93942dca291a8ffc7401"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GestionPresence.Pages.Pages_soso), @"mvc.1.0.razor-page", @"/Pages/soso.cshtml")]
namespace GestionPresence.Pages
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
#line 1 "C:\aspcorezack\GestionPresence\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\aspcorezack\GestionPresence\Pages\_ViewImports.cshtml"
using GestionPresence;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\aspcorezack\GestionPresence\Pages\_ViewImports.cshtml"
using GestionPresence.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13ec6a8dd3214afb814c93942dca291a8ffc7401", @"/Pages/soso.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b65beb1e6f3a5a97df9837a559343ae128dcf4da", @"/Pages/_ViewImports.cshtml")]
    public class Pages_soso : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<input id=\"basta\" type=\"text\" />\r\n<div id=\"res\"></div>\r\n\r\n<button id=\"mybtn\">zbi</button>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>

  $(document).ready(function(){

$(""#mybtn"").click(function(){

 $.ajax({
         
        url: '?handler=TestMethod',
        type: 'GET',
        dataType: 'json',
        data: {id: $(""#basta"").val()},
        success: function(result){

            $(""#res"").text(result.id+""  ""+result.name);


     
    }});
});
   

});
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyApp.Namespace.sosoModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyApp.Namespace.sosoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyApp.Namespace.sosoModel>)PageContext?.ViewData;
        public MyApp.Namespace.sosoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

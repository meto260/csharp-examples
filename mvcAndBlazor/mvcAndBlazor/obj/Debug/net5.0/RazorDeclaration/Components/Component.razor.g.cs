// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace mvcAndBlazor.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "C:\Users\metin.yakar\source\repos\mvcAndBlazor\mvcAndBlazor\Components\Component.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\metin.yakar\source\repos\mvcAndBlazor\mvcAndBlazor\Components\Component.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\metin.yakar\source\repos\mvcAndBlazor\mvcAndBlazor\Components\Component.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
    public partial class Component : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 13 "C:\Users\metin.yakar\source\repos\mvcAndBlazor\mvcAndBlazor\Components\Component.razor"
       
    public int counter { get; set; } = 0;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (storage is not null)
        {
            counter = (await storage.GetAsync<int>("counter")).Value;
            StateHasChanged();
        }
    }

    private async Task onePlus(MouseEventArgs mouseEventArgs)
    {
        if (storage is not null)
        {
            counter = (await storage.GetAsync<int>("counter")).Value;
        }
        counter++;
        await storage.SetAsync("counter", counter);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedSessionStorage storage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }
    }
}
#pragma warning restore 1591

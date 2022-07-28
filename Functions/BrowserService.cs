using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using BlazorPro.BlazorSize;

namespace ScriptWriterApp.Functions
{
    public class BrowserService
    {
        //browser
        private IJSObjectReference? browserFunctions;
        private IJSRuntime jsRuntime;

        public BrowserService(IJSRuntime jSRuntime)
        {
            jsRuntime = jSRuntime;
        }

        public async Task<BrowserWindowSize> GetWindowSize()
        {
            browserFunctions = await jsRuntime.InvokeAsync<IJSObjectReference>("Functions.getBrowserAction");
            return await browserFunctions.InvokeAsync<BrowserWindowSize>("getWindowDimensions");
        }
    }

    public struct BrowserDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}

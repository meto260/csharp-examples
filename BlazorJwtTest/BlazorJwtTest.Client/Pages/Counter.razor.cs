using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorJwtTest.Client.Pages {
    public partial class Counter {
        [Inject]
        ILocalStorageService localStorageService { get; set; }

        [Inject]
        HttpClient Client { get; set; }

        [Inject]
        AuthenticationStateProvider authenticationStateProvider { get; set; }

        ClaimsPrincipal LogonUser { get; set; }

        private int currentCount = 0;
        public string msgdata { get; set; }

        protected override async Task OnInitializedAsync() {
            var a = await (authenticationStateProvider as AuthStateManager).GetAuthenticationStateAsync();
            LogonUser = a.User;
        }

        private void IncrementCount() {
            currentCount++;
        }

        private async Task AuthButClick() {
            var httpReqRes = await Client.GetStringAsync("api/Values/data/deneme");
            msgdata = httpReqRes;
        }

        private bool IsAuthorized() {
            try {
                return LogonUser.Identity.IsAuthenticated;
            } catch (Exception exc) {
                Console.WriteLine(exc);
                return false;
            }
        }
    }
}

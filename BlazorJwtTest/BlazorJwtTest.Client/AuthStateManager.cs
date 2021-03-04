using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorJwtTest.Client {
    public class AuthStateManager : AuthenticationStateProvider {
        readonly ILocalStorageService localStorage;
        private readonly HttpClient client;
        readonly AuthenticationState anonymous;
        public AuthStateManager(ILocalStorageService localStorageService, HttpClient Client) {
            localStorage = localStorageService;
            client = Client;
            anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync() {
            string token = await localStorage.GetItemAsStringAsync("token");
            if (string.IsNullOrEmpty(token)) {
                return anonymous;
            }
            string username = await localStorage.GetItemAsStringAsync("username");
            string LoginUserType = await localStorage.GetItemAsStringAsync("role");
            var myClaimPrincipals = new ClaimsPrincipal(
                new ClaimsIdentity(new[] { new Claim("username", username), new Claim("LoginUserType", LoginUserType) }, "jwtAuthType")
            );

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var authstate = new AuthenticationState(myClaimPrincipals);
            return authstate;
        }

        public void NotifyUserLogin(string username, string role) {
            var myClaimPrincipals = new ClaimsPrincipal(
                new ClaimsIdentity(new[] { new Claim("username", username), new Claim("LoginUserType", role) }, "jwtAuthType")
            );
            var authState = Task.FromResult(new AuthenticationState(myClaimPrincipals));

            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout() {
            var authState = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
        public async Task<bool> IsAuthorizedAsync() {
            //var asp = await (authenticationStateProvider as AuthStateManager).GetAuthenticationStateAsync();
            var asp = await GetAuthenticationStateAsync();
            if(asp?.User is not null && asp.User.Identity.IsAuthenticated) {
                return true;
            } else {
                return false;
            }
        }
    }
}

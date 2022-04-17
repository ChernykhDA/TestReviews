using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Reviews.Shared;
using Reviews.Shared.Services;
using System.Security.Claims;

namespace TestReviews.Common
{
    public class CustomProvider : AuthenticationStateProvider
    {
        public ILocalStorageService LocalStorage { get; set; }

        public IUserService UserService { get; set; }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var accessToken = await LocalStorage.GetItemAsync<string>("accessToken");

            ClaimsIdentity identity;

            if (accessToken != null && accessToken != string.Empty)
            {
                User user = await UserService.GetUserByAccessTokenAsync(accessToken);
                identity = GetClaimsIdentity(user);
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var claimsPrincipal = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        public async Task UserAsAuthenticated(User user, string token)
        {
            await LocalStorage.SetItemAsync("accessToken", token);

            var identity = GetClaimsIdentity(user);

            var claimsPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public CustomProvider(ILocalStorageService localStorage, IUserService userService)
        {
            LocalStorage = localStorage;
            UserService = userService;
        }

        /// <summary>
        /// Метод разлогинивания
        /// </summary>
        /// <returns></returns>
        public async Task UserAsLoggedOut()
        {
            await LocalStorage.RemoveItemAsync("accessToken");

            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private ClaimsIdentity GetClaimsIdentity(User user)
        {
            var claimsIdentity = new ClaimsIdentity();

            if (user?.Login != null)
            {
                claimsIdentity = new ClaimsIdentity(new[]
                                {
                                    new Claim(ClaimTypes.Name, user.Login),
                                    new Claim(ClaimTypes.Role, user.Role.Description)
                                }, "apiauth_type");
            }
            return claimsIdentity;
        }
    }
}

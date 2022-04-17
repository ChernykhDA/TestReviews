using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Reviews.Shared;
using System.Security.Claims;
using TestReviews.Common;

namespace TestReviews.Pages.Login
{
    public partial class Login
    {
        private string LoginMesssage { get; set; }
        private User user { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> authStateTask { get; set; }

        protected async override Task OnInitializedAsync()
        {
            user = new User();
            user.Login = "";
            user.Password = "";

            ClaimsPrincipal claimsPrincipal = (await authStateTask).User;

            if (claimsPrincipal.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        private async Task<bool> ValidateUser()
        {
            (User, string) returnedUser = await userService.LoginAsync(user);

            if (returnedUser.Item1 != null)
            {
                await ((CustomProvider)AuthenticationStateProvider)
                    .UserAsAuthenticated(returnedUser.Item1, returnedUser.Item2);

                NavigationManager.NavigateTo("/");
            }
            else
            {
                user.Password = "";
                LoginMesssage = "Неверный логин или пароль";
            }

            return await Task.FromResult(true);
        }
    }
}

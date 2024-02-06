using GameShop.Client.Services.AuthService;
using Microsoft.AspNetCore.Components;

namespace GameShop.Client.Pages
{
    public partial class Profile
    {
        [Inject]
        public IAuthService AuthService { get; set; }

        public UserChangePassword request { get; set; } = new UserChangePassword();

        public string message { get; set; } = string.Empty;


        private async Task ChangePassword()
        {
            var result = await AuthService.ChangePassword(request);
            message = result.Message;
        }

    }
}

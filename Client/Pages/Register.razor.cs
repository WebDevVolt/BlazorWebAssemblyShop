using GameShop.Client.Services.AuthService;
using Microsoft.AspNetCore.Components;

namespace GameShop.Client.Pages
{
    public partial class Register
    {
        [Inject]
        public IAuthService AuthService { get; set; }

        public UserRegister user { get; set; } = new UserRegister();

        public string message { get; set; } = string.Empty;

        public string messageCssClass { get; set; } = string.Empty;

        async Task HandleRegistration()
        {
            var result = await AuthService.Register(user);
            message = result.Message;
            if (result.Success)
                messageCssClass = "text-success";
            else
                messageCssClass = "text-danger";
        }
    }
}

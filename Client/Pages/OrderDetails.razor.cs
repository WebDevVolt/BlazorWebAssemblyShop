using Microsoft.AspNetCore.Components;

namespace GameShop.Client.Pages
{
    public partial class OrderDetails
    {
        [Inject]
        public IOrderService? OrderService { get; set; }

        [Parameter]
        public int orderId { get; set; }

        OrderDetailsResponse order = null;

        protected override async Task OnInitializedAsync()
        {
            order = await OrderService.GetOrderDetails(orderId);
        }
    }
}

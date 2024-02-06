
using Microsoft.AspNetCore.Components;

namespace GameShop.Client.Pages
{
    public partial class Orders
    {
        List<OrderOverviewResponse> orders = null;

        [Inject]
        public IOrderService OrderService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            orders = await OrderService.GetOrders();
        }
    }
}

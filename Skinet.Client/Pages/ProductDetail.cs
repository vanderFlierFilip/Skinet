using Microsoft.AspNetCore.Components;
using Skinet.Client.Services.Interface;
using Skinet.Model.Models;
using System.Threading.Tasks;

namespace Skinet.Client.Pages
{
    public partial class ProductDetail
    {
        [Parameter]
        public string ProductId { get; set; }
        public ProductReadDto Product { get; set; }

        [Inject]
        public IProductsService ProductsService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Product = await ProductsService.GetProduct(int.Parse(ProductId));
        }
    }
}

using Microsoft.AspNetCore.Components;
using Skinet.Client.Services.Interface;
using Skinet.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.Client.Pages
{
    public partial class ProductsOverview
    {
        public IEnumerable<ProductReadDto> Products { get; set; }

        [Inject]
        public IProductsService ProductsService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Products = (await ProductsService.GetAllProducts()).ToList();

        }
    }
}

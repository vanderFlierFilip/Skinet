using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using MudBlazor;
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
        [Inject]
        private IDialogService _dialogService{ get; set; }


        protected async override Task OnInitializedAsync()
        {
            Products = (await ProductsService.GetAllProducts()).ToList();

        }

        private async Task OpenModal(int productId = 0)
        {


            var parameters = new DialogParameters();

            if (productId != 0)
            {
                var product = await ProductsService.GetProduct(productId);

                if (product != null)
                {
                    parameters.Add(nameof(ProductAddOrEdit.ProductModel), new ProductReadDto
                    {
                        Id = product.Id, 
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        PictureUrl = product.PictureUrl,
                        ProductBrand = product.ProductBrand,
                        ProductType = product.ProductType,

                    }); 
                }

            }
            var options = new DialogOptions { CloseButton = true };

            _dialogService.Show<ProductAddOrEdit>("Dialog",  parameters, options);
        }
    }
}

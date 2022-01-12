using Microsoft.AspNetCore.Components;
using Skinet.Model.Models;

namespace Skinet.Client.Pages
{
    public partial class ProductAddOrEdit
    {
        [Parameter]
        public ProductReadDto ProductModel { get; set; } = new();
        public int IntValue { get; set; }
        public double DoubleValue { get; set; }
        public decimal DecimalValue { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Model.Models
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile PictureFile { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}

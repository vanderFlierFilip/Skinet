using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Skinet.Core.Entities;
using Skinet.Model.Models;

namespace Skinet.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductReadDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductReadDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl))  
                return null;
            
            return _config["ApiUrl"] + source.PictureUrl;

            
        }
    }
}
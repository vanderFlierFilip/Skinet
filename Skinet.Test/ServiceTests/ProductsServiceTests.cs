using Moq;
using Skinet.Core.Interfaces;
using Skinet.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Test.ServiceTests
{
    public class ProductsServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly ProductService _sut;

        public ProductsServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _sut = new ProductService(_productRepositoryMock.Object);
        }
    }
}

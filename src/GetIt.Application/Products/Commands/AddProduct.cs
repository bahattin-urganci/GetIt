using GetIt.Core.Mediator.Commands;
using GetIt.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application.Products.Commands
{
    public class AddProduct:ICommand
    {
        public string ProductName { get; set;}
    }
    public class AddProductHandler : ICommandHandler<AddProduct>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Unit> Handle(AddProduct request, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}

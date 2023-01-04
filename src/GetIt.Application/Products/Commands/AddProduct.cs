using GetIt.Core.Mediator.Commands;
using GetIt.Domain;
using GetIt.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application.Products.Commands
{
    public class AddProduct : ICommand
    {
        public string ProductName { get; set; }
        public decimal BasePrice { get; set; }
    }
    public class AddProductHandler : ICommandHandler<AddProduct>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _db;
        public AddProductHandler(IProductRepository productRepository, IUnitOfWork db)
        {
            _productRepository = productRepository;
            _db = db;
        }

        public async Task<Unit> Handle(AddProduct request, CancellationToken cancellationToken)
        {
            Product product = new Product(request.ProductName, request.BasePrice);
            product.AddNewProductEvent();
            _productRepository.Add(product);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

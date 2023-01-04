using GetIt.Application.Base;
using GetIt.Core.Mediator.Commands;
using GetIt.Domain;
using GetIt.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application.Products.Commands
{
    public class DeleteProduct : ICommand<BaseResponse<int>>
    {
        public int Id { get; set; }
        public DeleteProduct(int id)
        {
            Id = id;
        }
    }
    public class DeleteProductHandler : ICommandHandler<DeleteProduct, BaseResponse<int>>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _db;

        public DeleteProductHandler(IProductRepository repository, IUnitOfWork db)
        {
            _repository = repository;
            _db = db;
        }

        public async Task<BaseResponse<int>> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            BaseResponse<int> response = new();
            var product = await _repository.FindOneAsync(x => x.Id == request.Id);
            if (product == null)
            {
                response.Succedded = false;
                response.Message = "Ürün Bulunamadı";
                return response;
            }

            _repository.Remove(product);
            await _db.SaveChangesAsync(cancellationToken);
            response.Result = request.Id;
            response.Message = "Ürün Başarılı bir şekilde silindi";
            return response;
        }
    }

}

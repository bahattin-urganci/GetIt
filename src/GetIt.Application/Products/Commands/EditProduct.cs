using AutoMapper;
using GetIt.Application.Base;
using GetIt.Application.Products.Models;
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
    public class EditProduct : ICommand<BaseResponse<ProductDTO>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
    }
    public class EditProductHandler : ICommandHandler<EditProduct, BaseResponse<ProductDTO>>
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EditProductHandler(IProductRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ProductDTO>> Handle(EditProduct request, CancellationToken cancellationToken)
        {
            BaseResponse<ProductDTO> response = new();
            var product = await _repository.FindOneAsync(x => x.Id == request.Id);
            if (product == null)
            {
                response.Succedded = false;
                response.Message = "Ürün Bulunamadı";
                return response;
            }

            _repository.Update(request, product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            response.Result = _mapper.Map<ProductDTO>(product);
            return response;
        }
    }
}

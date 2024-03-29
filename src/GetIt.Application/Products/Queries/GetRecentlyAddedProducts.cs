﻿using AutoMapper;
using GetIt.Application.Products.Models;
using GetIt.Core.Mediator.Queries;
using GetIt.Domain.Products;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application.Products.Queries
{
    public class GetRecentlyAddedProducts : IQuery<List<ProductDTO>>
    {
        public GetRecentlyAddedProducts(int count)
        {
            Count = count;
        }

        public int Count { get; set; }
    }
    public class GetRecentlyAddedProductsQueryHandler : IQueryHandler<GetRecentlyAddedProducts, List<ProductDTO>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetRecentlyAddedProductsQueryHandler> _logger;
        public GetRecentlyAddedProductsQueryHandler(IProductRepository repository, IMapper mapper, ILogger<GetRecentlyAddedProductsQueryHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ProductDTO>> Handle(GetRecentlyAddedProducts request, CancellationToken cancellationToken)
        {
            List<Product> data = await _repository.GetRecentlyAddedProducts(request.Count);
            _logger.LogInformation("request count {reqCount} actual product count {productCount}", request.Count, data.Count);            
            return _mapper.Map<List<ProductDTO>>(data);
        }
    }
}

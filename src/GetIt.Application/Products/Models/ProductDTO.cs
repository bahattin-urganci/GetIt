using AutoMapper;
using GetIt.Application.Base;
using GetIt.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application.Products.Models
{
    [AutoMap(typeof(Product), ReverseMap = true)]
    public record ProductDTO : AuditDTO
    {
        public ProductDTO(string name, decimal basePrice)
        {
            Name = name;
            BasePrice = basePrice;
        }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
    }
}

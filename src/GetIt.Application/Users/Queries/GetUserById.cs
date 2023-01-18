using AutoMapper;
using GetIt.Application.Products.Models;
using GetIt.Application.Products.Queries;
using GetIt.Application.Users.Models;
using GetIt.Core.Mediator.Queries;
using GetIt.Domain.Products;
using GetIt.Domain.Users;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application.Users.Queries
{
    public class GetUserById : IQuery<UserDTO>
    {
        public GetUserById(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    internal class GetUserByIdQueryHandler : IQueryHandler<GetUserById, UserDTO>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;

        public GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper, ILogger<GetUserByIdQueryHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDTO> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            AppUser user = await _repository.FindOneAsync(x=>x.Id== request.Id);

            if (user == null)
            {
                _logger.LogInformation("User not found:{id}!", request.Id);
                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }
    }
}

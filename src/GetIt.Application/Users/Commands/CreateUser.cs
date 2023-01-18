using AutoMapper;
using GetIt.Application.Users.Models;
using GetIt.Core.Mediator.Commands;
using GetIt.Domain;
using GetIt.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application.Users.Commands
{
    public class CreateUser : ICommand<UserDTO>
    {
        public CreateUserDTO User { get; set; }
        public CreateUser(CreateUserDTO user)
        {
            User = user;
        }
    }
    internal class CreateUserCommandHandler : ICommandHandler<CreateUser,UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserDTO> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUser>(request.User);

            _userRepository.Add(user);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserDTO>(user);
        }
    }
}

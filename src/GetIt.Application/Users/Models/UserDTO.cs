using AutoMapper;
using GetIt.Application.Base;
using GetIt.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application.Users.Models
{
    [AutoMap(typeof(AppUser),ReverseMap = true)]
    public record UserDTO : AuditDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

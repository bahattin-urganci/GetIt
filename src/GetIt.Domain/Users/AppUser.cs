using GetIt.Domain.Base;

namespace GetIt.Domain.Users
{
    public class AppUser : AuditEntity
    {
        protected AppUser() { }
        public AppUser(string firstName, string lastName, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;            
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

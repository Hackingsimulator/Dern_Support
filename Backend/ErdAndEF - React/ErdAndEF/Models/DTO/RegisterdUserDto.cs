namespace ErdAndEF.Models.DTO
{
    public class RegisterdUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IList<string> Roles { get; set; }
    }
}

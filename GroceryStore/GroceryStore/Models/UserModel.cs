namespace GroceryStore.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }
    }

}

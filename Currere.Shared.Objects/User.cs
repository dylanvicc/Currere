namespace Currere.Shared.Objects
{
    public sealed class User
    {
        public int UserID { get; set; }

        public string EmailAddress { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime RegistrationDateUTC { get; set; }

        public DateTime LastLoginDateUTC { get; set; }

        public bool ConfirmedEmailAddress { get; set; }

        public bool Locked { get; set; }

        public int RoleID { get; set; }
    }
}

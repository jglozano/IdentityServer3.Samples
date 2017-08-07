namespace CustomLoginPage.Models
{
    public class LoginInputModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public UserType UserType { get; set; }
    }

    public class LoginViewModel
    {
        public string AuthId { get; set; }
    }

    public enum UserType
    {
        Client,
        Agent,
        Employee
    }
}

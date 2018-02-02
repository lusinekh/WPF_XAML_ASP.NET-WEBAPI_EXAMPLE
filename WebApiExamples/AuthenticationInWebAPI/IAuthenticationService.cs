namespace AuthenticationInWebAPI
{
    public interface IAuthenticationService
    {
        bool Authenticate(string user, string password);
    }
}

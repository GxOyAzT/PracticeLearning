namespace Auth.Api.IdentityJwt
{
    public interface IGenerateToken
    {
        string GenerateTokenMethod(string userId);
    }
}
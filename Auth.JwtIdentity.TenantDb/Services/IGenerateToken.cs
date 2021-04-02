namespace Auth.JwtIdentity.TenantDb.Services
{
    public interface IGenerateToken
    {
        string GenerateTokenMethod(string userId);
        string GenerateTokenMethodWithAdminPermissions(string userId);
    }
}
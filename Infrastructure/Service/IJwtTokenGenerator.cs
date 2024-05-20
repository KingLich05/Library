namespace sultan.Service;

public interface IJwtTokenGenerator
{
    Task<string> GenerateTokenAsync(string username);

}
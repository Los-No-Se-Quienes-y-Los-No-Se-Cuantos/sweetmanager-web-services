namespace sweetmanager.API.IAM.Infrastructure.Tokens.JWT.Configuration;

public class TokenSettings
{
    public string Secret { get; set; }
    
    public string Audience { get; set; }
    
    public string Issuer { get; set; }
    
    public int ExpirationInMinutes { get; set; }

    public TokenSettings()
    {
        Secret = string.Empty;
        Audience = string.Empty;
        Issuer = string.Empty;
        ExpirationInMinutes = 0;
    }
}
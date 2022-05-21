namespace WebApi.Options.Models;

public class JwtOptions
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public int TokenLifeExpectancyMinutes { get; set; }
    public string Secret { get; set; }
}
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Helpers;

public static class Crypto
{
    public static SymmetricSecurityKey GetSymmetricSecurityKey(string secret) => new(Encoding.UTF8.GetBytes(secret));

}
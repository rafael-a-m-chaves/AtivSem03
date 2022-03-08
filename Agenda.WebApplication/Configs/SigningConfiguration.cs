using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Agenda.WebApplication.Configs
{
    public class SigningConfiguration
    {        
        public SigningCredentials SigningCredentials { get; }
        public SecurityKey Key { get; }
        public SigningConfiguration(TokenConfiguration tokenConfigurations)
        {
            var byteArray = Encoding.ASCII.GetBytes(tokenConfigurations.SecretKey);
            var signingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(byteArray);

            SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            Key = signingKey;
        }
    }
}

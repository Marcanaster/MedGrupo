using MedGrupo.CrossCutting.Helper;
using MedGrupo.Domain.Dtos;
using MedGrupo.Domain.Entities;
using MedGrupo.Domain.Interfaces.Services.User;
using MedGrupo.Domain.Repository;
using MedGrupo.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MedGrupo.Service.Service
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        private IConfiguration _configuration { get; }

        public LoginService(IUserRepository repository, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration)
        {
            this._repository = repository;
            this._signingConfigurations = signingConfigurations;
            this._tokenConfigurations = tokenConfigurations;
            this._configuration = configuration;
        }
        public async Task<object> FindByLogin(LoginDto login)
        {
            var baseUser = new UserEntity();

            if (login != null && !string.IsNullOrWhiteSpace(login.Login) && !string.IsNullOrWhiteSpace(login.password))
            {
                var passEncrypt = Crypt.Encrypt(login.password, _configuration["KEY_CRYPT"]);

                baseUser = await _repository.FindByLogin(login.Login, passEncrypt);
                if (baseUser == null)
                {
                    return new { authenticated = false, message = "Falha ao autenticar" };
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(login.Login),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, login.Login)
                        }
                    );
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);
                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, login);
                }
            }
            else
            {
                return new { authenticated = false, message = "Falha ao autenticar" };
            }
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDto login)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = login.Login,
                message = "Usuário logado com sucesso!"
            };
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }
    }
}

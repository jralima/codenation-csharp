using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;

namespace Codenation.Challenge.Services
{
    public class UserProfileService : IProfileService
    {
        private readonly CodenationContext dbContext;

        /*
- Concluir a implementa��o do m�todo GetProfileDataAsync e do m�todo GetUserClaims. 
Esse m�todo deve buscar as informa��es do usu�rio que est� sendo passado no contexto e retornar as Claims. 
As claims necess�rias est�o definidas no m�todo GetUserClaims. Siga as regras de configura��o para terminar a 
constru��o desses m�todos. O m�todo GetUserClaims � utilizado tamb�m pela classe PasswordValidatorService. 
Esses dois servi�os s�o respons�veis por validar e retornar as informa��es do usu�rio que estar�o presentes 
no token.          
*/

        public UserProfileService(CodenationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var request = context.ValidatedRequest as ValidatedTokenRequest;
            if (request != null)
            {
                context.IssuedClaims = request.Subject.Claims.ToList();
            }
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }

        public static Claim[] GetUserClaims(User user)
        {
            var role = "User";

            if (user.Email.Equals("tegglestone9@blog.com"))
                role = "Admin";

            return new []
            {
                new Claim(ClaimTypes.Name, user.Nickname),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role)
            };
        }

    }
}
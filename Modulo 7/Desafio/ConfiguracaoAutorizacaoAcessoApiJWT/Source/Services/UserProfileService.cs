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
- Concluir a implementação do método GetProfileDataAsync e do método GetUserClaims. 
Esse método deve buscar as informações do usuário que está sendo passado no contexto e retornar as Claims. 
As claims necessárias estão definidas no método GetUserClaims. Siga as regras de configuração para terminar a 
construção desses métodos. O método GetUserClaims é utilizado também pela classe PasswordValidatorService. 
Esses dois serviços são responsáveis por validar e retornar as informações do usuário que estarão presentes 
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
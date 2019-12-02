using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Linq;
using System.Threading.Tasks;
 
namespace Codenation.Challenge.Services
{
    public class PasswordValidatorService: IResourceOwnerPasswordValidator
    {
        private readonly CodenationContext dbContext;

        /*
- Concluir a implementação da classe porque da forma como está ela sempre irá retornar uma autenticação inválida. 
Essa classe é responsável por verificar se a senha do usuário é válida. O e-mail do usuário será passado na 
propriedade UserName do contexto no método ValidateAsync e a senha é passada na propriedade Password do contexto.

- O método ValidateAsync deve retonar um GrantValidationResult passando como subject o Id do usuário, o 
authenticationMethod como custom e em claims a lista de Claims do usuário. Para a lista de claims pode ser 
usado o método estático já definido em UserProfileService. 

*/

        public PasswordValidatorService(CodenationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = dbContext.Users.Where(x => x.Email.Equals(context.UserName) && x.Password.Equals(context.Password)).FirstOrDefault();

            if(user == default)
            {
                context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant, "Invalid username or password");
                return Task.CompletedTask;
            }

            var subject = user.Id.ToString();
            var authenticationMethod = "custom";

            context.Result = new GrantValidationResult(subject, authenticationMethod, UserProfileService.GetUserClaims(user));

            return Task.CompletedTask;

        }
     
    }
}
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
- Concluir a implementa��o da classe porque da forma como est� ela sempre ir� retornar uma autentica��o inv�lida. 
Essa classe � respons�vel por verificar se a senha do usu�rio � v�lida. O e-mail do usu�rio ser� passado na 
propriedade UserName do contexto no m�todo ValidateAsync e a senha � passada na propriedade Password do contexto.

- O m�todo ValidateAsync deve retonar um GrantValidationResult passando como subject o Id do usu�rio, o 
authenticationMethod como custom e em claims a lista de Claims do usu�rio. Para a lista de claims pode ser 
usado o m�todo est�tico j� definido em UserProfileService. 

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
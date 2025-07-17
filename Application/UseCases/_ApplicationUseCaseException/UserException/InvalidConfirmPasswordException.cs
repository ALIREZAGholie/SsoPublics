using Webgostar.Framework.Application.ApplicationExceptions;

namespace Application.UseCases._ApplicationUseCaseException.UserException
{
    public class InvalidConfirmPasswordException : BaseApplicationException
    {
        public InvalidConfirmPasswordException() : base("رمز عبور و تائید رمز عبور یکسان نیست")
        {
        }
    }
}

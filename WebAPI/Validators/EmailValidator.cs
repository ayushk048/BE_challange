using FluentValidation;

namespace _Diabetes_BE_challenge.Validator
{
    public class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator()
        {
            RuleFor(x => x).EmailAddress();
        }
    }
}

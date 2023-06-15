using EFRepository.DTO;
using FluentValidation;

namespace ATWebAPI.Validations
{
    public class UserValidator:AbstractValidator<UserDTO>
    {
        //public UserValidator()
        //{
        //    RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.");
        //    RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required.");
        //    RuleFor(x => x.UserName).NotEmpty().WithMessage("Last Name is required.").MinimumLength(8).WithMessage("Minimum lenth should be 8 chars").MaximumLength(12).WithMessage("Max lenth should be 12 chars");
        //    RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is mandatory and one character is allowed");
        //    RuleFor(x => x.Email).EmailAddress();
        //}

    }
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name is required.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Name is required.");
        }

    }
}

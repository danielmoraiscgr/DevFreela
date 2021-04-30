using System;
using System.Text.RegularExpressions;
using DevFreela.Application.Commands.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido !");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula e um caracter especial");

            RuleFor(p => p.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório !");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"ˆ.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%ˆ&+=]).*$");

            return regex.IsMatch(password);
               
        }
        
    }
}

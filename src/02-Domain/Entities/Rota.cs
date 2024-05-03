using FluentValidation;
using RotaDeViagem.Shared.Abstractions.Entities;
using RotaDeViagem.Shared.Interfaces.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaDeViagem.Domain.Entities
{
    public class Rota: AuditEntityBase
    {
        public string Origem { get; private set; }
        public string Destino { get; private set; }
        public double Valor { get; private set; }

        public void Change(String origem, string destino, double valor)
        { 
            Origem = origem; 
            Destino = destino; 
            Valor = valor;            
        }
        public override bool Validate()
        {            
            var validator = new RotaValidator();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                return false;
            }
            return true;
            
        }

        internal class RotaValidator : AbstractValidator<Rota>
        {

            public RotaValidator()
            {
                RuleFor(x => x.Origem)
                    .NotEmpty()
                        .WithMessage("O campo origem é obrigatório.");

                RuleFor(x => x.Origem)
                    .MaximumLength(3)
                        .WithMessage("A origem deve conter no máxim 3 caracteres.");

                RuleFor(x => x.Destino)
                .NotEmpty()
                    .WithMessage("O campo destino é obrigatório.");

                RuleFor(x => x.Destino)
                    .MaximumLength(3)
                        .WithMessage("O destino deve conter no máxim 3 caracteres.");

                RuleFor(x => new { x.Origem, x.Destino}).Custom((value, context) => 
                { 
                    if (value.Origem.ToLower() == value.Destino.ToLower() )
                        context.AddFailure("A origem e o Destino devem ser diferentes");
                });

                RuleFor(x => x.Valor)
                .NotEmpty()
                    .WithMessage("O campo valor é obrigatório.");

                RuleFor(x => x.Valor).Custom((value, context) =>
                {
                    if (value <= 0)
                        context.AddFailure("O valor deve ser maior que zero");
                });
            }

        }
    }
}

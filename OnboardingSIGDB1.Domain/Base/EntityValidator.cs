using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnboardingSIGDB1.Domain.Base
{
    public abstract class EntityValidator<TEntity> : AbstractValidator<TEntity>
        where TEntity : EntityValidator<TEntity>
    {
        [NotMapped]
        public ValidationResult ValidationResult { get; protected set;}

        public abstract bool Validar();
    }
}

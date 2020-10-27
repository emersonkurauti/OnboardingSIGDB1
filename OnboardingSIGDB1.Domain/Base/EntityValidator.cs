using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnboardingSIGDB1.Domain.Base
{
    public abstract class EntityValidator<TId, TEntity> : AbstractValidator<TEntity>
        where TId : struct
        where TEntity : EntityValidator<TId, TEntity>
    {
        public TId Id { get; protected set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set;}

        public abstract bool Validar();
    }
}

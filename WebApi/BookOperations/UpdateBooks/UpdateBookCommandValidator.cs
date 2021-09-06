using System;
using FluentValidation;

namespace WebApi.BookOperations.UpdateBooks
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookQuery>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate).LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}
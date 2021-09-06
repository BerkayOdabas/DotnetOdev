using FluentValidation;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksCommandValidator : AbstractValidator<GetBooksById>
    {
        public GetBooksCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
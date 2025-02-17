namespace Ambev.DeveloperEvaluation.Domain.Rules
{
    public interface IRule<TIn,TOut>
    {
        bool Matches(TIn subject);
        TOut Execute(TIn subject);

    }
}

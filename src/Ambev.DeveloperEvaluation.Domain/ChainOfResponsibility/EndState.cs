namespace Ambev.DeveloperEvaluation.Domain.ChainOfResponsibility
{
    public abstract class EndState : IState
    {
        public IState? Next() => null;
    }
}

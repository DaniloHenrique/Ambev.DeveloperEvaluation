namespace Ambev.DeveloperEvaluation.Domain.ChainOfResponsibility
{
    public interface IState
    {
        IState? Next();
    }
}

namespace Ambev.DeveloperEvaluation.Domain.ChainOfResponsibility
{
    public abstract class Chain<TStartState,TEndState>
        where TStartState : class, IState
        where TEndState : EndState
    {
        readonly TStartState _start;
        public Chain(TStartState start) 
        {
            _start = start; 
        }

        public TEndState? Run()
        {
            IState? state = _start;

            do
            {
                state = state?.Next();
            }
            while(state is not TEndState);

            return state as TEndState;
        }
    }
}

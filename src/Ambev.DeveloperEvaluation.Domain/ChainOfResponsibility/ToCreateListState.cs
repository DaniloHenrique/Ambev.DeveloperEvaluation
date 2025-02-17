using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.ChainOfResponsibility
{
    public class ToCreateListState<TEntity> : IState
        where TEntity : BaseIdentityEntity
    {
        readonly List<TEntity> _previous;
        readonly List<TEntity> _received;

        public ToCreateListState(
            List<TEntity> previous, 
            List<TEntity> received
        ) 
        { 
            _previous = previous;
            _received = received;
        }
        public IState? Next()
        {
            var toCreateList = _received.Where(i => i.Id==0).ToList();

            var toUpdateOrDeleteList = _received.Except(toCreateList).ToList();

            return new ToUpdateListState<TEntity>(_previous, toUpdateOrDeleteList)
            {
                ToCreateList = toCreateList
            };
        }
    }
}

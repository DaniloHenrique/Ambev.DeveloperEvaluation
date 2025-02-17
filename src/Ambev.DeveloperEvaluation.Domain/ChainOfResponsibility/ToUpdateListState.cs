using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.ChainOfResponsibility
{
    public class ToUpdateListState<TEntity> : IState
        where TEntity : BaseIdentityEntity
    {
        public List<TEntity> ToCreateList { private get; set; } = new List<TEntity>();

        readonly List<TEntity> _previous;
        readonly List<TEntity> _toUpdateOrDeleteList;

        public ToUpdateListState(List<TEntity> previous, List<TEntity> toUpdateOrDeleteList) 
        {
            _previous = previous;
            _toUpdateOrDeleteList = toUpdateOrDeleteList;   
        }
        public IState? Next()
        {
            var previousIds = _previous.Select(item => item.Id);

            var toUpdateList = _toUpdateOrDeleteList.Where(item => previousIds.Contains(item.Id)).ToList();

            var removeIds = previousIds.Except(toUpdateList.Select(item => item.Id));

            var toRemoveList = _previous.Where(item => removeIds.Contains(item.Id)).ToList();

            return new ToCommandListState<TEntity>(ToCreateList,toUpdateList, toRemoveList);
        }
    }
}

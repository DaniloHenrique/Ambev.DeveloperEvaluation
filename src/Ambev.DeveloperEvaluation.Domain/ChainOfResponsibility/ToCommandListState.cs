using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.ChainOfResponsibility
{
    public class ToCommandListState<TEntity>:EndState
        where TEntity : BaseIdentityEntity
    {
        public List<TEntity> ToCreate { get; }
        public List<TEntity> ToUpdate { get; }
        public List<TEntity> ToRemove { get; }
        public ToCommandListState(
            List<TEntity> toCreateList, 
            List<TEntity> toUpdateList, 
            List<TEntity> toRemoveList
        )
        {
            ToCreate = toCreateList;
            ToUpdate = toUpdateList;
            ToRemove = toRemoveList;
        }
    }
}

using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contract;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Branch : BaseEntity<int>, ISubstance
    {
        public string Name { get; set; } = string.Empty;

        public Sale? Sale { get; set; }
    }
}

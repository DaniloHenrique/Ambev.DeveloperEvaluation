namespace Ambev.DeveloperEvaluation.Domain.Contract
{
    public interface IRating
    {
        public double Rate { get; set; }
        public int Count { get; set; }
    }
}

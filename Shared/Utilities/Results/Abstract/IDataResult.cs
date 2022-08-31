namespace Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {   // e.g.
        // new DataResult<Category>(ResultStatus.Success,category);
        // new DataResult<IList<Category>>(ResultStatus.Success,categoryList);
        public T Data { get; }
    }
}
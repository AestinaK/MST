using System.Collections;

namespace App.Base.ValueObject;

public class PagedResult<T> : IEnumerable<T> where T :class
{
    public readonly IEnumerable<T> Collection;
    public readonly int CollectionSize;
    public readonly int CurrentPage;
    public readonly int Limit;

    public PaginationInfo Info => new PaginationInfo(CollectionSize, CurrentPage, CollectionSize == 0 ? 0 : Limit);
    
    public PagedResult(IEnumerable<T> collection, int collectionSize,int currentPage, int limit)
    {
        Collection = collection;
        CollectionSize = collectionSize;
        CurrentPage = currentPage;
        Limit = limit;
    }

    public IEnumerator<T> GetEnumerator() => Collection.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
public class PaginationInfo
{
    public long TotalCount { get; set; }
    public int Page { get; set; }
    public int Limit { get; set; }

    public PaginationInfo(long totalCount, int page, int limit)
    {
        TotalCount = totalCount;
        Page = page;
        Limit = limit;
    }
}
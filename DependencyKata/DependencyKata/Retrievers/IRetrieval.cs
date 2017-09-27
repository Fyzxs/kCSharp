namespace DependencyKata.Retrievers
{
    public interface IRetrieval<T>
    {
        T Retrieve();
    }
}
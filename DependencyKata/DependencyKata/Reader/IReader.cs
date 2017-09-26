namespace DependencyKata.Reader
{
    public interface IReader
    {
        string Line();
        void WaitForKey();
    }
}
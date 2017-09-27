namespace DependencyKata.Db {
    public interface IDatabaseLogBookEnd
    {
        void Save(string logEntry);
    }
}
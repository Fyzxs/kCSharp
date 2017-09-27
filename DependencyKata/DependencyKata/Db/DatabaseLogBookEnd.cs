namespace DependencyKata.Db {
    public class DatabaseLogBookEnd : IDatabaseLogBookEnd
    {
        public void Save(string logEntry) => Database.SaveToLog(logEntry);
    }
}
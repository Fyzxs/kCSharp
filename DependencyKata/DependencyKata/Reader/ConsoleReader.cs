namespace DependencyKata.Reader
{
    public class ConsoleReader : IReader
    {
        private readonly IReaderBookEnd _readerBookEnd;

        public ConsoleReader() : this(new ReaderBookEnd()) { }

        public ConsoleReader(IReaderBookEnd readerBookEnd) => _readerBookEnd = readerBookEnd;

        public string Line() => _readerBookEnd.ReadLine();
        public void WaitForKey() => _readerBookEnd.ReadKey();
    }
}
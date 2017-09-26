namespace DependencyKata.Writer
{
    public class ConsoleWriter : IWriter
    {
        private readonly IWriterBookEnd _writerBookEnd;

        public ConsoleWriter() : this(new ConsoleWriterBookEnd()) { }

        public ConsoleWriter(IWriterBookEnd writerBookEnd) => _writerBookEnd = writerBookEnd;

        public void WriteLine(string text) => _writerBookEnd.WriteLine(text);
        public void Write(string text) => _writerBookEnd.Write(text);
    }
}
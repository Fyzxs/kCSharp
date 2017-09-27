using DependencyKata.Reader;
using DependencyKata.Writer;

namespace DependencyKata.Retrievers
{
    public class Retrieval : IRetrieval<string>
    {
        private readonly string _displayText;
        private readonly IWriter _writer;
        private readonly IReader _reader;

        public Retrieval(string displayText) : this(displayText, new ConsoleWriter(), new ConsoleReader())
        { }

        public Retrieval(string displayText, IWriter writer, IReader reader)
        {
            _displayText = displayText;
            _writer = writer;
            _reader = reader;
        }

        public string Retrieve()
        {
            _writer.WriteLine(_displayText);
            return _reader.Line();
        }
    }
}
using System;

namespace DependencyKata.Writer
{
    public class ConsoleWriterBookEnd : IWriterBookEnd
    {
        public void WriteLine(string text) => Console.WriteLine(text);
        public void Write(string text) => Console.Write(text);
    }
}
using System;

namespace DependencyKata.Reader
{
    public class ReaderBookEnd : IReaderBookEnd
    {
        public string ReadLine() => Console.ReadLine();
        public ConsoleKeyInfo ReadKey() => Console.ReadKey();
    }
}
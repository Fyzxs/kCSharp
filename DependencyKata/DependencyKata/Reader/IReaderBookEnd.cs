using System;

namespace DependencyKata.Reader
{
    public interface IReaderBookEnd
    {
        string ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}
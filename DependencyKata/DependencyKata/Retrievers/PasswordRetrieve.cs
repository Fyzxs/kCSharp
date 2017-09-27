using System;
using DependencyKata.Reader;
using DependencyKata.Texts;
using DependencyKata.Writer;

namespace DependencyKata.Retrievers {
    public class PasswordRetrieve : IRetrieval<string>
    {

        private readonly IWriter _writer;
        private readonly IReader _reader;

        public PasswordRetrieve() : this(new ConsoleWriter(), new ConsoleReader())
        { }

        public PasswordRetrieve(IWriter writer, IReader reader)
        {
            _writer = writer;
            _reader = reader;
        }

        public string Retrieve()
        {
            string password = new Retrieval("Enter your password").Retrieve();
            string confirmPassword = new Retrieval("Re-enter your password").Retrieve();

            if (new EqualStrings(password, confirmPassword).Value()) return password;

            _writer.WriteLine("The passwords don't match.");
            _reader.WaitForKey();
            throw new Exception("Exit the App");
        }
    }
}
using DependencyKata.Db;
using DependencyKata.Reader;
using DependencyKata.Texts;
using DependencyKata.Writer;
using System;
using System.IO;

namespace DependencyKata
{
    public class DoItAll
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private readonly UserDetails _userDetails = new UserDetails();

        public DoItAll() : this(new ConsoleWriter(), new ConsoleReader()) { }

        public DoItAll(IWriter writer, IReader reader)
        {
            _writer = writer;
            _reader = reader;
        }

        public void Do()
        {
            _writer.WriteLine("Enter a username");
            _userDetails.Username = _reader.Line();

            _writer.WriteLine("Enter your full name");
            string fullName = _reader.Line();

            _writer.WriteLine("Enter your password");
            _userDetails.Password = _reader.Line();

            _writer.WriteLine("Re-enter your password");
            string confirmPassword = _reader.Line();

            if (_userDetails.PasswordEncrypted != new UserDetails { Password = confirmPassword }.PasswordEncrypted)
            {
                _writer.WriteLine("The passwords don't match.");
                _reader.WaitForKey();
                return;
            }

            IText message = new FormatString("Saving Details for User ({0}, {1}, {2})\n", _userDetails.Username, fullName, _userDetails.PasswordEncrypted);

            _writer.Write(message.AsString());

            try
            {
                new DatabaseLogBookEnd().Save(message.AsString());
            }
            catch (Exception ex)
            {
                // If database write fails, write to file
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine("{0} - Database.SaveToLog Exception: \r\n{1}",
                        message, ex.Message);
                }
            }
            _reader.WaitForKey();
        }
    }
}

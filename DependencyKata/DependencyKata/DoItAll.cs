using DependencyKata.Db;
using DependencyKata.Reader;
using DependencyKata.Retrievers;
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

        public DoItAll() : this(new ConsoleWriter(), new ConsoleReader()) { }

        public DoItAll(IWriter writer, IReader reader)
        {
            _writer = writer;
            _reader = reader;
        }

        public void Do()
        {
            UserDetails userDetails = new UserDetailsRetrieve().Retrieve();

            IText message = new FormatString("Saving Details for User ({0}, {1}, {2})\n", userDetails.Username, userDetails.Fullname, userDetails.PasswordEncrypted);

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

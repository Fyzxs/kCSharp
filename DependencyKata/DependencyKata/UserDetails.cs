using DependencyKata.Texts;
using DependencyKata.Writer;

namespace DependencyKata
{
    public class UserDetails
    {
        private readonly IWriter _writer;
        private string _passwordEncrypted;
        private string _password;
        private string _username;
        private string _fullname;

        public UserDetails() : this(new ConsoleWriter()) { }

        public UserDetails(IWriter writer) => _writer = writer;

        public string Password
        {
            set
            {
                if (value.Length < 8)
                {
                    _writer.WriteLine("Password must be at least 8 characters in length. You fail.");
                }
                else
                {
                    _password = value;
                }
            }
        }

        public string PasswordEncrypted
        {
            get
            {
                // Encrypt the password (just reverse it, should be secure)
                _passwordEncrypted = new ReverseString(_password).AsString();
                return _passwordEncrypted;
            }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; }
        }
    }
}
namespace DependencyKata.Retrievers
{
    public class UserDetailsRetrieve : IRetrieval<UserDetails>
    {
        public UserDetails Retrieve()
        {
            string username = new Retrieval("Enter a username").Retrieve();
            string fullname = new Retrieval("Enter your full name").Retrieve();
            string password = new PasswordRetrieve().Retrieve();

            return new UserDetails { Fullname = fullname, Username = username, Password = password };
        }
    }
}
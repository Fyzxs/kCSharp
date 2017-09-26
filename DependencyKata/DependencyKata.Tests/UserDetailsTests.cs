using DependencyKata.Writer;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyKata.Tests
{
    [TestClass]
    public class UserDetailsTests
    {
        [TestMethod]
        public void ShouldWriteLineGivenLessThanEightPassword()
        {
            //Arrange
            FakeWriter fakeWriter = new FakeWriter();
            UserDetails userDetails = new UserDetails(fakeWriter);

            //Act
            userDetails.Password = "1234567";


            //Assert
            fakeWriter.AssertWriteLineInvoked();
        }
        [TestMethod]
        public void ShouldNotWriteLineGivenNotLessThanEightPassword()
        {
            //Arrange
            FakeWriter fakeWriter = new FakeWriter();
            UserDetails userDetails = new UserDetails(fakeWriter);

            //Act
            userDetails.Password = "12345678";


            //Assert
            fakeWriter.AssertWriteLineNotInvoked();
        }
        [TestMethod]
        public void ShouldEncryptPassword()
        {
            //Arrange
            FakeWriter fakeWriter = new FakeWriter();
            UserDetails userDetails = new UserDetails(fakeWriter);

            //Act
            userDetails.Password = "123456789";

            //Assert
            userDetails.PasswordEncrypted.Should().Be("987654321");
        }
    }

    public class FakeWriter : IWriter
    {
        private bool _invokedWriteLine;
        private bool _invokedWrite;

        public void WriteLine(string text) => _invokedWriteLine = true;

        public void Write(string text) => _invokedWrite = true;

        public void AssertWriteLineInvoked() => _invokedWriteLine.Should().BeTrue();
        public void AssertWriteInvoked() => _invokedWrite.Should().BeTrue();
        public void AssertWriteLineNotInvoked() => _invokedWriteLine.Should().BeFalse();
    }
}
